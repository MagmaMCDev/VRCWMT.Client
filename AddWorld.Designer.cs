namespace VRCWMT
{
    partial class AddWorld
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWorld));
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            WorldName_Input = new TextBox();
            CreateWorldButton = new MagmaMc.BetterForms.BetterButton();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            Description_Input = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            betterPanel3 = new MagmaMc.BetterForms.BetterPanel();
            ImagePath = new TextBox();
            betterPanel2.SuspendLayout();
            betterPanel1.SuspendLayout();
            betterPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // betterPanel2
            // 
            betterPanel2.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel2.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel2.BorderCurve = 7F;
            betterPanel2.BorderSize = 3F;
            betterPanel2.Controls.Add(WorldName_Input);
            betterPanel2.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel2.Location = new Point(106, 38);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(377, 45);
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
            CreateWorldButton.Location = new Point(171, 300);
            CreateWorldButton.Name = "CreateWorldButton";
            CreateWorldButton.Size = new Size(239, 35);
            CreateWorldButton.TabIndex = 4;
            CreateWorldButton.Text = "Create World";
            CreateWorldButton.TextColor = Color.FromArgb(63, 213, 249);
            CreateWorldButton.UseVisualStyleBackColor = false;
            CreateWorldButton.Value = null;
            CreateWorldButton.Click += CreateButton_Click;
            // 
            // betterPanel1
            // 
            betterPanel1.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel1.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel1.BorderCurve = 7F;
            betterPanel1.BorderSize = 3F;
            betterPanel1.Controls.Add(Description_Input);
            betterPanel1.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel1.Location = new Point(106, 89);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(377, 134);
            betterPanel1.TabIndex = 1;
            // 
            // Description_Input
            // 
            Description_Input.BackColor = Color.FromArgb(5, 25, 29);
            Description_Input.BorderStyle = BorderStyle.None;
            Description_Input.DetectUrls = false;
            Description_Input.Location = new Point(10, 7);
            Description_Input.MaxLength = 500;
            Description_Input.Name = "Description_Input";
            Description_Input.ScrollBars = RichTextBoxScrollBars.None;
            Description_Input.Size = new Size(357, 124);
            Description_Input.TabIndex = 5;
            Description_Input.Text = "";
            Description_Input.TextChanged += Description_Input_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // betterPanel3
            // 
            betterPanel3.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel3.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel3.BorderCurve = 7F;
            betterPanel3.BorderSize = 3F;
            betterPanel3.Controls.Add(ImagePath);
            betterPanel3.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel3.Location = new Point(106, 228);
            betterPanel3.Name = "betterPanel3";
            betterPanel3.Size = new Size(377, 45);
            betterPanel3.TabIndex = 5;
            // 
            // ImagePath
            // 
            ImagePath.AccessibleRole = AccessibleRole.Text;
            ImagePath.BackColor = Color.FromArgb(5, 25, 29);
            ImagePath.BorderStyle = BorderStyle.None;
            ImagePath.CharacterCasing = CharacterCasing.Upper;
            ImagePath.Font = new Font("Segoe UI", 12F);
            ImagePath.ForeColor = Color.FromArgb(79, 227, 249);
            ImagePath.Location = new Point(10, 12);
            ImagePath.MaxLength = 256;
            ImagePath.Name = "ImagePath";
            ImagePath.PlaceholderText = "Select Banner Image";
            ImagePath.Size = new Size(357, 22);
            ImagePath.TabIndex = 0;
            ImagePath.MouseUp += SelectImage;
            // 
            // AddWorld
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(592, 393);
            Controls.Add(betterPanel3);
            Controls.Add(CreateWorldButton);
            Controls.Add(betterPanel2);
            Controls.Add(betterPanel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddWorld";
            Text = "VRCWEditor";
            Load += CreateWorld_Load;
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            betterPanel1.ResumeLayout(false);
            betterPanel3.ResumeLayout(false);
            betterPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private TextBox WorldName_Input;
        private MagmaMc.BetterForms.BetterButton CreateWorldButton;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private RichTextBox Description_Input;
        private OpenFileDialog openFileDialog1;
        private MagmaMc.BetterForms.BetterPanel betterPanel3;
        private TextBox ImagePath;
    }
}