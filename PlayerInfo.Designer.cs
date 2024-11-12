namespace VRCWMT
{
    partial class PlayerInfo
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInfo));
            PlayerName_Control = new MagmaMc.BetterForms.BetterPanel();
            Playername = new Label();
            Timeadded = new Label();
            PermissionMessage = new Label();
            SmallIcon = new PictureBox();
            BannerImage = new PictureBox();
            PlayerName_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SmallIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BannerImage).BeginInit();
            SuspendLayout();
            // 
            // PlayerName_Control
            // 
            PlayerName_Control.BackColor = Color.FromArgb(5, 25, 29);
            PlayerName_Control.BorderColor = Color.FromArgb(6, 75, 92);
            PlayerName_Control.BorderCurve = 7F;
            PlayerName_Control.BorderSize = 3F;
            PlayerName_Control.Controls.Add(Playername);
            PlayerName_Control.ForeColor = Color.FromArgb(6, 75, 92);
            PlayerName_Control.Location = new Point(8, 10);
            PlayerName_Control.Name = "PlayerName_Control";
            PlayerName_Control.Size = new Size(326, 38);
            PlayerName_Control.TabIndex = 2;
            // 
            // Playername
            // 
            Playername.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Playername.ForeColor = Color.FromArgb(79, 227, 249);
            Playername.Location = new Point(8, 5);
            Playername.Name = "Playername";
            Playername.Size = new Size(302, 28);
            Playername.TabIndex = 1;
            Playername.Click += Playername_Click;
            // 
            // Timeadded
            // 
            Timeadded.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Timeadded.Font = new Font("Segoe UI Variable Small", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Timeadded.ForeColor = Color.WhiteSmoke;
            Timeadded.Location = new Point(317, 85);
            Timeadded.Name = "Timeadded";
            Timeadded.Size = new Size(115, 16);
            Timeadded.TabIndex = 4;
            Timeadded.TextAlign = ContentAlignment.TopRight;
            // 
            // PermissionMessage
            // 
            PermissionMessage.Font = new Font("Segoe UI Variable Small", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PermissionMessage.ForeColor = Color.Silver;
            PermissionMessage.Location = new Point(8, 52);
            PermissionMessage.Name = "PermissionMessage";
            PermissionMessage.Size = new Size(326, 43);
            PermissionMessage.TabIndex = 1;
            // 
            // SmallIcon
            // 
            SmallIcon.BackgroundImageLayout = ImageLayout.None;
            SmallIcon.Image = AppResources.Exampleimage;
            SmallIcon.Location = new Point(340, 7);
            SmallIcon.Name = "SmallIcon";
            SmallIcon.Size = new Size(90, 82);
            SmallIcon.SizeMode = PictureBoxSizeMode.Zoom;
            SmallIcon.TabIndex = 5;
            SmallIcon.TabStop = false;
            // 
            // BannerImage
            // 
            BannerImage.Image = AppResources.Exampleimage;
            BannerImage.Location = new Point(8, 100);
            BannerImage.Name = "BannerImage";
            BannerImage.Size = new Size(422, 241);
            BannerImage.SizeMode = PictureBoxSizeMode.Zoom;
            BannerImage.TabIndex = 6;
            BannerImage.TabStop = false;
            // 
            // PlayerInfo
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(435, 344);
            Controls.Add(BannerImage);
            Controls.Add(SmallIcon);
            Controls.Add(Timeadded);
            Controls.Add(PlayerName_Control);
            Controls.Add(PermissionMessage);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlayerInfo";
            Text = "Viewing Player: ";
            FormClosed += WindowClosed;
            Load += PlayerInfo_Load;
            PlayerName_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SmallIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)BannerImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private MagmaMc.BetterForms.BetterPanel PlayerName_Control;
        private Label Playername;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private Label Timeadded;
        private Label PermissionMessage;
        private PictureBox SmallIcon;
        private PictureBox BannerImage;
    }
}