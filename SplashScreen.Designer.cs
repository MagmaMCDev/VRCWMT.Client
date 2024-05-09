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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            pictureBox1.Size = new Size(498, 179);
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
            Status.Location = new Point(-2, 148);
            Status.Name = "Status";
            Status.Size = new Size(222, 25);
            Status.TabIndex = 1;
            Status.Text = "Status";
            Status.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 176);
            Controls.Add(Status);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        public Label Status;
    }
}