using MagmaMc.BetterForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRCWMT
{
    public partial class SplashScreen: Form
    {
        public FormRounder Rounder;
        public SplashScreen()
        {
            InitializeComponent();
            Rounder = new FormRounder(this);
        }

        private void Drag(object sender, MouseEventArgs e)
        {
            Rounder.Object_Draggable();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
