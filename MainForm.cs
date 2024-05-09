using System.Net.Sockets;
using System.Net;
using MagmaMc.JEF;
using System.Text;
using System.Diagnostics;
using MagmaMc.UAS;
using static VRCWMT.Client;
using MagmaMC.SharedLibrary;
using System.Text.RegularExpressions;
using VRCWMT.Models;
using KPreisser.UI;
using Microsoft.VisualBasic;
using TaskDialog = KPreisser.UI.TaskDialog;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MagmaMc.BetterForms;
using System.Drawing.Printing;

namespace VRCWMT;

public partial class MainForm : Form
{
    public VRCW? CurrentWorld = null;


    private readonly SplashScreen splashScreen;
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
        splashScreen.TopMost = true;
    }

    private async void Form_Load(object sender, EventArgs e)
    {
        Config.Read();
        #region SplashScreen
        splashScreen.Status.Text = "Logging In...";
        await Task.Delay(350);
        while (Github.GetUserAsync(Config.GithubAuth) == null)
            await GithubLogin();


        splashScreen.Status.Text = "Loading UserData...";
        await Task.Delay(400);
        GithubUser githubUser = await Github.GetUserAsync(Config.GithubAuth);
        Username.Text = githubUser.name;
        ProfileIcon.Image = UDUtils.DownloadBitmap(githubUser.avatar_url);

        splashScreen.Status.Text = "Starting...";
        #endregion SplashScreen
        #region Welcome Wizard
        bool OpenWizard = false;
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
            LoadInstance();
        else
            LoadForm();


    }
    private bool AreArraysEqual(string[] array1, string[] array2)
    {
        if (array1 == null || array2 == null)
            return false;

        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }
    private string[] previousGroups;

    private void Form_Shown(object sender, EventArgs e)
    {

        new Thread(() =>
        {
            while (true)
            {

                if (!IsDisposed && !Disposing)
                {
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
        CurrentWorld = API.GetWorld(Config.WorldID);
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
        Config.WorldID = "";
        Config.Write();
        WelcomeWizard welcomeWizard = new();
        welcomeWizard.ShowDialog();
        welcomeWizard.Dispose();
        if (welcomeWizard.Canceled) return;
        LoadForm();
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
        string[] commits = API.GetCommits(Config.WorldID);
        Invoke((MethodInvoker)delegate
        {
            Commits.Text = string.Join('\n', commits);
        });
    }
    private void UpdateGroups()
    {
        if (CurrentWorld != null)
        {
            string[] currentGroups = CurrentWorld.GetGroups().OrderByDescending(p => p.Value.Count()).ToDictionary().Keys.ToArray();
            if (!AreArraysEqual(currentGroups, previousGroups))
            {
                // Clear the panel
                GroupPanelInternal.Controls.Clear();

                int xIndex = 0;
                int yIndex = 0;
                int controlHeight = 25; // Height of each control
                int margin = 10; // Margin between controls
                int maxControlsPerColumn = 7; // Maximum number of controls per column
                int panelHeight = maxControlsPerColumn * (controlHeight + margin); // Calculate the panel height

                Invoke((MethodInvoker)delegate
                {
                    foreach (string item in currentGroups)
                    {
                        BetterRadioButton checkBox = new BetterRadioButton
                        {
                            Text = item,
                            Width = 180,
                            Location = new Point(10 + (yIndex * 55), margin + (xIndex * (controlHeight + margin))),
                            ForeColor = Color.Wheat,
                        };

                        // Add the control to the panel
                        GroupPanelInternal.Controls.Add(checkBox);

                        // Update indices
                        xIndex++;
                        if (xIndex >= maxControlsPerColumn)
                        {
                            xIndex = 0;
                            yIndex++;
                        }
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

    private void PublishCommit_Click(object sender, EventArgs e)
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

    private void betterButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Commits.Text))
        {
            if (TaskDialog.Show(text: "Are You Sure You Want To Close The Instance You Have Unpublished Commits",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No) return;
        }
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
    }

    private void Window_Closing(object sender, FormClosingEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Commits.Text))
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
        });
    }
    public void EndData()
    {
        Invoke((MethodInvoker)delegate
        {
            ContactingServerGIF.Visible = false;
            PublishCommitButton.Enabled = true;
            CloseInstanceButton.Enabled = true;
        });
    }

}
