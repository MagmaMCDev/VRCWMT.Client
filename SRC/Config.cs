using MagmaMc.MagmaSimpleConfig;

namespace VRCWMT;

public static class Config
{
    public static string Dir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagmaMC");
    public const string Filename = "VRCWMT.db";

    public static string GithubAuth = "";
    public static string WorldID = "";
    private static readonly SimpleConfig Conf = new(Path.Combine(Dir, Filename));
    public static void Setup()
    {
        if (Directory.Exists(Dir))
            Directory.CreateDirectory(Dir);
        if (!File.Exists(Path.Combine(Dir, Filename)))
            File.WriteAllBytes(Path.Combine(Dir, Filename), Array.Empty<byte>());
    }

    public static void Write()
    {
        Conf.SetValue("GithubOAuth", GithubAuth, "VRCWMT");
        Conf.SetValue("WorldID", WorldID, "VRCWMT");
    }
    public static void Read()
    {
        GithubAuth = Conf.GetValue("GithubOAuth", "VRCWMT", GithubAuth);
        WorldID = Conf.GetValue("WorldID", "VRCWMT", WorldID);
    }

}
