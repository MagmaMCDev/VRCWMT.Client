namespace VRCWMT
{
    partial class MainForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
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
            PlayersPanelBase = new MagmaMc.BetterForms.BetterPanel();
            PlayersPanelInternal = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CloseInstanceButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ManageStaffButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PublishCommitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).BeginInit();
            betterPanel1.SuspendLayout();
            GroupPanelBase.SuspendLayout();
            PlayersPanelBase.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 26, 27);
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
            ManageStaffButton.Location = new Point(703, 0);
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
            ContactingServerGIF.Image = AppResources.Contacting_Alt1;
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
            Commits.Font = new Font("Segoe UI Variable Small", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Commits.ForeColor = SystemColors.WindowText;
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
            GroupPanelInternal.Location = new Point(12, 34);
            GroupPanelInternal.Name = "GroupPanelInternal";
            GroupPanelInternal.Size = new Size(332, 184);
            GroupPanelInternal.TabIndex = 0;
            // 
            // PLayersPanelBase
            // 
            PlayersPanelBase.BorderColor = Color.DeepSkyBlue;
            PlayersPanelBase.BorderCurve = 10F;
            PlayersPanelBase.BorderSize = 4F;
            PlayersPanelBase.Controls.Add(PlayersPanelInternal);
            PlayersPanelBase.Location = new Point(12, 41);
            PlayersPanelBase.Name = "PLayersPanelBase";
            PlayersPanelBase.Size = new Size(427, 402);
            PlayersPanelBase.TabIndex = 3;
            // 
            // PlayersPanelInternal
            // 
            PlayersPanelInternal.Location = new Point(11, 35);
            PlayersPanelInternal.Name = "PlayersPanelInternal";
            PlayersPanelInternal.Size = new Size(410, 361);
            PlayersPanelInternal.TabIndex = 0;
            // 
            // MainForm
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
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InstanceName";
            TransparencyKey = Color.Transparent;
            FormClosing += Window_Closing;
            Load += Form_Load;
            Shown += Form_Shown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CloseInstanceButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ManageStaffButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PublishCommitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).EndInit();
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            GroupPanelBase.ResumeLayout(false);
            PlayersPanelBase.ResumeLayout(false);
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
    }
}