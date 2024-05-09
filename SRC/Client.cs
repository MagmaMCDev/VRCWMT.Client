namespace VRCWMT;

internal class Client
{
    public static string User_Agent = "VRChat-World-Moderation-Tool.Client - " + Environment.OSVersion.Platform + $" - {Environment.OSVersion.VersionString.Replace(" ", "-")}";
#pragma warning disable CS8618
    public static string[] Arguments
    {
        get;
        private set;
    }
#pragma warning restore CS8618
    public Client(string[] Args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Config.Setup();
        Arguments = Args;
        Start();
    }


    [STAThread]
    private void Start()
    {
        SplashScreen SS = new();
        SS.ShowInTaskbar = false;
        SS.Show();
        Application.Run(new MainForm(SS));
    }
}
