using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
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
            
            // We try to load the local configuration
            var localConfig = LoadLocalConfiguration();
            if (localConfig == null)
            {
                Environment.Exit(-1);
            }

            _library = new Core(localConfig);
            _library.Localization.RegisterNewControl(btnLogIn);
            _library.Localization.ApplyLocalization();
        }

        private static LocalConfiguration LoadLocalConfiguration()
        {
            var filePath = Path.Combine(Application.StartupPath, "configuration.json");
            LocalConfiguration config;

            if (File.Exists(filePath))
            {
                config = new LocalConfiguration(filePath);
                if (!string.IsNullOrWhiteSpace(config.ApplicationSettings) &&
                    !string.IsNullOrWhiteSpace(config.Database)) return config;

                XtraMessageBox.Show("Either the path to the application settings  file or the path to the database file is not set\n" +
                                    "Make sure the fields are correctly configured.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;

            }

            config = new LocalConfiguration() { Localization = "", ApplicationSettings = "", Database = "" };
            config.SaveToFile(filePath);
            XtraMessageBox.Show("Local configuration not found\nA blank configuration was created, please configure and re open the application", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return null;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckControls(txtUserName);
                CheckControls(txtPassword);

                _library.LogIn(txtUserName.Text, txtPassword.Text);
                var mainMenu = new MainMenu(_library);
                Hide();
                mainMenu.Show();
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