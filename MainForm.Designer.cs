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
            ContactingServerGIF = new MagmaMc.BetterForms.GIFPlayer();
            CloseInstanceButton = new MagmaMc.BetterForms.BetterButton();
            ProfileIcon = new PictureBox();
            PublishCommitButton = new MagmaMc.BetterForms.BetterButton();
            Username = new Label();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            Commits = new Label();
            label1 = new Label();
            GroupPanel = new MagmaMc.BetterForms.BetterPanel();
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            GroupPanelInternal = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).BeginInit();
            betterPanel1.SuspendLayout();
            GroupPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 26, 27);
            panel1.Controls.Add(ContactingServerGIF);
            panel1.Controls.Add(CloseInstanceButton);
            panel1.Controls.Add(ProfileIcon);
            panel1.Controls.Add(PublishCommitButton);
            panel1.Controls.Add(Username);
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 39);
            panel1.TabIndex = 0;
            // 
            // ContactingServerGIF
            // 
            ContactingServerGIF.BackColor = Color.Transparent;
            ContactingServerGIF.Image = AppResources.Contacting;
            ContactingServerGIF.Location = new Point(482, 0);
            ContactingServerGIF.Name = "ContactingServerGIF";
            ContactingServerGIF.Size = new Size(40, 39);
            ContactingServerGIF.SizeMode = PictureBoxSizeMode.Zoom;
            ContactingServerGIF.TabIndex = 0;
            ContactingServerGIF.TabStop = false;
            // 
            // CloseInstanceButton
            // 
            CloseInstanceButton.BackColor = Color.Black;
            CloseInstanceButton.BackgroundColor = Color.Black;
            CloseInstanceButton.BorderColor = Color.DeepSkyBlue;
            CloseInstanceButton.BorderRadius = 10;
            CloseInstanceButton.BorderSize = 4;
            CloseInstanceButton.FlatAppearance.BorderSize = 0;
            CloseInstanceButton.FlatStyle = FlatStyle.Flat;
            CloseInstanceButton.Font = new Font("Segoe UI Variable Small", 9F);
            CloseInstanceButton.ForeColor = SystemColors.WindowText;
            CloseInstanceButton.Location = new Point(519, 3);
            CloseInstanceButton.Name = "CloseInstanceButton";
            CloseInstanceButton.Size = new Size(121, 33);
            CloseInstanceButton.TabIndex = 4;
            CloseInstanceButton.Text = "Close Instance";
            CloseInstanceButton.TextColor = SystemColors.WindowText;
            CloseInstanceButton.UseVisualStyleBackColor = false;
            CloseInstanceButton.Value = null;
            CloseInstanceButton.Click += betterButton1_Click;
            // 
            // ProfileIcon
            // 
            ProfileIcon.Location = new Point(-1, 0);
            ProfileIcon.Name = "ProfileIcon";
            ProfileIcon.Size = new Size(39, 39);
            ProfileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            ProfileIcon.TabIndex = 3;
            ProfileIcon.TabStop = false;
            // 
            // PublishCommitButton
            // 
            PublishCommitButton.BackColor = Color.Black;
            PublishCommitButton.BackgroundColor = Color.Black;
            PublishCommitButton.BorderColor = Color.DeepSkyBlue;
            PublishCommitButton.BorderRadius = 10;
            PublishCommitButton.BorderSize = 4;
            PublishCommitButton.FlatAppearance.BorderSize = 0;
            PublishCommitButton.FlatStyle = FlatStyle.Flat;
            PublishCommitButton.Font = new Font("Segoe UI Variable Small", 9F);
            PublishCommitButton.ForeColor = SystemColors.WindowText;
            PublishCommitButton.Location = new Point(646, 3);
            PublishCommitButton.Name = "PublishCommitButton";
            PublishCommitButton.Size = new Size(152, 33);
            PublishCommitButton.TabIndex = 1;
            PublishCommitButton.Text = "Publish Commit";
            PublishCommitButton.TextColor = SystemColors.WindowText;
            PublishCommitButton.UseVisualStyleBackColor = false;
            PublishCommitButton.Value = null;
            PublishCommitButton.Click += PublishCommit_Click;
            // 
            // Username
            // 
            Username.Font = new Font("Segoe UI Variable Small", 9F);
            Username.ForeColor = SystemColors.WindowText;
            Username.Location = new Point(37, 0);
            Username.Name = "Username";
            Username.Size = new Size(278, 39);
            Username.TabIndex = 2;
            Username.Text = "Username";
            Username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // betterPanel1
            // 
            betterPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betterPanel1.BorderColor = Color.DeepSkyBlue;
            betterPanel1.BorderCurve = 10F;
            betterPanel1.BorderSize = 4F;
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
            // GroupPanel
            // 
            GroupPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GroupPanel.BorderColor = Color.DeepSkyBlue;
            GroupPanel.BorderCurve = 10F;
            GroupPanel.BorderSize = 4F;
            GroupPanel.Controls.Add(GroupPanelInternal);
            GroupPanel.Location = new Point(446, 222);
            GroupPanel.Name = "GroupPanel";
            GroupPanel.Size = new Size(352, 221);
            GroupPanel.TabIndex = 2;
            // 
            // betterPanel2
            // 
            betterPanel2.BorderColor = Color.DeepSkyBlue;
            betterPanel2.BorderCurve = 10F;
            betterPanel2.BorderSize = 4F;
            betterPanel2.Location = new Point(12, 41);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(427, 402);
            betterPanel2.TabIndex = 3;
            // 
            // GroupPanelInternal
            // 
            GroupPanelInternal.Location = new Point(12, 10);
            GroupPanelInternal.Name = "GroupPanelInternal";
            GroupPanelInternal.Size = new Size(332, 205);
            GroupPanelInternal.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 41, 42);
            ClientSize = new Size(800, 455);
            Controls.Add(betterPanel2);
            Controls.Add(GroupPanel);
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
            ((System.ComponentModel.ISupportInitialize)ContactingServerGIF).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfileIcon).EndInit();
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            GroupPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Username;
        private MagmaMc.BetterForms.BetterButton PublishCommitButton;
        private PictureBox ProfileIcon;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private Label Commits;
        private Label label1;
        private MagmaMc.BetterForms.BetterPanel GroupPanel;
        private MagmaMc.BetterForms.BetterButton CloseInstanceButton;
        private MagmaMc.BetterForms.GIFPlayer ContactingServerGIF;
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private Panel GroupPanelInternal;
    }
}