using System.Text.RegularExpressions;

namespace VRCWMT;

public partial class AddGroup : Form
{
    public bool Canceled = true;
    public AddGroup()
    {
        InitializeComponent();
    }
    private void AddGroup_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(GroupName.Text))
        {
            MessageBox.Show("Group Name Is Required", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(GroupPermissions.Text))
        {
            MessageBox.Show("At Least One Permission Is Required", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Canceled = false;
        Close();
    }
}
