using System.Text.RegularExpressions;
using KPreisser.UI;
using TaskDialog = KPreisser.UI.TaskDialog;

namespace VRCWMT;

public partial class SettingsWindow : Form
{
    public bool Canceled = true;
    public SettingsWindow()
    {
        InitializeComponent();
    }

    private void SettingsWindow_Load(object sender, EventArgs e)
    {
        FastGC.Checked = Config.FastGC;
        AllowMultipleWindows.Checked = Config.AllowMultipleWindows;
        WarnBeforeClose.Checked = Config.WarnBeforeClose;
        AutoCloseInstance.Checked = Config.AutoCloseInstance;
        UpdateTime.Text = Config.UpdateTime.ToString();
    }

    private void SaveSettings(object sender, FormClosingEventArgs e)
    {
        Config.FastGC = FastGC.Checked;
        Config.AllowMultipleWindows = AllowMultipleWindows.Checked;
        Config.WarnBeforeClose = WarnBeforeClose.Checked;
        Config.AutoCloseInstance = AutoCloseInstance.Checked;
        ushort time;
        if (!ushort.TryParse(UpdateTime.Text.Trim(), out time))
        {
            e.Cancel = true;
            TaskDialog.Show(text: "Failed To Save Update Time",
                title: "Settings Window",
                buttons: TaskDialogButtons.OK,
                icon: TaskDialogStandardIcon.Error);
            return;
        }
        if (time < 5)
            time = 10;
        if (time > 300)
            time = 300;
        Config.UpdateTime = time;
        Config.WriteConfig();
    }
}
