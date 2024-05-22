using MagmaMC.SharedLibrary;
using System.Text.RegularExpressions;
using VRCWMT.Models;

namespace VRCWMT;

public partial class WelcomeWizard : Form
{
    public bool Canceled = true;
    public WelcomeWizard()
    {
        InitializeComponent();
    }

    private void WelcomeWizard_Load(object sender, EventArgs e)
    {

    }


    private void Click_CreateWorld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Hide();
        using AddWorld World = new AddWorld();
        World.ShowDialog();
    }
    private void ContinueButton_Click(object sender, EventArgs e)
    {
        WarningText.Text = "";
        ContinueButton.Enabled = false;
        if (string.IsNullOrWhiteSpace(WorldID_Input.Text))
        {
            WarningText.Text = "Invalid WorldID";
            ContinueButton.Enabled = true;
            return;
        }
        new Thread(() =>
        {
            if (!Regex.Match(WorldID_Input.Text, @"^WRD_[0-9A-Z]{32}$").Success || API.GetWorld(WorldID_Input.Text) == null)
            {
                Invoke((MethodInvoker)delegate
                {
                    WarningText.Text = "Invalid WorldID";
                    ContinueButton.Enabled = true;
                });
                return;
            }
            GithubUser githubUser = Github.GetUserAsync(Config.GithubAuth).GetResult();
            SiteUser? User = API.GetUser(WorldID_Input.Text, githubUser.login);
            if (User == null)
            {
                Invoke((MethodInvoker)delegate
                {
                    WarningText.Text = "Invalid User";
                    ContinueButton.Enabled = true;
                });
                return;
            }
            if (!User.siteAdmin && !User.worldCreator && !User.siteOwner && !User.read)
            {
                Invoke((MethodInvoker)delegate
                {
                    WarningText.Text = "Unauthorized";
                    ContinueButton.Enabled = true;
                });
                return;
            }
            Invoke((MethodInvoker)delegate
            {
                Config.WorldID = WorldID_Input.Text;
                Config.WriteConfig();
                Canceled = false;
                Close();
            });
        }).Start();
    }
    private void WelcomeWizard_FormClosing(object sender, FormClosingEventArgs e)
    {
    }
}
