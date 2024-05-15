namespace VRCWMT
{
    partial class AddGroup
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroup));
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            GroupName = new TextBox();
            WorldName_Input = new TextBox();
            CreateWorldButton = new MagmaMc.BetterForms.BetterButton();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            GroupPermissions = new TextBox();
            textBox2 = new TextBox();
            betterPanel2.SuspendLayout();
            betterPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // betterPanel2
            // 
            betterPanel2.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel2.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel2.BorderCurve = 7F;
            betterPanel2.BorderSize = 3F;
            betterPanel2.Controls.Add(GroupName);
            betterPanel2.Controls.Add(WorldName_Input);
            betterPanel2.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel2.Location = new Point(45, 34);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(377, 45);
            betterPanel2.TabIndex = 2;
            // 
            // GroupName
            // 
            GroupName.AccessibleRole = AccessibleRole.Text;
            GroupName.BackColor = Color.FromArgb(5, 25, 29);
            GroupName.BorderStyle = BorderStyle.None;
            GroupName.CharacterCasing = CharacterCasing.Upper;
            GroupName.Font = new Font("Segoe UI", 12F);
            GroupName.ForeColor = Color.FromArgb(79, 227, 249);
            GroupName.Location = new Point(10, 11);
            GroupName.MaxLength = 120;
            GroupName.Name = "GroupName";
            GroupName.PlaceholderText = "Group Name";
            GroupName.Size = new Size(357, 22);
            GroupName.TabIndex = 1;
            // 
            // WorldName_Input
            // 
            WorldName_Input.AccessibleRole = AccessibleRole.Text;
            WorldName_Input.BackColor = Color.FromArgb(5, 25, 29);
            WorldName_Input.BorderStyle = BorderStyle.None;
            WorldName_Input.CharacterCasing = CharacterCasing.Upper;
            WorldName_Input.Font = new Font("Segoe UI", 12F);
            WorldName_Input.ForeColor = Color.FromArgb(79, 227, 249);
            WorldName_Input.Location = new Point(10, 12);
            WorldName_Input.MaxLength = 120;
            WorldName_Input.Name = "WorldName_Input";
            WorldName_Input.PlaceholderText = "WorldName";
            WorldName_Input.Size = new Size(357, 22);
            WorldName_Input.TabIndex = 0;
            // 
            // CreateWorldButton
            // 
            CreateWorldButton.AccessibleRole = AccessibleRole.PushButton;
            CreateWorldButton.BackColor = Color.FromArgb(6, 75, 92);
            CreateWorldButton.BackgroundColor = Color.FromArgb(6, 75, 92);
            CreateWorldButton.BorderColor = Color.FromArgb(6, 75, 92);
            CreateWorldButton.BorderRadius = 7;
            CreateWorldButton.BorderSize = 2;
            CreateWorldButton.FlatAppearance.BorderSize = 0;
            CreateWorldButton.FlatStyle = FlatStyle.Flat;
            CreateWorldButton.Font = new Font("Segoe UI", 12F);
            CreateWorldButton.ForeColor = Color.FromArgb(63, 213, 249);
            CreateWorldButton.Location = new Point(109, 136);
            CreateWorldButton.Name = "CreateWorldButton";
            CreateWorldButton.Size = new Size(239, 35);
            CreateWorldButton.TabIndex = 4;
            CreateWorldButton.Text = "Add Group";
            CreateWorldButton.TextColor = Color.FromArgb(63, 213, 249);
            CreateWorldButton.UseVisualStyleBackColor = false;
            CreateWorldButton.Value = null;
            CreateWorldButton.Click += AddGroup_Click;
            // 
            // betterPanel1
            // 
            betterPanel1.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel1.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel1.BorderCurve = 7F;
            betterPanel1.BorderSize = 3F;
            betterPanel1.Controls.Add(GroupPermissions);
            betterPanel1.Controls.Add(textBox2);
            betterPanel1.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel1.Location = new Point(45, 85);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(377, 45);
            betterPanel1.TabIndex = 3;
            // 
            // GroupPermissions
            // 
            GroupPermissions.AccessibleRole = AccessibleRole.Text;
            GroupPermissions.BackColor = Color.FromArgb(5, 25, 29);
            GroupPermissions.BorderStyle = BorderStyle.None;
            GroupPermissions.CharacterCasing = CharacterCasing.Upper;
            GroupPermissions.Font = new Font("Segoe UI", 12F);
            GroupPermissions.ForeColor = Color.FromArgb(79, 227, 249);
            GroupPermissions.Location = new Point(10, 11);
            GroupPermissions.MaxLength = 120;
            GroupPermissions.Name = "GroupPermissions";
            GroupPermissions.PlaceholderText = "Group Permissions";
            GroupPermissions.Size = new Size(357, 22);
            GroupPermissions.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.AccessibleRole = AccessibleRole.Text;
            textBox2.BackColor = Color.FromArgb(5, 25, 29);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.ForeColor = Color.FromArgb(79, 227, 249);
            textBox2.Location = new Point(10, 12);
            textBox2.MaxLength = 120;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "WorldName";
            textBox2.Size = new Size(357, 22);
            textBox2.TabIndex = 0;
            // 
            // AddGroup
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(468, 198);
            Controls.Add(betterPanel1);
            Controls.Add(CreateWorldButton);
            Controls.Add(betterPanel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddGroup";
            Text = "Create Permission Group";
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private TextBox WorldName_Input;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private TextBox textBox2;
        public TextBox GroupPermissions;
        public MagmaMc.BetterForms.BetterButton CreateWorldButton;
        public TextBox GroupName;
    }
}