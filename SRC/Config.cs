using MagmaMc.MagmaSimpleConfig;

namespace VRCWMT;

public static class Config
{
    private static string Dir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagmaMC");
    public const string ConfigFilename = "VRCWMT.db";

    public static string GithubAuth = "";
    public static string WorldID = "";
    public static bool AllowMultipleWindows = false;
    public static bool FastGC = true;
    public static ushort UpdateTime = 15;
    public static bool AutoCloseInstance = false;
    public static bool WarnBeforeClose = true;
    public static Version LastVersion = Client.Version;

    private static readonly SimpleConfig Conf = new(Path.Combine(Dir, ConfigFilename));
    public static void SetupConfig()
    {
        if (!Directory.Exists(Dir))
            Directory.CreateDirectory(Dir);
        if (!File.Exists(Path.Combine(Dir, ConfigFilename)))
            File.WriteAllBytes(Path.Combine(Dir, ConfigFilename), Array.Empty<byte>());
    }

    public static void WriteConfig()
    {
        Conf.SetValue("GithubOAuth", GithubAuth, "VRCWMT");
        Conf.SetValue("WorldID", WorldID, "VRCWMT");

        Conf.SetValue("AllowMultipleWindows", AllowMultipleWindows ? "true" : "false", "VRCWMT");
        Conf.SetValue("WarnBeforeClose", WarnBeforeClose ? "true" : "false", "VRCWMT");
        Conf.SetValue("AutoCloseInstance", AutoCloseInstance ? "true" : "false", "VRCWMT");
        Conf.SetValue("FastGC", FastGC ? "true" : "false", "VRCWMT");
        Conf.SetValue("UpdateTime", UpdateTime.ToString(), "VRCWMT");
        Conf.SetValue("Version", LastVersion.ToString(), "VRCWMT");
    }
    public static void ReadConfig()
    {
        GithubAuth = Conf.GetValue("GithubOAuth", "VRCWMT", GithubAuth);
        WorldID = Conf.GetValue("WorldID", "VRCWMT", WorldID);

        AllowMultipleWindows = Conf.GetValue("AllowMultipleWindows", "VRCWMT", AllowMultipleWindows ? "true" : "false") == "true" ? true : false;
        WarnBeforeClose = Conf.GetValue("WarnBeforeClose", "VRCWMT", WarnBeforeClose ? "true" : "false") == "true" ? true : false;
        AutoCloseInstance = Conf.GetValue("AutoCloseInstance", "VRCWMT", AutoCloseInstance ? "true" : "false") == "true" ? true : false;
        FastGC = Conf.GetValue("FastGC", "VRCWMT", FastGC ? "true" : "false") == "true" ? true : false;
        UpdateTime = ushort.Parse(Conf.GetValue("UpdateTime", "VRCWMT", UpdateTime.ToString()));
        LastVersion = new Version(Conf.GetValue("Version", "VRCWMT", LastVersion.ToString()));
    }

}
