using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class frmLanguageConfig : XtraForm
    {
        private readonly Core _core;

        public frmLanguageConfig(Core core)
        {
            _core = core;
            InitializeComponent();

            _core.Localization.RegisterNewControl(btnApplyLanguage);
            _core.Localization.RegisterNewControl(lblAvailableLanguage);
        }

        private void frmLanguageConfig_Load(object sender, EventArgs e)
        {
            var languages = _core.Localization.GetLanguages();
            languages.ForEach(l => comboAvailableLangauges.Properties.Items.Add(l));

            comboAvailableLangauges.Text = _core.Localization.CurrentLocalization;
        }

        private void btnApplyLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                _core.Localization.SetLocalization(comboAvailableLangauges.Text);
                _core.Localization.ApplyLocalization();
                _core.LoggedUser.Configuration.Language = _core.Localization.CurrentLocalization;
                _core.UserManagement.UpdateUser(_core.LoggedUser);
                XtraMessageBox.Show("Localization set successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong!\n" + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportLocalization_Click(object sender, EventArgs e)
        {
            try
            {
                using (var of = new OpenFileDialog())
                {
                    of.Filter = "Language File|*.json";
                    of.ShowDialog();

                    if (!string.IsNullOrWhiteSpace(of.FileName))
                    {
                        _core.Localization.Import(of.FileName);
                    }
                }

                XtraMessageBox.Show("Localization was imported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong!\n" + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportLocalization_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sf = new SaveFileDialog())
                {
                    sf.FileName = comboAvailableLangauges.Text;
                    sf.Filter = "Serialzied Object (*.json)|*.json";
                    sf.DefaultExt = ".json";
                    sf.AddExtension = true;

                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        _core.Localization.Export(sf.FileName, comboAvailableLangauges.Text);
                        XtraMessageBox.Show("Localization was exported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong!\n" + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}