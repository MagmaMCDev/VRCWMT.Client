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

namespace VRCWMT;

public partial class MainForm : Form
{
    private VRCW? CurrentWorld = null;
    private GithubUser? githubUser = null;
    private string CurrentGroup = "";
    private string[]? previousGroups;


    private readonly Dictionary<string, Control[]> PlayerControls = new();
    private readonly Dictionary<string, Control[]> GroupControls = new();
    public bool Initialized { get; private set; } = false;


    private readonly SplashScreen splashScreen;
    private ColoredPictureBox AddButton;
    public MainForm(SplashScreen ss)
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
                Config.Write();
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
        Config.Read();
#region Form Controls
        AddButton = new ColoredPictureBox
        {
            Image = AppResources.Material_Symbols_Add,
            Location = new Point(375, 8),
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
            Location = new Point(290-32, 8),
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
                } catch { }
                EndData();

            }).Start();


        };

        PlayersPanelBase.Controls.Add(AddButton);
        GroupPanelBase.Controls.Add(AddGroupButton);
        GroupPanelBase.Controls.Add(RemoveGroupButton);

#endregion 

        #region SplashScreen
        await Task.Delay(150);
        splashScreen.Status.Text = "Checking Version...";
        Version? LatestV = Client.Version.GetLatestVersion();
        if (LatestV == null)
        {
            splashScreen.Dispose();
            if (TaskDialog.Show(text: "Failed To Check Client Version Retry?",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Retry | TaskDialogButtons.Abort,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.Abort)
            {
                Commits.Text = "";
                Dispose();
                Environment.Exit(-1);
                return;
            }
            else
            {
                Commits.Text = "";
                Dispose();
                Application.Restart();
            }

        }
        if (Client.Version < LatestV)
        {
        
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
                if (User == null)
                    OpenWizard = true;
                else if (!User.siteAdmin && !User.worldCreator && !User.siteOwner)
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
                    for (byte i = 0; i < 10; i++)
                        if (!IsDisposed && !Disposing)
                            Thread.Sleep(2 * 1000);
                }
                else
                    return;
            }

        }).Start();
    }

    private void LoadForm()
    {
        CurrentWorld = API.GetWorld(Config.WorldID)!;
        githubUser = Github.GetUserAsync(Config.GithubAuth).GetResult();
        if (!API.GetUser(Config.WorldID, githubUser.login).worldCreator)
        {
            ManageStaffButton.Visible = false;
            // add more as needed
        }
        Text = CurrentWorld.worldName;
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
        Config.Write();
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
                            foreach (Control item in GroupPanelInternal.Controls)
                                item.Dispose();
                            GroupPanelInternal.Controls.Clear();
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
                                // Add the control to the panel
                                GroupPanelInternal.Controls.Add(checkBox);

                                xIndex++;
                            }

                            // Adjust panel height to fit all controls
                            GroupPanelInternal.AutoScroll = true;
                            GroupPanelInternal.VerticalScroll.Visible = true;
                            GroupPanelInternal.VerticalScroll.Enabled = true;
                            GroupPanelInternal.VerticalScroll.Maximum = panelHeight;
                        });

                        // Update the previous groups
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

                    Invoke((MethodInvoker)delegate
                    {
                        foreach (Control item in PlayersPanelInternal.Controls)
                            item.Dispose();
                        PlayerControls.Clear();
                        PlayersPanelInternal.Controls.Clear();
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

                            PlayersPanelInternal.Controls.Add(Username);
                            PlayersPanelInternal.Controls.Add(InfoButton);
                            PlayersPanelInternal.Controls.Add(DeleteButton);

                            xIndex++;
                        }

                        PlayersPanelInternal.AutoScroll = true;
                        PlayersPanelInternal.VerticalScroll.Visible = true;
                        PlayersPanelInternal.VerticalScroll.Enabled = true;
                        PlayersPanelInternal.VerticalScroll.Maximum = panelHeight;
                    });
                }
            }
            finally
            {
                EndData();
            }
        }).Start();
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
            {
                Invoke((MethodInvoker)delegate
                {
                    Commits.Text = "";
                });
            }
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
        Config.Write();
        this.Opacity = 0.0;
        this.ShowInTaskbar = false;
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
        if (!string.IsNullOrWhiteSpace(Commits.Text) && Initialized)
        {
            if (TaskDialog.Show(text: "Area You Sure You Want To Close You Have Unpublished Commits",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No) return;
        }
        this.Opacity = 0.0f;
        this.ShowInTaskbar = false;
    }


    public void BeginData()
    {
        Invoke((MethodInvoker)delegate
        {
            ContactingServerGIF.Visible = true;
            PublishCommitButton.Enabled = false;
            CloseInstanceButton.Enabled = false;
            ManageStaffButton.Enabled = false;
            GroupPanelBase.Enabled = false;
            PlayersPanelBase.Enabled = false;
        });
    }
    public void EndData()
    {
        Invoke((MethodInvoker)delegate
        {
            ContactingServerGIF.Visible = false;
            PublishCommitButton.Enabled = true;
            CloseInstanceButton.Enabled = true;
            ManageStaffButton.Enabled = true;
            GroupPanelBase.Enabled = true;
            PlayersPanelBase.Enabled = true;
        });
    }

    public void ManageStaff_Click(object? _, object? __)
    {
        if (!CanEdit)
            return;
        ManageStaffForm manageStaff = new(CurrentWorld!);
        Hide();
        Opacity = 0.0f;
        manageStaff.ShowDialog();
        Opacity = 1.0f;
        Show();
    }

    public void ShowWindow()
    {
        if (Initialized)
            Show();
    }

    public void HideWindow()
    {
        if (Initialized)
            Hide();
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
