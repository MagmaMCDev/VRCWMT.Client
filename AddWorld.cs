using KPreisser.UI;
using MagmaMc.BetterForms;
using MagmaMc.JEF;
using MagmaMc.UAS;
using MagmaMC.SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDialog = KPreisser.UI.TaskDialog;

namespace VRCWMT;

public partial class AddWorld : Form
{
    public AddWorld()
    {
        InitializeComponent();
    }

    private void CreateWorld_Load(object sender, EventArgs e)
    {

    }

    private void CreateButton_Click(object sender, EventArgs e)
    {
        if (WorldName_Input.Text.Length < 3)
        {
            MessageBox.Show("World Name Invalid Length", "VRCWEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        gifPlayer1.Visible = true;
        CreateWorldButton.Enabled = false;
        WarningText.Text = "";
        Task<string> addworld = API.AddWorldAsync(WorldName_Input.Text, Description_Input.Text, GithubRepo_Input.Text, File.ReadAllBytes(ImagePath.Text), Path.GetExtension(ImagePath.Text));
        new Thread(() =>
        {
            string Success = addworld.GetResult();
            Invoke((MethodInvoker)delegate
            {
                gifPlayer1.Visible = false;
                CreateWorldButton.Enabled = true;
                if (string.IsNullOrWhiteSpace(Success))
                    WarningText.Text = "Failed";
                else
                {
                    Clipboard.SetText(Success);
                    TaskDialog.Show(text: "World Created Successfully, Copied WorldID To Clip Board",
                        title: "VRCWMT",
                        buttons: TaskDialogButtons.OK,
                        icon: TaskDialogStandardIcon.Information);
                    Close();
                    Config.WorldID = Success;
                    Config.WriteConfig();
                    Application.Restart();
                    Dispose();
                    return;
                }
            });
        }).Start();

    }

    private void Description_Input_TextChanged(object sender, EventArgs e)
    {

    }
    private DateTime? lastClickTime = null;

    private void SelectImage(object sender, MouseEventArgs e)
    {
        if (lastClickTime != null && (DateTime.Now - lastClickTime.Value).TotalMilliseconds < 250)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpeg; *.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath.Text = openFileDialog.FileName;
            }
        }

        lastClickTime = DateTime.Now;
    }


    private void BannerImagePath_TextChanged(object sender, EventArgs e)
    {

    }
}
