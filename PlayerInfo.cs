using System.Diagnostics;
using System.Text.RegularExpressions;
using MagmaMc.UAS;
using MagmaMC.SharedLibrary;
using OpenVRChatAPI.Models;
using VRCWMT.Models;

namespace VRCWMT;

public partial class PlayerInfo : Form
{
    private readonly VRCW world;
    private readonly string group;
    private readonly PlayerItem player;

    public PlayerInfo(VRCW World, string Group, PlayerItem Player)
    {
        world = World;
        group = Group;
        player = Player;
        InitializeComponent();
    }

    private void PlayerInfo_Load(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.UserAgent.Clear();
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(Client.User_Agent);
        Playername.Text = player.displayName;
        Text += player.displayName;
        Timeadded.Text = $"{player.timeAdded.ToLocalTime():d/M/yy h:mm tt}";
        PermissionMessage.Text = player.userAdded + ": " + player.message;
        Task.Run(() =>
        {
            VRCUser user = user = world.GetVRCUser(player.playerID)!;
            Bitmap? Icon = null;
            Bitmap? Banner = null;
            if (!string.IsNullOrEmpty(user.userIcon))
                Icon = DownloadImage(ref httpClient, user.userIcon);

            SmallIcon.Invoke((MethodInvoker)delegate
            {
                SmallIcon.Image = Icon;
            });

            if (!string.IsNullOrEmpty(user.profilePicOverride))
                Banner = DownloadImage(ref httpClient, user.profilePicOverride);
            else
                Banner = DownloadImage(ref httpClient, user.currentAvatarThumbnailImageUrl);

            if (Banner != null)
                SmallIcon.Invoke((MethodInvoker)delegate
                {
                    BannerImage.Image = Banner;
                });
            httpClient.Dispose();
        });
    }

    private void WindowClosed(object sender, FormClosedEventArgs e)
    {
        Dispose();
    }
    private Bitmap? DownloadImage(ref HttpClient httpClient, string url)
    {
        using var response = httpClient.GetAsync(url).GetResult();
        if (!response.IsSuccessStatusCode)
            return null;

        var bytes = response.Content.ReadAsByteArrayAsync().GetResult();
        using var stream = new MemoryStream(bytes);
        return new Bitmap(stream);
    }

    private void Playername_Click(object sender, EventArgs e)
    {
        ProcessStartInfo PSI = new($"https://vrchat.com/home/user/{player.playerID}");
        PSI.UseShellExecute = true;
        Process.Start(PSI);
    }

    private void Timeadded_Click(object sender, EventArgs e)
    {

    }
}
