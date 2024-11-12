namespace VRCWMT
{
    partial class AddPlayer
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlayer));
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            PlayerID = new TextBox();
            WorldName_Input = new TextBox();
            CreateWorldButton = new MagmaMc.BetterForms.BetterButton();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            Message = new RichTextBox();
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
            betterPanel2.Controls.Add(PlayerID);
            betterPanel2.Controls.Add(WorldName_Input);
            betterPanel2.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel2.Location = new Point(45, 34);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(377, 45);
            betterPanel2.TabIndex = 2;
            // 
            // PlayerID
            // 
            PlayerID.AccessibleRole = AccessibleRole.Text;
            PlayerID.BackColor = Color.FromArgb(5, 25, 29);
            PlayerID.BorderStyle = BorderStyle.None;
            PlayerID.CharacterCasing = CharacterCasing.Lower;
            PlayerID.Font = new Font("Segoe UI", 12F);
            PlayerID.ForeColor = Color.FromArgb(79, 227, 249);
            PlayerID.Location = new Point(10, 11);
            PlayerID.MaxLength = 120;
            PlayerID.Name = "PlayerID";
            PlayerID.PlaceholderText = "PlayerID";
            PlayerID.Size = new Size(357, 22);
            PlayerID.TabIndex = 1;
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
            CreateWorldButton.Location = new Point(116, 182);
            CreateWorldButton.Name = "CreateWorldButton";
            CreateWorldButton.Size = new Size(239, 35);
            CreateWorldButton.TabIndex = 4;
            CreateWorldButton.Text = "Add Player";
            CreateWorldButton.TextColor = Color.FromArgb(63, 213, 249);
            CreateWorldButton.UseVisualStyleBackColor = false;
            CreateWorldButton.Value = null;
            CreateWorldButton.Click += AddPlayer_Click;
            // 
            // betterPanel1
            // 
            betterPanel1.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel1.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel1.BorderCurve = 7F;
            betterPanel1.BorderSize = 3F;
            betterPanel1.Controls.Add(Message);
            betterPanel1.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel1.Location = new Point(45, 85);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(377, 91);
            betterPanel1.TabIndex = 1;
            // 
            // Message
            // 
            Message.BackColor = Color.FromArgb(5, 25, 29);
            Message.BorderStyle = BorderStyle.None;
            Message.DetectUrls = false;
            Message.Location = new Point(10, 7);
            Message.MaxLength = 500;
            Message.Name = "Message";
            Message.ScrollBars = RichTextBoxScrollBars.None;
            Message.Size = new Size(357, 81);
            Message.TabIndex = 5;
            Message.Text = "";
            // 
            // AddPlayer
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(468, 233);
            Controls.Add(CreateWorldButton);
            Controls.Add(betterPanel2);
            Controls.Add(betterPanel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPlayer";
            Text = "Add Player To Group: ";
            Load += AddPlayer_Load;
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            betterPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private TextBox WorldName_Input;
        private MagmaMc.BetterForms.BetterButton CreateWorldButton;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        private RichTextBox Message;
        private TextBox PlayerID;
    }
}