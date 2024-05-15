using VRCWMT;

namespace VRCWMT
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            pictureBox1 = new PictureBox();
            Status = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Loading";
            pictureBox1.AccessibleName = "Loading";
            pictureBox1.AccessibleRole = AccessibleRole.Window;
            pictureBox1.Image = AppResources.VRChatBanner;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(502, 179);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseDown += Drag;
            // 
            // Status
            // 
            Status.BackColor = Color.Transparent;
            Status.FlatStyle = FlatStyle.Flat;
            Status.ForeColor = Color.White;
            Status.Image = AppResources.VRChatBanner;
            Status.ImageAlign = ContentAlignment.BottomLeft;
            Status.Location = new Point(-3, 148);
            Status.Name = "Status";
            Status.Size = new Size(222, 25);
            Status.TabIndex = 1;
            Status.Text = "Status";
            Status.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Control;
            pictureBox2.BackgroundImage = AppResources.VRChatBanner;
            pictureBox2.Image = AppResources.Icon_New;
            pictureBox2.Location = new Point(-1, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(888, 56);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.ForeColor = Color.White;
            label1.Image = AppResources.VRChatBanner;
            label1.ImageAlign = ContentAlignment.BottomLeft;
            label1.Location = new Point(-3, 148);
            label1.Name = "label1";
            label1.Size = new Size(503, 25);
            label1.TabIndex = 3;
            label1.Text = "Version: ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 176);
            Controls.Add(pictureBox2);
            Controls.Add(Status);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            TopMost = true;
            Load += Loaded;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        public Label Status;
        private PictureBox pictureBox2;
        public Label label1;
    }
}