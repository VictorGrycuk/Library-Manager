using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Base.Architecture.UserManagement.Models;
using DevExpress.XtraEditors;
using LibraryManagementCore;
using DevExpress.XtraLayout;

namespace LibraryManagement
{
    public partial class frmUserForm : DevExpress.XtraEditors.XtraForm
    {
        private Core _core;

        public frmUserForm(Core core)
        {
            InitializeComponent();

            _core = core;
        }

        private void frmUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            var newUser = new User
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text
            };

            try
            {
                _core.UserManagement.StoreUser(newUser, txtPassword.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong:\n\n" + ex.Message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            var emptyControlList = new List<string>();
            foreach (var group in layoutControlGroupUser.Items)
            {
                var grp = group as LayoutControlGroup;

                if (grp == null) continue;
                foreach (var control in grp.Items)
                {
                    var edit = (control as LayoutControlItem)?.Control as TextEdit;
                    if (edit != null && string.IsNullOrWhiteSpace(edit.Text)) emptyControlList.Add((control as LayoutControlItem).CustomizationFormText);
                }
            }

            if (emptyControlList.Count == 0) return true;

            XtraMessageBox.Show("The following controls can not be empty:\n\n" + string.Join("\n", emptyControlList.ToArray()),
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);

            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var group in layoutControlGroupUser.Items)
            {
                var grp = group as LayoutControlGroup;

                if (grp == null) continue;
                foreach (var control in grp.Items)
                {
                    var edit = (control as LayoutControlItem)?.Control as TextEdit;
                    if (edit != null && !string.IsNullOrWhiteSpace(edit.Text)) edit.Text = string.Empty;
                }
            }
        }
    }
}