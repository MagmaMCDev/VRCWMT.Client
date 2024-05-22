namespace VRCWMT
{
    partial class SettingsWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            AllowMultipleWindows = new CheckBox();
            WarnBeforeClose = new CheckBox();
            FastGC = new CheckBox();
            betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            UpdateTime = new TextBox();
            label1 = new Label();
            AutoCloseInstance = new CheckBox();
            betterPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // AllowMultipleWindows
            // 
            AllowMultipleWindows.AutoSize = true;
            AllowMultipleWindows.Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AllowMultipleWindows.Location = new Point(37, 29);
            AllowMultipleWindows.Name = "AllowMultipleWindows";
            AllowMultipleWindows.Size = new Size(206, 25);
            AllowMultipleWindows.TabIndex = 4;
            AllowMultipleWindows.Text = "Allow Multiple Windows";
            AllowMultipleWindows.UseVisualStyleBackColor = true;
            // 
            // WarnBeforeClose
            // 
            WarnBeforeClose.AutoSize = true;
            WarnBeforeClose.Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WarnBeforeClose.Location = new Point(37, 60);
            WarnBeforeClose.Name = "WarnBeforeClose";
            WarnBeforeClose.Size = new Size(148, 25);
            WarnBeforeClose.TabIndex = 5;
            WarnBeforeClose.Text = "Warn Before Exit";
            WarnBeforeClose.UseVisualStyleBackColor = true;
            // 
            // FastGC
            // 
            FastGC.AutoSize = true;
            FastGC.Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FastGC.Location = new Point(37, 91);
            FastGC.Name = "FastGC";
            FastGC.Size = new Size(82, 25);
            FastGC.TabIndex = 6;
            FastGC.Text = "Fast GC";
            FastGC.UseVisualStyleBackColor = true;
            // 
            // betterPanel1
            // 
            betterPanel1.BackColor = Color.FromArgb(5, 25, 29);
            betterPanel1.BorderColor = Color.FromArgb(6, 75, 92);
            betterPanel1.BorderCurve = 7F;
            betterPanel1.BorderSize = 3F;
            betterPanel1.Controls.Add(UpdateTime);
            betterPanel1.ForeColor = Color.FromArgb(6, 75, 92);
            betterPanel1.Location = new Point(148, 149);
            betterPanel1.Name = "betterPanel1";
            betterPanel1.Size = new Size(76, 35);
            betterPanel1.TabIndex = 3;
            // 
            // UpdateTime
            // 
            UpdateTime.AccessibleRole = AccessibleRole.Text;
            UpdateTime.BackColor = Color.FromArgb(5, 25, 29);
            UpdateTime.BorderStyle = BorderStyle.None;
            UpdateTime.CharacterCasing = CharacterCasing.Upper;
            UpdateTime.Font = new Font("Segoe UI", 12F);
            UpdateTime.ForeColor = Color.FromArgb(79, 227, 249);
            UpdateTime.Location = new Point(5, 7);
            UpdateTime.MaxLength = 4;
            UpdateTime.Name = "UpdateTime";
            UpdateTime.Size = new Size(68, 22);
            UpdateTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Small", 12F);
            label1.Location = new Point(34, 155);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 7;
            label1.Text = "Update Time:";
            // 
            // AutoCloseInstance
            // 
            AutoCloseInstance.AutoSize = true;
            AutoCloseInstance.Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutoCloseInstance.Location = new Point(37, 122);
            AutoCloseInstance.Name = "AutoCloseInstance";
            AutoCloseInstance.Size = new Size(173, 25);
            AutoCloseInstance.TabIndex = 8;
            AutoCloseInstance.Text = "Auto Close Instance";
            AutoCloseInstance.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 27);
            ClientSize = new Size(317, 199);
            Controls.Add(AutoCloseInstance);
            Controls.Add(label1);
            Controls.Add(betterPanel1);
            Controls.Add(FastGC);
            Controls.Add(WarnBeforeClose);
            Controls.Add(AllowMultipleWindows);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            FormClosing += SaveSettings;
            Load += SettingsWindow_Load;
            betterPanel1.ResumeLayout(false);
            betterPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox AllowMultipleWindows;
        private CheckBox WarnBeforeClose;
        private CheckBox FastGC;
        private MagmaMc.BetterForms.BetterPanel betterPanel1;
        public TextBox UpdateTime;
        private Label label1;
        private CheckBox AutoCloseInstance;
    }
}