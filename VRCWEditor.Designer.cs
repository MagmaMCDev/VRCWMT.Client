namespace VRCWMT
{
    partial class VRCWEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VRCWEditor));
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            DevToken_Input = new TextBox();
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            WorldName_Input = new TextBox();
            Click_DevToken = new LinkLabel();
            CreateConfig = new MagmaMc.BetterForms.BetterButton();
            betterPanel1.SuspendLayout();
            betterPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // betterPanel1
            // 
            betterPanel1.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel1.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel1.BorderCurve = 7F;
            betterPanel1.BorderSize = 3F;
            betterPanel1.Controls.Add(DevToken_Input);
            betterPanel1.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel1.Location = new Point(106, 83);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(284, 42);
            betterPanel1.TabIndex = 1;
            // 
            // DevToken_Input
            // 
            DevToken_Input.AccessibleRole = AccessibleRole.Text;
            DevToken_Input.BackColor = Color.FromArgb(5, 25, 29);
            DevToken_Input.BorderStyle = BorderStyle.None;
            DevToken_Input.Font = new Font("Segoe UI", 12F);
            DevToken_Input.ForeColor = Color.FromArgb(79, 227, 249);
            DevToken_Input.Location = new Point(9, 10);
            DevToken_Input.MaxLength = 120;
            DevToken_Input.Name = "DevToken_Input";
            DevToken_Input.PlaceholderText = "DevToken";
            DevToken_Input.Size = new Size(268, 22);
            DevToken_Input.TabIndex = 0;
            DevToken_Input.UseSystemPasswordChar = true;
            DevToken_Input.TextChanged += textBox1_TextChanged;
            // 
            // betterPanel2
            // 
            betterPanel2.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel2.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel2.BorderCurve = 7F;
            betterPanel2.BorderSize = 3F;
            betterPanel2.Controls.Add(WorldName_Input);
            betterPanel2.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel2.Location = new Point(106, 35);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(284, 42);
            betterPanel2.TabIndex = 2;
            // 
            // WorldName_Input
            // 
            WorldName_Input.AccessibleRole = AccessibleRole.Text;
            WorldName_Input.BackColor = Color.FromArgb(5, 25, 29);
            WorldName_Input.BorderStyle = BorderStyle.None;
            WorldName_Input.CharacterCasing = CharacterCasing.Upper;
            WorldName_Input.Font = new Font("Segoe UI", 12F);
            WorldName_Input.ForeColor = Color.FromArgb(79, 227, 249);
            WorldName_Input.Location = new Point(10, 11);
            WorldName_Input.MaxLength = 120;
            WorldName_Input.Name = "WorldName_Input";
            WorldName_Input.PlaceholderText = "WorldName";
            WorldName_Input.Size = new Size(268, 22);
            WorldName_Input.TabIndex = 0;
            // 
            // Click_DevToken
            // 
            Click_DevToken.AccessibleRole = AccessibleRole.StaticText;
            Click_DevToken.AutoSize = true;
            Click_DevToken.LinkBehavior = LinkBehavior.NeverUnderline;
            Click_DevToken.LinkColor = Color.FromArgb(14, 155, 177);
            Click_DevToken.Location = new Point(196, 167);
            Click_DevToken.Name = "Click_DevToken";
            Click_DevToken.Size = new Size(105, 15);
            Click_DevToken.TabIndex = 3;
            Click_DevToken.TabStop = true;
            Click_DevToken.Text = "Create a DevToken";
            Click_DevToken.TextAlign = ContentAlignment.TopCenter;
            Click_DevToken.VisitedLinkColor = Color.FromArgb(14, 155, 177);
            Click_DevToken.LinkClicked += Click_DevToken_LinkClicked;
            // 
            // CreateConfig
            // 
            CreateConfig.AccessibleRole = AccessibleRole.PushButton;
            CreateConfig.BackColor = Color.FromArgb(6, 75, 92);
            CreateConfig.BackgroundColor = Color.FromArgb(6, 75, 92);
            CreateConfig.BorderColor = Color.FromArgb(6, 75, 92);
            CreateConfig.BorderRadius = 7;
            CreateConfig.BorderSize = 2;
            CreateConfig.FlatAppearance.BorderSize = 0;
            CreateConfig.FlatStyle = FlatStyle.Flat;
            CreateConfig.Font = new Font("Segoe UI", 12F);
            CreateConfig.ForeColor = Color.FromArgb(63, 213, 249);
            CreateConfig.Location = new Point(106, 131);
            CreateConfig.Name = "CreateConfig";
            CreateConfig.Size = new Size(284, 33);
            CreateConfig.TabIndex = 4;
            CreateConfig.Text = "Create Config";
            CreateConfig.TextColor = Color.FromArgb(63, 213, 249);
            CreateConfig.UseVisualStyleBackColor = false;
            CreateConfig.Value = null;
            CreateConfig.Click += CreateButton_Click;
            // 
            // VRCWEditor
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(486, 206);
            Controls.Add(CreateConfig);
            Controls.Add(Click_DevToken);
            Controls.Add(betterPanel2);
            Controls.Add(betterPanel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "VRCWEditor";
            Text = "VRCWEditor";
            Load += VRCWEditor_Load;
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private TextBox DevToken_Input;
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private TextBox WorldName_Input;
        private LinkLabel Click_DevToken;
        private MagmaMc.BetterForms.BetterButton CreateConfig;
    }
}