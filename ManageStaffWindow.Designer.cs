using MagmaMc.BetterForms;

namespace VRCWMT;

partial class ManageStaffWindow
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
        betterPanel1 = new BetterPanel();
        UsersPanel = new Panel();
        betterPanel2 = new BetterPanel();
        WorldName_Input = new TextBox();
        betterPanel3 = new BetterPanel();
        WorldDesc_Input = new RichTextBox();
        SaveWorldDetails = new BetterButton();
        betterRadioButton1 = new BetterRadioButton();
        betterRadioButton2 = new BetterRadioButton();
        betterPanel1.SuspendLayout();
        betterPanel2.SuspendLayout();
        betterPanel3.SuspendLayout();
        SuspendLayout();
        // 
        // betterPanel1
        // 
        betterPanel1.BackColor = Color.FromArgb(25, 26, 27);
        betterPanel1.BorderColor = Color.DeepSkyBlue;
        betterPanel1.BorderCurve = 10F;
        betterPanel1.BorderSize = 4F;
        betterPanel1.Controls.Add(UsersPanel);
        betterPanel1.Location = new Point(2, 12);
        betterPanel1.Name = "betterPanel1";
        betterPanel1.Size = new Size(354, 319);
        betterPanel1.TabIndex = 3;
        // 
        // UsersPanel
        // 
        UsersPanel.BackColor = Color.FromArgb(25, 26, 27);
        UsersPanel.Location = new Point(9, 31);
        UsersPanel.Name = "UsersPanel";
        UsersPanel.Size = new Size(336, 282);
        UsersPanel.TabIndex = 0;
        // 
        // betterPanel2
        // 
        betterPanel2.BackColor = Color.FromArgb(25, 26, 27);
        betterPanel2.BorderColor = Color.DeepSkyBlue;
        betterPanel2.BorderCurve = 10F;
        betterPanel2.BorderSize = 4F;
        betterPanel2.Controls.Add(WorldName_Input);
        betterPanel2.Location = new Point(375, 12);
        betterPanel2.Name = "betterPanel2";
        betterPanel2.Size = new Size(358, 39);
        betterPanel2.TabIndex = 4;
        // 
        // WorldName_Input
        // 
        WorldName_Input.BackColor = Color.FromArgb(25, 26, 27);
        WorldName_Input.BorderStyle = BorderStyle.None;
        WorldName_Input.Cursor = Cursors.IBeam;
        WorldName_Input.Font = new Font("Segoe UI Variable Small", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        WorldName_Input.Location = new Point(8, 9);
        WorldName_Input.MaxLength = 100;
        WorldName_Input.Name = "WorldName_Input";
        WorldName_Input.Size = new Size(338, 20);
        WorldName_Input.TabIndex = 0;
        WorldName_Input.TextChanged += textBox1_TextChanged;
        // 
        // betterPanel3
        // 
        betterPanel3.BorderColor = Color.DeepSkyBlue;
        betterPanel3.BorderCurve = 10F;
        betterPanel3.BorderSize = 4F;
        betterPanel3.Controls.Add(WorldDesc_Input);
        betterPanel3.Location = new Point(375, 57);
        betterPanel3.Name = "betterPanel3";
        betterPanel3.Size = new Size(358, 163);
        betterPanel3.TabIndex = 4;
        // 
        // WorldDesc_Input
        // 
        WorldDesc_Input.BackColor = Color.FromArgb(25, 26, 27);
        WorldDesc_Input.BorderStyle = BorderStyle.None;
        WorldDesc_Input.DetectUrls = false;
        WorldDesc_Input.Location = new Point(7, 6);
        WorldDesc_Input.MaxLength = 1000;
        WorldDesc_Input.Name = "WorldDesc_Input";
        WorldDesc_Input.Size = new Size(346, 154);
        WorldDesc_Input.TabIndex = 0;
        WorldDesc_Input.Text = "";
        WorldDesc_Input.TextChanged += WorldDesc_Input_TextChanged;
        // 
        // SaveWorldDetails
        // 
        SaveWorldDetails.AccessibleRole = AccessibleRole.PushButton;
        SaveWorldDetails.BackColor = Color.FromArgb(6, 75, 92);
        SaveWorldDetails.BackgroundColor = Color.FromArgb(6, 75, 92);
        SaveWorldDetails.BorderColor = Color.FromArgb(6, 75, 92);
        SaveWorldDetails.BorderRadius = 7;
        SaveWorldDetails.BorderSize = 2;
        SaveWorldDetails.FlatAppearance.BorderSize = 0;
        SaveWorldDetails.FlatStyle = FlatStyle.Flat;
        SaveWorldDetails.Font = new Font("Segoe UI", 12F);
        SaveWorldDetails.ForeColor = Color.FromArgb(63, 213, 249);
        SaveWorldDetails.Location = new Point(434, 226);
        SaveWorldDetails.Name = "SaveWorldDetails";
        SaveWorldDetails.Size = new Size(239, 35);
        SaveWorldDetails.TabIndex = 5;
        SaveWorldDetails.Text = "Save";
        SaveWorldDetails.TextColor = Color.FromArgb(63, 213, 249);
        SaveWorldDetails.UseVisualStyleBackColor = false;
        SaveWorldDetails.Value = null;
        SaveWorldDetails.Click += SaveWorldDetails_Click;
        // 
        // betterRadioButton1
        // 
        betterRadioButton1.AutoSize = true;
        betterRadioButton1.CheckedColor = Color.MediumSlateBlue;
        betterRadioButton1.Location = new Point(362, 294);
        betterRadioButton1.MinimumSize = new Size(0, 21);
        betterRadioButton1.Name = "betterRadioButton1";
        betterRadioButton1.Padding = new Padding(10, 0, 0, 0);
        betterRadioButton1.Size = new Size(100, 21);
        betterRadioButton1.TabIndex = 0;
        betterRadioButton1.TabStop = true;
        betterRadioButton1.Text = "Read access";
        betterRadioButton1.UnCheckedColor = Color.Gray;
        betterRadioButton1.UseVisualStyleBackColor = true;
        betterRadioButton1.CheckedChanged += UpdateAccess;
        // 
        // betterRadioButton2
        // 
        betterRadioButton2.AutoSize = true;
        betterRadioButton2.CheckedColor = Color.MediumSlateBlue;
        betterRadioButton2.Location = new Point(362, 267);
        betterRadioButton2.MinimumSize = new Size(0, 21);
        betterRadioButton2.Name = "betterRadioButton2";
        betterRadioButton2.Padding = new Padding(10, 0, 0, 0);
        betterRadioButton2.Size = new Size(134, 21);
        betterRadioButton2.TabIndex = 6;
        betterRadioButton2.TabStop = true;
        betterRadioButton2.Text = "Read/Write access";
        betterRadioButton2.UnCheckedColor = Color.Gray;
        betterRadioButton2.UseVisualStyleBackColor = true;
        betterRadioButton2.CheckedChanged += UpdateAccess;
        // 
        // ManageStaffWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(40, 41, 42);
        ClientSize = new Size(738, 338);
        Controls.Add(betterRadioButton2);
        Controls.Add(betterRadioButton1);
        Controls.Add(SaveWorldDetails);
        Controls.Add(betterPanel3);
        Controls.Add(betterPanel2);
        Controls.Add(betterPanel1);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "ManageStaffWindow";
        Text = "Manage World";
        Load += Form_Loaded;
        betterPanel1.ResumeLayout(false);
        betterPanel2.ResumeLayout(false);
        betterPanel2.PerformLayout();
        betterPanel3.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MagmaMc.BetterForms.BetterPanel betterPanel1;
    private Panel UsersPanel;
    private BetterPanel betterPanel2;
    private TextBox WorldName_Input;
    private BetterPanel betterPanel3;
    private RichTextBox WorldDesc_Input;
    private BetterButton SaveWorldDetails;
    private BetterRadioButton betterRadioButton1;
    private BetterRadioButton betterRadioButton2;
}