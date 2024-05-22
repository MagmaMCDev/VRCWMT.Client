using System.Drawing.Drawing2D;
using KPreisser.UI;
using TaskDialog = KPreisser.UI.TaskDialog;

namespace VRCWMT;

internal class Client
{
    public static string User_Agent = "VRChat-World-Moderation-Tool.Client-" + Environment.OSVersion.Platform + $"-{Environment.OSVersion.VersionString.Replace(" ", "-")}";
#pragma warning disable CS8618
    public static Version Version
    {
        get;
        private set;
    } = new("0.4.0");
    public static string[] Arguments
    {
        get;
        private set;
    }
    private readonly NotifyIcon TaskIcon = new();
    private MainWindow Window;
    public Client(string[] Args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Config.SetupConfig();
        Version.SetUpdateURL("https://vrc.magmamc.dev/API/V2/Version/Latest");
        Arguments = Args;
        Start();
    }
#pragma warning restore CS8618


    [STAThread]
    private void Start()
    {
        SplashScreen SS = new()
        {
            ShowInTaskbar = false
        };
        SS.Show();
        TaskIcon.Icon = AppResources.VRCWMT;
        TaskIcon.ContextMenuStrip = new ContextMenuStrip();
        TaskIcon.ContextMenuStrip.Items.Add("Logout", null, (sender, e) =>
        {
            if (TaskDialog.Show(text: "Are You Sure You Want To Logout?",
                title: "VRCWMT",
                buttons: TaskDialogButtons.Yes | TaskDialogButtons.No,
                icon: TaskDialogStandardIcon.Information) == TaskDialogResult.No) return;
            TaskIcon.Dispose();
            Window.Hide();
            Window.Dispose();
            Config.GithubAuth = "";
            Config.WriteConfig();
            Application.Restart();

        });
        TaskIcon.ContextMenuStrip.Items.Add("Close Instance", null, (sender, e) => Window.CloseInstance_Click(null, null));
        TaskIcon.ContextMenuStrip.Items.Add("Publish Commits", null, (sender, e) => Window.PublishCommit_Click(null, null));
        TaskIcon.ContextMenuStrip.Items.Add("Manage Staff", null, (sender, e) => Window.ManageStaff_Click(null, null));
        TaskIcon.ContextMenuStrip.Items.Add("Show", null, (sender, e) => Window.ShowWindow());
        TaskIcon.ContextMenuStrip.Items.Add("Hide", null, (sender, e) => Window.HideWindow());
        TaskIcon.ContextMenuStrip.Items.Add("Exit", null, (sender, e) => 
        { 
            TaskIcon.Dispose(); 
            Window.Hide();
            Window.Dispose();
            Environment.Exit(0);
        });
        TaskIcon.DoubleClick += (sender, e) => Window.ShowWindow();
        TaskIcon.Visible = true;

        Window = new MainWindow(SS);
        Application.Run(Window);
    }
}
