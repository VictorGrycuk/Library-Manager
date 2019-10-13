﻿using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class frmLanguageConfig : XtraForm
    {
        private readonly LibraryCore _core;

        public frmLanguageConfig(LibraryCore core)
        {
            _core = core;
            InitializeComponent();

            _core.Localization.RegisterNewControl(btnApplyLanguage);
            _core.Localization.RegisterNewControl(lblAvailableLanguage);
        }

        private void frmLanguageConfig_Load(object sender, EventArgs e)
        {
            var languages = _core.Localization.GetLanguages();
            languages.ForEach(l => comboAvailableLangauges.Properties.Items.Add(l.LanguageTag));

            comboAvailableLangauges.Text = _core.Localization.CurrentLocalization;
        }

        private void btnApplyLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                _core.Localization.SetLocalization(comboAvailableLangauges.Text);
                _core.Localization.ApplyLocalization();
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
                    var language = _core.Localization.GetLanguages().Find(l => l.LanguageTag == comboAvailableLangauges.Text);
                    sf.FileName = language.LanguageTag;
                    sf.Filter = "Serialzied Object (*.json)|*.json";
                    sf.DefaultExt = ".json";
                    sf.AddExtension = true;
                    sf.ShowDialog();

                    _core.Localization.Export(language, sf.FileName);
                }

                XtraMessageBox.Show("Localization was exported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong!\n" + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}