namespace VRCWMT
{
    partial class MainWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            panel1 = new Panel();
            SettingsButton = new PictureBox();
            CloseInstanceButton = new PictureBox();
            ManageStaffButton = new PictureBox();
            PublishCommitButton = new PictureBox();
            ProfileIcon = new PictureBox();
            Username = new Label();
            ContactingServerGIF = new MagmaMc.BetterForms.GIFPlayer();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            Commits = new Label();
            label1 = new Label();
            GroupPanelBase = new MagmaMc.BetterForms.BetterPanel();
            GroupPanelInternal = new Panel();
            overlay_GroupControls = new MagmaMc.BetterForms.BetterPanel();
            PlayersPanelBase = new MagmaMc.BetterForms.BetterPanel();
            PlayersPanelInternal = new Panel();
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            pictureBox1 = new PictureBox();
            PlayerSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CloseInstanceButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ManageStaffButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PublishCommitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).BeginInit();
            betterPanel1.SuspendLayout();
            GroupPanelBase.SuspendLayout();
            GroupPanelInternal.SuspendLayout();
            PlayersPanelBase.SuspendLayout();
            betterPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 26, 27);
            panel1.Controls.Add(SettingsButton);
            panel1.Controls.Add(CloseInstanceButton);
            panel1.Controls.Add(ManageStaffButton);
            panel1.Controls.Add(PublishCommitButton);
            panel1.Controls.Add(ProfileIcon);
            panel1.Controls.Add(Username);
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 36);
            panel1.TabIndex = 0;
            // 
            // SettingsButton
            // 
            SettingsButton.Image = AppResources.Material_symbols_Settings;
            SettingsButton.Location = new Point(703, -1);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(41, 37);
            SettingsButton.SizeMode = PictureBoxSizeMode.Zoom;
            SettingsButton.TabIndex = 6;
            SettingsButton.TabStop = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // CloseInstanceButton
            // 
            CloseInstanceButton.Image = AppResources.Material_symbols_Exit;
            CloseInstanceButton.Location = new Point(0, 1);
            CloseInstanceButton.Name = "CloseInstanceButton";
            CloseInstanceButton.Size = new Size(41, 36);
            CloseInstanceButton.SizeMode = PictureBoxSizeMode.Zoom;
            CloseInstanceButton.TabIndex = 5;
            CloseInstanceButton.TabStop = false;
            CloseInstanceButton.Click += CloseInstance_Click;
            // 
            // ManageStaffButton
            // 
            ManageStaffButton.Image = AppResources.Material_Symbols_ManageAccount;
            ManageStaffButton.Location = new Point(656, -1);
            ManageStaffButton.Name = "ManageStaffButton";
            ManageStaffButton.Size = new Size(41, 37);
            ManageStaffButton.SizeMode = PictureBoxSizeMode.Zoom;
            ManageStaffButton.TabIndex = 4;
            ManageStaffButton.TabStop = false;
            ManageStaffButton.Click += ManageStaff_Click;
            // 
            // PublishCommitButton
            // 
            PublishCommitButton.Image = AppResources.Material_symbols_Publish;
            PublishCommitButton.Location = new Point(750, 0);
            PublishCommitButton.Name = "PublishCommitButton";
            PublishCommitButton.Size = new Size(36, 36);
            PublishCommitButton.SizeMode = PictureBoxSizeMode.Zoom;
            PublishCommitButton.TabIndex = 0;
            PublishCommitButton.TabStop = false;
            PublishCommitButton.Click += PublishCommit_Click;
            // 
            // ProfileIcon
            // 
            ProfileIcon.Location = new Point(40, 0);
            ProfileIcon.Name = "ProfileIcon";
            ProfileIcon.Size = new Size(39, 39);
            ProfileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            ProfileIcon.TabIndex = 3;
            ProfileIcon.TabStop = false;
            // 
            // Username
            // 
            Username.Font = new Font("Segoe UI Variable Small", 9F);
            Username.ForeColor = SystemColors.WindowText;
            Username.Location = new Point(78, 0);
            Username.Name = "Username";
            Username.Size = new Size(189, 39);
            Username.TabIndex = 2;
            Username.Text = "Username";
            Username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContactingServerGIF
            // 
            ContactingServerGIF.BackColor = Color.FromArgb(40, 41, 42);
            ContactingServerGIF.Image = AppResources.Contacting;
            ContactingServerGIF.Location = new Point(9, 4);
            ContactingServerGIF.Name = "ContactingServerGIF";
            ContactingServerGIF.Size = new Size(36, 38);
            ContactingServerGIF.SizeMode = PictureBoxSizeMode.Zoom;
            ContactingServerGIF.TabIndex = 0;
            ContactingServerGIF.TabStop = false;
            // 
            // betterPanel1
            // 
            betterPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betterPanel1.BackColor = Color.FromArgb(25, 26, 27);
            betterPanel1.BorderColor = Color.DeepSkyBlue;
            betterPanel1.BorderCurve = 10F;
            betterPanel1.BorderSize = 4F;
            betterPanel1.Controls.Add(ContactingServerGIF);
            betterPanel1.Controls.Add(Commits);
            betterPanel1.Controls.Add(label1);
            betterPanel1.Location = new Point(445, 42);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(353, 174);
            betterPanel1.TabIndex = 1;
            // 
            // Commits
            // 
            Commits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Commits.BackColor = Color.FromArgb(25, 26, 27);
            Commits.Font = new Font("Segoe UI Variable Small", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Commits.ForeColor = Color.WhiteSmoke;
            Commits.Location = new Point(16, 41);
            Commits.Name = "Commits";
            Commits.Size = new Size(334, 121);
            Commits.TabIndex = 1;
            Commits.Text = "Loading...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Small", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(117, 5);
            label1.Name = "label1";
            label1.Size = new Size(130, 36);
            label1.TabIndex = 0;
            label1.Text = "Commits";
            // 
            // GroupPanelBase
            // 
            GroupPanelBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GroupPanelBase.BackColor = Color.FromArgb(25, 26, 27);
            GroupPanelBase.BorderColor = Color.DeepSkyBlue;
            GroupPanelBase.BorderCurve = 10F;
            GroupPanelBase.BorderSize = 4F;
            GroupPanelBase.Controls.Add(GroupPanelInternal);
            GroupPanelBase.Location = new Point(446, 222);
            GroupPanelBase.Name = "GroupPanelBase";
            GroupPanelBase.Size = new Size(352, 221);
            GroupPanelBase.TabIndex = 2;
            // 
            // GroupPanelInternal
            // 
            GroupPanelInternal.BackColor = Color.FromArgb(25, 26, 27);
            GroupPanelInternal.Controls.Add(overlay_GroupControls);
            GroupPanelInternal.Location = new Point(6, 7);
            GroupPanelInternal.Name = "GroupPanelInternal";
            GroupPanelInternal.Size = new Size(341, 209);
            GroupPanelInternal.TabIndex = 0;
            GroupPanelInternal.Scroll += GroupPanel_Scroll;
            GroupPanelInternal.MouseWheel += GroupPanel_MouseWheel;
            // 
            // overlay_GroupControls
            // 
            overlay_GroupControls.BackColor = Color.FromArgb(35, 36, 37);
            overlay_GroupControls.BorderColor = Color.FromArgb(25, 26, 27);
            overlay_GroupControls.BorderCurve = 12F;
            overlay_GroupControls.BorderSize = 0F;
            overlay_GroupControls.Location = new Point(247, 3);
            overlay_GroupControls.Name = "overlay_GroupControls";
            overlay_GroupControls.Size = new Size(77, 25);
            overlay_GroupControls.TabIndex = 1;
            // 
            // PlayersPanelBase
            // 
            PlayersPanelBase.BackColor = Color.FromArgb(25, 26, 27);
            PlayersPanelBase.BorderColor = Color.DeepSkyBlue;
            PlayersPanelBase.BorderCurve = 10F;
            PlayersPanelBase.BorderSize = 4F;
            PlayersPanelBase.Controls.Add(PlayersPanelInternal);
            PlayersPanelBase.Controls.Add(betterPanel2);
            PlayersPanelBase.Location = new Point(12, 41);
            PlayersPanelBase.Name = "PlayersPanelBase";
            PlayersPanelBase.Size = new Size(427, 402);
            PlayersPanelBase.TabIndex = 3;
            // 
            // PlayersPanelInternal
            // 
            PlayersPanelInternal.Location = new Point(6, 36);
            PlayersPanelInternal.Name = "PlayersPanelInternal";
            PlayersPanelInternal.Size = new Size(416, 361);
            PlayersPanelInternal.TabIndex = 0;
            PlayersPanelInternal.Scroll += PlayersPanel_Scroll;
            // 
            // betterPanel2
            // 
            betterPanel2.BackColor = Color.FromArgb(35, 36, 37);
            betterPanel2.BorderColor = Color.FromArgb(25, 26, 27);
            betterPanel2.BorderCurve = 15F;
            betterPanel2.BorderSize = 0F;
            betterPanel2.Controls.Add(pictureBox1);
            betterPanel2.Controls.Add(PlayerSearch);
            betterPanel2.ForeColor = Color.WhiteSmoke;
            betterPanel2.Location = new Point(5, 7);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(350, 27);
            betterPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = AppResources.Material_symbols_Search;
            pictureBox1.Location = new Point(6, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // PlayerSearch
            // 
            PlayerSearch.BackColor = Color.FromArgb(35, 36, 37);
            PlayerSearch.BorderStyle = BorderStyle.None;
            PlayerSearch.Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerSearch.Location = new Point(38, 1);
            PlayerSearch.MaxLength = 35;
            PlayerSearch.Name = "PlayerSearch";
            PlayerSearch.Size = new Size(297, 22);
            PlayerSearch.TabIndex = 1;
            PlayerSearch.TextChanged += PlayerSearch_TextChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 41, 42);
            ClientSize = new Size(800, 455);
            Controls.Add(PlayersPanelBase);
            Controls.Add(GroupPanelBase);
            Controls.Add(betterPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InstanceName";
            TransparencyKey = Color.Transparent;
            FormClosing += Window_Closing;
            Load += Form_Load;
            Shown += Form_Shown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SettingsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)CloseInstanceButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ManageStaffButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PublishCommitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).EndInit();
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            GroupPanelBase.ResumeLayout(false);
            GroupPanelInternal.ResumeLayout(false);
            PlayersPanelBase.ResumeLayout(false);
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Username;
        private PictureBox ProfileIcon;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private Label Commits;
        private Label label1;
        private MagmaMc.BetterForms.BetterPanel GroupPanelBase;
        private MagmaMc.BetterForms.GIFPlayer ContactingServerGIF;
        private MagmaMc.BetterForms.BetterPanel PlayersPanelBase;
        private Panel GroupPanelInternal;
        private Panel PlayersPanelInternal;
        private PictureBox PublishCommitButton;
        private PictureBox ManageStaffButton;
        private PictureBox CloseInstanceButton;
        private PictureBox SettingsButton;
        private TextBox PlayerSearch;
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private PictureBox pictureBox1;
        private MagmaMc.BetterForms.BetterPanel overlay_GroupControls;
    }
}