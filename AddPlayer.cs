using MagmaMc.BetterForms;
using MagmaMc.JEF;
using MagmaMc.UAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRCWMT;

public partial class AddPlayer : Form
{
    public AddPlayer()
    {
        InitializeComponent();
    }

    private void CreateWorld_Load(object sender, EventArgs e)
    {

    }

    private void CreateButton_Click(object sender, EventArgs e)
    {
        if (WorldName_Input.Text.Length < 5)
        {
            MessageBox.Show("WorldName Invalid", "VRCWEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Application.Restart();
        Environment.Exit(0);
    }

    private void Description_Input_TextChanged(object sender, EventArgs e)
    {

    }
}
