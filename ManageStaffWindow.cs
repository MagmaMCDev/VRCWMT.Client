using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagmaMc.BetterForms;
using MagmaMC.SharedLibrary;
using VRCWMT.Models;

namespace VRCWMT;
public partial class ManageStaffWindow : Form
{
    private readonly VRCW VRCWorld;
    private readonly Dictionary<string, Control[]> StaffControls = new();
    private readonly Dictionary<string, Control[]> ModControls = new();
    public ManageStaffWindow(VRCW World)
    {
        VRCWorld = World;
        InitializeComponent();
    }

    private void Form_Loaded(object sender, EventArgs e)
    {
        WorldName_Input.Text = VRCWorld.worldName;
        WorldDesc_Input.Text = VRCWorld.worldDescription;
        UsersPanel.AutoScroll = true;
        UsersPanel.VerticalScroll.Visible = true;
        UsersPanel.VerticalScroll.Enabled = true;
        betterRadioButton2.Checked = true;
        ColoredPictureBox AddButton = new ColoredPictureBox
        {
            Image = AppResources.Material_Symbols_Add,
            Location = new Point(313, 5),
            Name = "AddStaff",
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.Zoom,
            TabIndex = 0,
            TabStop = false,
            OverlayColor = Color.White,
            Cursor = Cursors.Hand
        };
        AddButton.MouseEnter += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.Green;
        AddButton.MouseLeave += (Control, _) => (Control as ColoredPictureBox)!.OverlayColor = Color.White;
        AddButton.MouseClick += (_, _) =>
        {
            InputData Username = InputBox.Show("Enter Github Username", "Manage World Staff", 1);
            if (Username.Canceled)
                return;
            if (string.IsNullOrWhiteSpace(Username.Value))
                return;
            if (Username.Value.Trim().ToLower() == VRCWorld.worldCreator.Trim().ToLower())
                return;
            if (StaffControls.ContainsKey(Username.Value.Trim()))
                return;

            if (betterRadioButton2.Checked)
                VRCWorld.AddStaff(Username.Value.Trim()).ConfigureAwait(false);
            else
                VRCWorld.AddMod(Username.Value.Trim()).ConfigureAwait(false);
            Thread.Sleep(50);
            UpdatePlayers();
        };

        Label WorldCreator_Username = new Label
        {
            Text = VRCWorld.worldCreator,
            Width = 200,
            Font = new Font("Segoe UI Variable Small", 11f, FontStyle.Regular),
            Location = new Point(10, 10),
            ForeColor = Color.Wheat,
        };

        StaffControls.Add(VRCWorld.worldCreator,
        [
            WorldCreator_Username
        ]);

        betterPanel1.Controls.Add(WorldCreator_Username);
        betterPanel1.Controls.Add(AddButton);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
    private void UpdatePlayers()
    {
        if (VRCWorld != null)
        {
            bool write = betterRadioButton2.Checked;
            string[]? Members;
            if (write)
                Members = VRCWorld.GetStaff();
            else
                Members = VRCWorld.GetMods();
            if (Members == null)
                return;

            ushort xIndex = 0;
            ushort controlHeight = 25;
            ushort margin = 10;
            ushort maxControlsPerColumn = 7;
            var panelHeight = maxControlsPerColumn * (controlHeight + margin);

            Invoke((MethodInvoker)delegate
            {
                foreach (Control item in UsersPanel.Controls)
                    item.Dispose();
                StaffControls.Clear();
                ModControls.Clear();
                UsersPanel.Controls.Clear();

                foreach (var item in Members)
                {
                    Label Username = new Label
                    {
                        Text = item,
                        Width = 200,
                        Font = new Font("Segoe UI Variable Small", 12f, FontStyle.Regular),
                        Location = new Point(0, margin + (xIndex * (controlHeight + margin))),
                        ForeColor = Color.Wheat,
                    };
                    ColoredPictureBox DeleteButton = new ColoredPictureBox
                    {
                        Image = AppResources.Material_symbols_Delete,
                        Location = new Point(304, margin + (xIndex * (controlHeight + margin))),
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
                        VRCWorld.RemoveStaff(item).ConfigureAwait(false);
                        if (write)
                            foreach (Control item in StaffControls[item])
                                item.Dispose();
                        else
                            foreach (Control item in ModControls[item])
                                item.Dispose();

                        Control[] controls = new Control[UsersPanel.Controls.Count];
                        UsersPanel.Controls.CopyTo(controls, 0);
                        foreach (Control item in controls)
                            if (item.Disposing || item.IsDisposed) UsersPanel.Controls.Remove(item);
                    };

                    if (write)
                        StaffControls.Add(item,
                        [
                            Username,
                            DeleteButton
                        ]);
                    else
                        ModControls.Add(item,
                        [
                            Username,
                            DeleteButton
                        ]);

                    UsersPanel.Controls.Add(Username);
                    UsersPanel.Controls.Add(DeleteButton);
                    xIndex++;
                }
            });
            UsersPanel.VerticalScroll.Maximum = panelHeight;
            if (Config.FastGC)
                GC.Collect();
        }

    }

    private void WorldDesc_Input_TextChanged(object sender, EventArgs e)
    {

    }

    private void SaveWorldDetails_Click(object sender, EventArgs e)
    {
        SaveWorldDetails.Enabled = false;
        var worldname = WorldName_Input.Text;
        var worlddesc = WorldDesc_Input.Text;
        new Thread(async () =>
        {
            if (VRCWorld.worldName != worldname)
            {
                VRCWorld.worldName = worldname;
                await VRCWorld.EditWorldName(VRCWorld.worldName);

            }
            if (VRCWorld.worldDescription != worlddesc)
            {
                VRCWorld.worldDescription = worlddesc;
                await VRCWorld.EditWorldDescription(VRCWorld.worldDescription);
            }
            Invoke((MethodInvoker)delegate
            {
                SaveWorldDetails.Enabled = true;
            });
        }).Start();
    }

    private void UpdateAccess(object sender, EventArgs e) => UpdatePlayers();
}
