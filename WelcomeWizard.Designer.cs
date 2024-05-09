namespace VRCWMT
{
    partial class WelcomeWizard
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeWizard));
            betterPanel2 = new MagmaMc.BetterForms.BetterPanel();
            WorldID_Input = new TextBox();
            Click_DevToken = new LinkLabel();
            ContinueButton = new MagmaMc.BetterForms.BetterButton();
            WarningText = new Label();
            betterPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // betterPanel2
            // 
            betterPanel2.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel2.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel2.BorderCurve = 7F;
            betterPanel2.BorderSize = 3F;
            betterPanel2.Controls.Add(WorldID_Input);
            betterPanel2.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel2.Location = new Point(106, 37);
            betterPanel2.Name = "betterPanel2";
            betterPanel2.Size = new Size(284, 45);
            betterPanel2.TabIndex = 2;
            // 
            // WorldID_Input
            // 
            WorldID_Input.AccessibleRole = AccessibleRole.Text;
            WorldID_Input.BackColor = Color.FromArgb(5, 25, 29);
            WorldID_Input.BorderStyle = BorderStyle.None;
            WorldID_Input.CharacterCasing = CharacterCasing.Upper;
            WorldID_Input.Font = new Font("Segoe UI", 12F);
            WorldID_Input.ForeColor = Color.FromArgb(79, 227, 249);
            WorldID_Input.Location = new Point(10, 12);
            WorldID_Input.MaxLength = 120;
            WorldID_Input.Name = "WorldID_Input";
            WorldID_Input.PlaceholderText = "Enter WorldID";
            WorldID_Input.Size = new Size(268, 22);
            WorldID_Input.TabIndex = 0;
            // 
            // Click_DevToken
            // 
            Click_DevToken.AccessibleRole = AccessibleRole.StaticText;
            Click_DevToken.AutoSize = true;
            Click_DevToken.LinkBehavior = LinkBehavior.NeverUnderline;
            Click_DevToken.LinkColor = Color.FromArgb(14, 155, 177);
            Click_DevToken.Location = new Point(203, 153);
            Click_DevToken.Name = "Click_DevToken";
            Click_DevToken.Size = new Size(87, 16);
            Click_DevToken.TabIndex = 3;
            Click_DevToken.TabStop = true;
            Click_DevToken.Text = "Create a World";
            Click_DevToken.TextAlign = ContentAlignment.TopCenter;
            Click_DevToken.VisitedLinkColor = Color.FromArgb(14, 155, 177);
            Click_DevToken.LinkClicked += Click_CreateWorld_LinkClicked;
            // 
            // ContinueButton
            // 
            ContinueButton.AccessibleRole = AccessibleRole.PushButton;
            ContinueButton.BackColor = Color.FromArgb(6, 75, 92);
            ContinueButton.BackgroundColor = Color.FromArgb(6, 75, 92);
            ContinueButton.BorderColor = Color.FromArgb(6, 75, 92);
            ContinueButton.BorderRadius = 7;
            ContinueButton.BorderSize = 2;
            ContinueButton.FlatAppearance.BorderSize = 0;
            ContinueButton.FlatStyle = FlatStyle.Flat;
            ContinueButton.Font = new Font("Segoe UI", 12F);
            ContinueButton.ForeColor = Color.FromArgb(63, 213, 249);
            ContinueButton.Location = new Point(106, 115);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new Size(284, 35);
            ContinueButton.TabIndex = 4;
            ContinueButton.Text = "Continue";
            ContinueButton.TextColor = Color.FromArgb(63, 213, 249);
            ContinueButton.UseVisualStyleBackColor = false;
            ContinueButton.Value = null;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // WarningText
            // 
            WarningText.ForeColor = Color.FromArgb(255, 128, 0);
            WarningText.Location = new Point(116, 85);
            WarningText.Name = "WarningText";
            WarningText.Size = new Size(268, 22);
            WarningText.TabIndex = 5;
            WarningText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WelcomeWizard
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 18, 22);
            ClientSize = new Size(486, 187);
            Controls.Add(WarningText);
            Controls.Add(ContinueButton);
            Controls.Add(Click_DevToken);
            Controls.Add(betterPanel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "WelcomeWizard";
            Text = "VRCWEditor";
            FormClosing += WelcomeWizard_FormClosing;
            Load += WelcomeWizard_Load;
            betterPanel2.ResumeLayout(false);
            betterPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private MagmaMc.BetterForms.BetterPanel betterPanel2;
        private TextBox WorldID_Input;
        private LinkLabel Click_DevToken;
        private MagmaMc.BetterForms.BetterButton ContinueButton;
        private Label WarningText;
    }
}