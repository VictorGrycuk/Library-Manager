using System;
using System.Security;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class frmLogIn : XtraForm
    {
        private readonly Core _library;
        public frmLogIn()
        {
            InitializeComponent();
            try
            {
                // We try to load the local configuration
                var localConfig = Helpers.LoadLocalConfiguration();
                if (localConfig == null)
                {
                    Environment.Exit(-1);
                }

                _library = new Core(localConfig);
                _library.Localization.RegisterNewControl(btnLogIn);
                _library.Localization.ApplyLocalization();
            }
            catch (SecurityException exception)
            {
                XtraMessageBox.Show("The database checksum does not match the checksum stored.\nThe database information may be compromised.\n\nThe program will now exit.", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Something went wrong:\n" + exception.Message);
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckControls(txtUserName);
                CheckControls(txtPassword);

                _library.LogIn(txtUserName.Text, txtPassword.Text);

                using (var mainMenu = new MainMenu(_library))
                {
                    Hide();
                    mainMenu.ShowDialog();
                }

                Show();
            }
            catch (ArgumentException exception)
            {
                XtraMessageBox.Show("Username or Password invalid.\nPlease try again.", exception.Message);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Something went wrong:\n" + exception.Message, exception.Message);
            }
        }

        private void CheckControls(TextEdit textEdit)
        {
            errorProvider.SetIconAlignment(textEdit, ErrorIconAlignment.MiddleRight);
            if (string.IsNullOrWhiteSpace(textEdit.Text))
            {
                errorProvider.SetError(textEdit, "Field can not be empty", ErrorType.Warning);
            }
            else
            {
                errorProvider.SetError(textEdit, string.Empty);
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogIn_Click(null, null);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogIn_Click(null, null);
            }
        }
    }
}