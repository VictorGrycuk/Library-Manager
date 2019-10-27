using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Base.Architecture.DatabaseManager;
using Base.Architecture.LocalizationManagement;
using Base.Architecture.LogManagement;

namespace LibraryManagementCore.Localization
{
    public class Localization
    {
        public string CurrentLocalization => _currentLanguage.LanguageTag;
        private readonly LocalizationManager _languageManager;
        private readonly List<Control> _controlList = new List<Control>();
        private readonly List<object> _objectList = new List<object>();
        private Language _currentLanguage;

        public Localization(DBManager dbManager)
        {
            _languageManager = new LocalizationManager(dbManager);
        }

        public void RegisterNewControl(Control control)
        {
            if (!_controlList.Contains(control))
            {
                _controlList.Add(control);
            }
        }

        public void RegisterNewControl(object control)
        {
            if (!_objectList.Contains(control))
            {
                _objectList.Add(control);
            }
        }

        public void RemoveRegisteredControl(Control control)
        {
            _controlList.Remove(control);
        }

        public void RemoveRegisteredControl(object control)
        {
            _objectList.Remove(control);
        }

        public void SetLocalization(string localizationCode)
        {
            _currentLanguage = _languageManager.Find(localizationCode);
        }

        public void Import(string filePath)
        {
            _languageManager.Import(filePath);
        }

        public void Export(string filePath, string languageCode)
        {
            _languageManager.Export(filePath, _languageManager.Find(languageCode));
        }

        public List<string> GetLanguages()
        {
            return _languageManager.GetAll().ToList().Select(l => l.LanguageTag).ToList();
        }

        public void ApplyLocalization()
        {
            _controlList.ForEach(c => c.Text = Test(c));
            _objectList.ForEach(c => SetObjectLanguage(c, _currentLanguage.Controls));
        }

        private string Test(Control control)
        {
            return _currentLanguage.Controls.ContainsKey(control.Name) ? _currentLanguage.Controls[control.Name] : control.Text;
        }

        public static void SetObjectLanguage(object control, Dictionary<string, string> dictionary)
        {
            SetNewValue(control, GetNewValue(control, dictionary));
        }

        private static string GetNewValue(object control, Dictionary<string, string> dictionary)
        {
            var controlName = control.GetType().GetProperty("Name")?.GetValue(control, null) as string;

            return !dictionary.ContainsKey(controlName) ? GetDefaultProperty(control) : dictionary[controlName];
        }

        private static void SetNewValue(object control, string newValue)
        {
            var propertyInfo = GetPropertyInfo(control);

            propertyInfo?.SetValue(control, Convert.ChangeType(newValue, propertyInfo.PropertyType), null);
        }

        private static string GetDefaultProperty(object control)
        {
            var propertyInfo = GetPropertyInfo(control);

            return propertyInfo?.GetValue(control).ToString();
        }

        private static PropertyInfo GetPropertyInfo(object control)
        {
            var propertyInfo = control.GetType().GetProperty("Caption");

            if (propertyInfo == null)
            {
                propertyInfo = control.GetType().GetProperty("Text");
            }

            return propertyInfo;
        }
    }
}
