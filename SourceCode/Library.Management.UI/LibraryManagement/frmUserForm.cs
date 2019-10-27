using System;
using System.Windows.Forms;
using Base.Architecture.UserManagement.Models;
using DevExpress.XtraEditors;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class frmUserForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Core _core;

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
            try
            {
                Helpers.ValidateLayoutControls(layoutControlGroupUser);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Helpers.ClearLayoutControls(layoutControlGroupUser);
        }
    }
}