using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;
using MagmaMc.UAS;
using MagmaMC.SharedLibrary;
using System.Text.RegularExpressions;
using VRCWMT.Models;
using KPreisser.UI;
using TaskDialog = KPreisser.UI.TaskDialog;
using MagmaMc.BetterForms;
using static VRCWMT.Config;

namespace VRCWMT;

public partial class MainWindow : Form
{
    private VRCW? CurrentWorld = null;
    private GithubUser? githubUser = null;
    private string CurrentGroup = "";
    private string[]? previousGroups;
    public static bool WriteMode = true;

    private readonly Dictionary<string, Control[]> PlayerControls = new();
    private readonly Dictionary<string, Control[]> GroupControls = new();
    public bool Initialized { get; private set; } = false;


    private readonly SplashScreen splashScreen;
    private ColoredPictureBox AddButton;
    public MainWindow(SplashScreen ss)
    {
        splashScreen = ss;
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        this.Opacity = 0;
        this.ShowInTaskbar = false;
        TransparencyKey = Color.Transparent;
    }

    public async Task GithubLogin()
    {
        ProcessStartInfo PSI = new("https://vrc.magmamc.dev/API/V1/Client/Login");
        PSI.UseShellExecute = true;
        Process.Start(PSI);

        var listener = new TcpListener(IPAddress.Loopback, 3928);
        listener.Start();
        Console.WriteLine("Server started. Waiting for GitHub OAuth token...");
        splashScreen.TopMost = false;

        while (true)
        {
            using TcpClient TCPClient = await listener.AcceptTcpClientAsync();
            using var stream = TCPClient.GetStream();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            var request = await reader.ReadLineAsync();
            if (!string.IsNullOrEmpty(request) && request.Contains("?auth="))
            {
                var authToken = request.Split('=')[1].Split(' ')[0];
                Config.GithubAuth = authToken;
                Config.WriteConfig();
                break;
            }
            else
            {
                Console.WriteLine("Invalid request");
            }
        }
        listener.Stop();
        listener.Dispose();
        splashScreen.TopMost = true;
    }

    private async void Form_Load(object sender, EventArgs e)
    {
        Config.ReadConfig();
        #region Form Controls
        AddButton = new ColoredPictureBox
        {
            Image = AppResources.Material_Symbols_Add,
            Location = new Point(370, 6),
            Name = "AddPlayer",
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.Zoom,
            TabIndex = 0,
            TabStop = false,
            OverlayColor = Color.White,
            Cursor = Cursors.Hand,
            Visible = false
        };
        AddButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.Green;
        AddButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
        AddButton.MouseClick += (_, _) =>
        {
            if (!Initialized || !CanEdit)
                return;
            if (string.IsNullOrWhiteSpace(CurrentGroup))
                return;

            AddPlayer PlayerForm = new AddPlayer();
            Hide();
            Opacity = 0.0f;
            PlayerForm.Text += CurrentGroup;
            PlayerForm.ShowDialog();
            Opacity = 1.0f;
            Show();


            if (PlayerForm.Canceled)
                return;

            if (string.IsNullOrWhiteSpace(PlayerForm.playerID))
                return;


            BeginData();
            AddButton.Visible = false;
            foreach (Control item in PlayersPanelInternal.Controls)
                item.Dispose();
            PlayerControls.Clear();
            PlayersPanelInternal.Controls.Clear();
            new Thread(() =>
            {
                try
                {
                    CurrentWorld!.AddPlayer(CurrentGroup, PlayerForm.playerID, PlayerForm.message).Wait();

                    Invoke((MethodInvoker)delegate
                    {
                        UpdatePlayers();
                    });
                }
                catch { }
                EndData();

            }).Start();

        };
        PlayersPanelBase.Controls.Add(AddButton);


        ColoredPictureBox AddGroupButton = new ColoredPictureBox
        {
            Image = AppResources.Material_Symbols_Add,
            Location = new Point(290, 8),
            Name = "AddGroup",
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.Zoom,
            TabIndex = 0,
            TabStop = false,
            OverlayColor = Color.White,
            Cursor = Cursors.Hand,
        };
        AddGroupButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.Green;
        AddGroupButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
        AddGroupButton.MouseClick += (_, _) =>
        {
            if (!Initialized || !CanEdit)
                return;

            AddGroup GroupForm = new AddGroup();
            Hide();
            Opacity = 0.0f;
            GroupForm.ShowDialog();
            Opacity = 1.0f;
            Show();

            if (GroupForm.Canceled)
                return;

            CurrentWorld!.AddGroup(GroupForm.GroupName.Text, GroupForm.GroupPermissions.Text).ConfigureAwait(false);

            foreach (Control item in PlayersPanelInternal.Controls)
                item.Dispose();
            PlayerControls.Clear();
            PlayersPanelInternal.Controls.Clear();
            AddButton.Visible = false;
            UpdateGroups();
        };

        ColoredPictureBox RemoveGroupButton = new ColoredPictureBox
        {
            Image = AppResources.Material_Symbols_Remove,
            Location = new Point(290 - 32, 8),
            Name = "RemoveGroup",
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.Zoom,
            TabIndex = 0,
            TabStop = false,
            OverlayColor = Color.White,
            Cursor = Cursors.Hand,
        };
        RemoveGroupButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.Red;
        RemoveGroupButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
        RemoveGroupButton.MouseClick += (_, _) =>
        {
            if (!Initialized || !CanEdit)
                return;
            InputData Group = InputBox.Show("Enter Permission Group Name To Remove", "Remove Group", 1);
            if (Group.Canceled)
                return;
            BeginData();
            AddButton.Visible = false;
            foreach (Control item in PlayersPanelInternal.Controls)
                item.Dispose();
            PlayerControls.Clear();
            PlayersPanelInternal.Controls.Clear();
            new Thread(() =>
            {
                try
                {
                    CurrentWorld!.RemoveGroup(Group.Value).Wait();

                    Invoke((MethodInvoker)delegate
                    {
                        UpdateGroups();
                    });
                }
                catch { }
                EndData();

            }).Start();


        };

        if (WriteMode)
        {
            PlayersPanelBase.Controls.Add(AddButton);
            GroupPanelBase.Controls.Add(AddGroupButton);
            GroupPanelBase.Controls.Add(RemoveGroupButton);
        }

        GroupPanelInternal.AutoScroll = true;
        GroupPanelInternal.HorizontalScroll.Visible = false;
        GroupPanelInternal.VerticalScroll.Visible = true;
        GroupPanelInternal.VerticalScroll.Enabled = true;
        PlayersPanelInternal.AutoScroll = true;
        PlayersPanelInternal.HorizontalScroll.Visible = false;
        PlayersPanelInternal.HorizontalScroll.Enabled = false;
        PlayersPanelInternal.VerticalScroll.Visible = true;
        PlayersPanelInternal.VerticalScroll.Enabled = true;

        #endregion

        #region SplashScreen
        await Task.Delay(150);
        splashScreen.Status.Text = "Checking Version...";
        Version? LatestV = Client.Version.GetLatestVersion();
        if (LatestV == null)
        {
            splashScreen.Dispose();
            var ae = TaskDialog.Show(text: "Failed To Check Client Version Retry?",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Retry | TaskDialogButtons.Abort | TaskDialogButtons.Ignore,
                icon: TaskDialogStandardIcon.Information);
            if (ae == TaskDialogResult.Abort)
            {
                Commits.Text = "";
                Dispose();
                Environment.Exit(-1);
                return;
            }
            else if (ae == TaskDialogResult.Retry)
            {
                Commits.Text = "";
                Dispose();
                Application.Restart();
            }

        }
        if (Client.Version < LatestV)
        {
            splashScreen.Hide();
            if (TaskDialog.Show(text: "You are on an outdated version. Do you wish to update?",
                                title: "VRCWMT",
                                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.Yes)
            {
                string updateUrl = LatestV.updateURL!.ToString();
                string tempFilePath = Path.Combine(Path.GetTempPath(), "VRCWMT_Update.exe");

                using (var client = new WebClient())
                {
                    client.DownloadFile(updateUrl, tempFilePath);
                }

                // Construct the arguments to relaunch the new version and terminate the old one
                string currentExePath = Application.ExecutablePath;
                string arguments = $"/C timeout 2 && move /Y \"{tempFilePath}\" \"{currentExePath}\" && start \"\" \"{currentExePath}\"";

                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(psi);
                splashScreen.Dispose();
                Commits.Text = "";
                Dispose();
                Environment.Exit(0);
            }
            else
            {
                splashScreen.Show();
            }
        }


        splashScreen.Status.Text = "Logging In...";
        await Task.Delay(250);
        while (string.IsNullOrWhiteSpace(Config.GithubAuth))
            await GithubLogin();
        while (Github.GetUserAsync(Config.GithubAuth) == null)
            await GithubLogin();




        splashScreen.Status.Text = "Loading UserData...";
        await Task.Delay(200);
        githubUser = await Github.GetUserAsync(Config.GithubAuth);
        Username.Text = githubUser.name;
        ProfileIcon.Image = UDUtils.DownloadBitmap(githubUser.avatar_url);

        splashScreen.Status.Text = "Starting...";
        #endregion SplashScreen
        #region Welcome Wizard

        var OpenWizard = false;
        if (Config.WorldID == "")
            OpenWizard = true;
        else
        {
            splashScreen.Status.Text = "Checking WorldID...";
            if (!Regex.Match(Config.WorldID, @"^WRD_[0-9A-Z]{32}$").Success)
                OpenWizard = true;
            else if (API.GetWorld(Config.WorldID) == null)
                OpenWizard = true;
            else
            {
                splashScreen.Status.Text = "Loading Instance...";
                CurrentWorld = API.GetWorld(Config.WorldID);
                SiteUser? User = API.GetUser(Config.WorldID, githubUser.login);
                if (User != null)
                {
                    user = User;
                    WriteMode = !User.read || User.siteOwner;
                }
                if (User == null)
                    OpenWizard = true;
                else if (!User.siteAdmin && !User.worldCreator && !User.siteOwner && !User.read)
                    OpenWizard = true;
                else
                    new Thread(() =>
                    {
                        BeginData();
                        UpdateContainers();
                        EndData();
                    }).Start();
                
            }
        }
        #endregion

        for (var opacity = splashScreen.Opacity; opacity >= 0; opacity -= 0.02)
        {
            splashScreen.Opacity = opacity;
            await Task.Delay(2);
        }
        splashScreen.Close();
        splashScreen.Dispose();

        if (OpenWizard)
        {
            LoadInstance();
            if (string.IsNullOrWhiteSpace(Config.WorldID))
            {
                Environment.Exit(-1);
                return;
            }
        }
        else
            LoadForm();
        Initialized = true;
    }
    private bool AreArraysEqual(string[] array1, string[] array2)
    {
        if (array1 == null || array2 == null)
            return false;

        if (array1.Length != array2.Length)
            return false;

        for (uint i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }

    private void Form_Shown(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            while (true)
            {

                if (!IsDisposed && !Disposing)
                {
                    if (!string.IsNullOrEmpty(Config.WorldID) && !string.IsNullOrEmpty(Config.GithubAuth))
                        UpdateContainers();
                    for (byte i = 0; i < UpdateTime; i++)
                        if (!IsDisposed && !Disposing)
                            Thread.Sleep(1000);
                }
                else
                    return;
            }

        }).Start();
    }
    SiteUser user;
    private void LoadForm()
    {

        WriteMode = !user.read || user.siteOwner;
        CurrentWorld = API.GetWorld(Config.WorldID)!;
        githubUser = Github.GetUserAsync(Config.GithubAuth).GetResult();
        if (!user.worldCreator)
            ManageStaffButton.Visible = false;

        Text = CurrentWorld.worldName;
        if (user.read && !user.siteOwner)
            Text += " READ MODE!";
        FormBorderStyle = FormBorderStyle.Fixed3D;
        ShowInTaskbar = true;
        for (var opacity = 0.0; opacity <= 1; opacity += 0.1)
        {
            Opacity = opacity;
            Thread.Sleep(2);
        }
        Opacity = 1.0f;
    }

    private void LoadInstance()
    {
        CurrentWorld = null;
        Initialized = false;
        Config.WorldID = "";
        Config.WriteConfig();
        WriteMode = !user.read || user.siteOwner;
        WelcomeWizard welcomeWizard = new();
        welcomeWizard.ShowDialog();
        welcomeWizard.Dispose();
        if (welcomeWizard.Canceled) return;
        LoadForm();
        Initialized = true;
    }

    private void UpdateContainers()
    {
        if (IsDisposed || Disposing)
            return;
        UpdateCommits();
        UpdateGroups();
    }

    private void UpdateCommits()
    {
        var commits = API.GetCommits(Config.WorldID);
        Invoke((MethodInvoker)delegate
        {
            Commits.Text = string.Join('\n', commits);
        });
    }
    private void UpdateGroups()
    {
        new Thread(() =>
        {
            try
            {

                BeginData();
                if (CurrentWorld != null)
                {
                    var _groups = CurrentWorld!.GetGroups();
                    if (_groups == null)
                    {
                        Thread.Sleep(50);
                        return;
                    }
                    var currentGroups = _groups.OrderByDescending(p => p.Value.Count()).ToDictionary().Keys.ToArray();
                    if (!AreArraysEqual(currentGroups, previousGroups))
                    {
                        ushort xIndex = 0;
                        ushort controlHeight = 25;
                        ushort margin = 10;
                        ushort maxControlsPerColumn = 7;
                        var panelHeight = maxControlsPerColumn * (controlHeight + margin);

                        Invoke((MethodInvoker)delegate
                        {
                            DisposeGroups();
                            foreach (var item in currentGroups)
                            {
                                BetterRadioButton checkBox = new BetterRadioButton
                                {
                                    Text = item,
                                    Width = 180,
                                    Location = new Point(10, margin + (xIndex * (controlHeight + margin))),
                                    ForeColor = Color.Wheat,
                                };
                                checkBox.MouseUp += (sender, e) =>
                                {
                                    CurrentGroup = checkBox.Text;
                                    UpdatePlayers();
                                };
                                GroupPanelInternal.Controls.Add(checkBox);
                                xIndex++;
                            }

                            GroupPanelInternal.VerticalScroll.Maximum = panelHeight;
                        });

                        previousGroups = currentGroups;
                    }
                }
            }
            finally
            {
                EndData();
            }
        }).Start();
    }
    private void UpdatePlayers()
    {
        new Thread(() =>
        {
            try
            {

                BeginData();
                if (CurrentWorld != null)
                {
                    PlayerItem[]? Players = CurrentWorld.GetPlayers(CurrentGroup);
                    if (Players == null)
                        return;

                    ushort xIndex = 0;
                    ushort controlHeight = 25;
                    ushort margin = 10;
                    ushort maxControlsPerColumn = 7;
                    var panelHeight = maxControlsPerColumn * (controlHeight + margin);

                    PlayersPanelInternal.Invoke((MethodInvoker)delegate
                    {
                        DisposePlayers();

                        AddButton.Visible = true;
                        foreach (PlayerItem item in Players)
                        {
                            Label Username = new Label
                            {
                                Text = item.displayName,
                                Width = 200,
                                Location = new Point(10, margin + (xIndex * (controlHeight + margin))),
                                ForeColor = Color.Wheat,
                            };

                            ColoredPictureBox InfoButton = new ColoredPictureBox
                            {
                                Image = AppResources.Material_symbols_Info,
                                Location = new Point(332, margin + (xIndex * (controlHeight + margin))),
                                Name = "Info",
                                Size = new Size(32, 32),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                TabIndex = 0,
                                TabStop = false,
                                Cursor = Cursors.Hand
                            };
                            InfoButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.LightBlue;
                            InfoButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
                            InfoButton.MouseDown += (Control, _) =>
                            {
                                PlayerInfo player = new(CurrentWorld, CurrentGroup, item);
                                if (!AllowMultipleWindows)
                                {
                                    Hide();
                                    Opacity = 0.0f;
                                    DisposePlayers();
                                    if (FastGC)
                                        GC.Collect();
                                    player.ShowDialog();
                                    player.Dispose();
                                    Opacity = 1.0f;
                                    Show(); new Thread(() =>
                                    {
                                        BeginData();
                                        UpdatePlayers();
                                        EndData();
                                    }).Start();
                                }
                                else
                                {
                                    player.Show();
                                    player.FormClosed += (_, _) =>
                                    {
                                        player.Dispose();
                                    };
                                }

                            };

                            if (WriteMode)
                            {
                                ColoredPictureBox DeleteButton = new ColoredPictureBox
                                {
                                    Image = AppResources.Material_symbols_Delete,
                                    Location = new Point(364, margin + (xIndex * (controlHeight + margin))),
                                    Name = "Delete",
                                    Size = new Size(32, 32),
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    TabIndex = 1,
                                    TabStop = false,
                                    OverlayColor = Color.White,
                                    Cursor = Cursors.Hand
                                };
                                DeleteButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.Red;
                                DeleteButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
                                DeleteButton.MouseDown += (_, _) =>
                                {
                                    InputData Data = InputBox.Show($"Please Provide A Reason For Removing The Player: {item.displayName}, From The Group: {CurrentGroup}", "VRCWMT", 1);
                                    if (Data.Canceled)
                                        return;
                                    CurrentWorld.RemovePlayer(CurrentGroup, item.playerID, Data.Value).ConfigureAwait(false);
                                    foreach (Control item in PlayerControls[item.displayName])
                                        item.Dispose();

                                    Control[] controls = new Control[PlayersPanelInternal.Controls.Count];
                                    PlayersPanelInternal.Controls.CopyTo(controls, 0);
                                    foreach (Control item in controls)
                                        if (item.Disposing || item.IsDisposed) PlayersPanelInternal.Controls.Remove(item);
                                };

                                PlayerControls.Add(item.displayName,
                                [
                                    Username,
                                    InfoButton,
                                    DeleteButton
                                ]);

                                PlayersPanelInternal.Controls.Add(DeleteButton);

                            }
                            else
                                PlayerControls.Add(item.displayName,
                                [
                                    Username,
                                    InfoButton,
                                ]);
                            PlayersPanelInternal.Controls.Add(Username);
                            PlayersPanelInternal.Controls.Add(InfoButton);

                            xIndex++;
                        }

                        PlayersPanelInternal.VerticalScroll.Maximum = panelHeight;
                        ProcessPlayerSearch();
                    });
                }
            }
            finally
            {
                EndData();
            }
        })
        {
            Priority = ThreadPriority.Highest
        }.Start();
    }

    public void PublishCommit_Click(object? _, object? __)
    {
        if (string.IsNullOrWhiteSpace(Commits.Text))
            if (TaskDialog.Show(text: "Are You Sure You Want To Commit Nothing?",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No) return;
        new Thread(() =>
        {
            BeginData();
            if (API.PushCommits(Config.WorldID))
                Commits.Invoke((MethodInvoker)delegate
                {
                    Commits.Text = "";
                });
            else
                Invoke((MethodInvoker)delegate
                {
                    TaskDialog.Show(text: "Failed To Push Commits!\nMake Sure You Are Not Sending To Many Requests.",
                        title: "Push Commits",
                        buttons: TaskDialogButtons.OK,
                        icon: TaskDialogStandardIcon.Error);
                });
            EndData();
        }).Start();
    }

    public void CloseInstance_Click(object? _, object? __)
    {
        if (!CanEdit)
            return;
        if (CloseInstanceButton.Enabled)
            if (!string.IsNullOrWhiteSpace(Commits.Text))
            {
                if (TaskDialog.Show(text: "Are You Sure You Want To Close The Instance You Have Unpublished Commits",
                    title: "VRCWMT",
                    buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                    icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No) return;
            }
        CurrentWorld = null;
        Initialized = false;
        Config.WorldID = "";
        Config.WriteConfig();
        this.Opacity = 0.0;
        this.ShowInTaskbar = false;
        BeginData();
        DisposeGroups();
        DisposePlayers();
        EndData();
        WelcomeWizard welcomeWizard = new();
        welcomeWizard.ShowDialog();
        welcomeWizard.Dispose();
        if (welcomeWizard.Canceled)
        {
            Commits.Text = "";
            Close();
            Dispose();
            return;
        }
        new Thread(() =>
        {
            BeginData();
            UpdateContainers();
            EndData();
        }).Start();


        LoadForm();
        Initialized = true;
    }

    private void Window_Closing(object sender, FormClosingEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Commits.Text) && Initialized && WarnBeforeClose && WriteMode)
        {
            if (TaskDialog.Show(text: "Are You Sure You Want To Close You Have Unpublished Commits",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No)
            {
                e.Cancel = true;
                return;
            };
        }
        if (AutoCloseInstance)
        {
            WorldID = "";
            WriteConfig();
        }
        this.Opacity = 0.0f;
        this.ShowInTaskbar = false;
    }

    public void BeginData()
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)delegate
            {
                BeginData();
            });
        }
        else
        {
            ContactingServerGIF.Visible = true;
            PublishCommitButton.Enabled = false;
            CloseInstanceButton.Enabled = false;
            ManageStaffButton.Enabled = false;
            GroupPanelBase.Enabled = false;
            PlayersPanelBase.Enabled = false;
        }
    }

    public void EndData()
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)delegate
            {
                EndData();
            });
        }
        else
        {
            ContactingServerGIF.Visible = false;
            PublishCommitButton.Enabled = true;
            CloseInstanceButton.Enabled = true;
            ManageStaffButton.Enabled = true;
            GroupPanelBase.Enabled = true;
            PlayersPanelBase.Enabled = true;
            if (FastGC)
                GC.Collect();
        }
    }

    public void DisposeGroups()
    {

        if (InvokeRequired)
        {
            GroupPanelInternal.Invoke((MethodInvoker)delegate
            {
                BeginData();
            });
        }
        else
        {
            var controls = GroupPanelInternal.Controls.Cast<Control>().ToArray();

            for (int i = 0; i < controls.Length; i++)
                controls[i].Dispose();

            GroupPanelInternal.Controls.Clear();
            GroupControls.Clear();
        }
    }
    public void DisposePlayers()
    {

        if (InvokeRequired)
        {
            PlayersPanelInternal.Invoke((MethodInvoker)delegate
            {
                BeginData();
            });
        }
        else
        {
            var controls = PlayersPanelInternal.Controls.Cast<Control>().ToArray();

            for (int i = 0; i < controls.Length; i++)
                controls[i].Dispose();

            PlayersPanelInternal.Controls.Clear();
            PlayerControls.Clear();
            AddButton.Visible = false;
        }
    }

    public void ManageStaff_Click(object? _, object? __)
    {
        if (!CanEdit)
            return;
        ManageStaffWindow manageStaff = new(CurrentWorld!);
        Hide();
        Opacity = 0.0f;
        manageStaff.ShowDialog();
        Opacity = 1.0f;
        Show();
    }

    public void ShowWindow()
    {
        if (!Initialized)
            return;
        BeginData();
        UpdatePlayers();
        EndData();
        Show();
    }

    public void HideWindow()
    {
        if (!Initialized)
            return;
        BeginData();
        DisposePlayers();
        EndData();
        Hide();
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        SettingsButton.Enabled = false;
        SettingsWindow Settings = new SettingsWindow();
        if (AllowMultipleWindows)
        {
            Settings.Show();
            Settings.FormClosed += (_, _) =>
            {
                SettingsButton.Enabled = true;
                Settings.Dispose();
                if (FastGC)
                    GC.Collect();
            };
        }else
        {
            Hide();
            Opacity = 0.0f;
            Settings.ShowDialog();
            Settings.Dispose();
            if (FastGC)
                GC.Collect();
            Opacity = 1.0f;
            Show();
            SettingsButton.Enabled = true;
        }
    }

    private void PlayerSearch_TextChanged(object sender, EventArgs e) => ProcessPlayerSearch();
    public void ProcessPlayerSearch()
    {
        string query = PlayerSearch.Text.ToLower();
        var filteredPlayers = PlayerControls.Keys
            .Where(name => name.ToLower().Contains(query))
            .ToArray();

        PlayersPanelInternal.Invoke((MethodInvoker)delegate
        {
            ushort xIndex = 0;
            ushort controlHeight = 25;
            ushort margin = 10;

            foreach (var player in PlayerControls)
            {
                bool any = filteredPlayers.Contains(player.Key);
                foreach (Control control in player.Value)
                {
                    control.Visible = any;
                    if (control.Visible)
                    {
                        int newY = margin + (xIndex * (controlHeight + margin));
                        control.Location = new Point(control.Location.X, newY);
                    }
                }
                if (any)
                    xIndex++;
            }
        });
    }


    public bool CanEdit
    {
        get
        {
            if (CurrentWorld == null)
                return false;

            return true;
        }
    }
}
