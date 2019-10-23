using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using LibraryManagementCore;

namespace LibraryManagement
{
    static class Helpers
    {
        public static void ClearLayoutControls(LayoutControlGroup layoutGroup)
        {
            IterateLayoutGroups(
                layoutGroup,
                edit => edit != null && !string.IsNullOrWhiteSpace(edit.Text),
                edit => edit.Text = string.Empty);
        }

        private static void IterateLayoutGroups(LayoutControlGroup layoutGroup, Func<TextEdit, bool> validation, Action<TextEdit> action)
        {
            foreach (var item in layoutGroup.Items)
            {
                var grp = item as LayoutControlGroup;
                if (grp != null) IterateLayoutGroups(grp, validation, action);

                var edit = (item as LayoutControlItem)?.Control as TextEdit;
                if (validation(edit)) action.Invoke(edit);
            }
        }

        public static void ValidateLayoutControls(LayoutControlGroup layoutGroup)
        {
            var emptyControlList = new List<string>();
            IterateLayoutGroups2(
                layoutGroup,
                emptyControlList);

            if (emptyControlList.Count > 0)
            {
                throw new Exception("The following controls are empty:\n\n" + string.Join("\n", emptyControlList.ToArray()));
            }
        }

        private static void IterateLayoutGroups2(LayoutControlGroup layoutGroup, List<string> emptyControls)
        {
            foreach (var item in layoutGroup.Items)
            {
                var grp = item as LayoutControlGroup;
                if (grp != null) IterateLayoutGroups2(grp, emptyControls);

                var edit = (item as LayoutControlItem)?.Control as TextEdit;
                if (edit != null && string.IsNullOrWhiteSpace(edit.Text)) emptyControls.Add((item as LayoutControlItem).CustomizationFormText);

                var list = (item as LayoutControlItem)?.Control as ListBoxControl;
                if (list != null && list.ItemCount == 0) emptyControls.Add((item as LayoutControlItem).CustomizationFormText);
            }
        }

        public static LocalConfiguration LoadLocalConfiguration()
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
    }
}
