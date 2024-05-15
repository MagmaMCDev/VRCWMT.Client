using System.Text.RegularExpressions;

namespace VRCWMT;

public partial class AddPlayer : Form
{
    public bool Canceled = true;
    public string playerID = "";
    public string message = "";
    public AddPlayer()
    {
        InitializeComponent();
    }
    private void AddPlayer_Click(object sender, EventArgs e)
    {
        if (!Regex.Match(PlayerID.Text.ToLower(), @"^(usr_)?[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}$").Success)
        {
            MessageBox.Show("PlayerID Invalid", "VRCWMT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrWhiteSpace(Message.Text))
        {
            MessageBox.Show("Commit Message Is Required", "VRCWMT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        playerID = PlayerID.Text.ToLower().StartsWith("usr_") ? PlayerID.Text.ToLower() : "usr_" + PlayerID.Text.ToLower();
        message = Message.Text;
        Canceled = false;
        Close();
    }

    private void AddPlayer_Load(object sender, EventArgs e)
    {

    }
}
