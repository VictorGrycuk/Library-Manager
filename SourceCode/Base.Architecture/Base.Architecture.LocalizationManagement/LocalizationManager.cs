using System.Collections.Generic;
using System.IO;
using System.Linq;
using Base.Architecture.DatabaseManager;
using Newtonsoft.Json;

namespace Base.Architecture.LocalizationManagement
{
    public class LocalizationManager
    {
        public Language Language;
        private readonly TableManager<Language> _db;

        public LocalizationManager(DBManager dbManager)
        {
            _db = dbManager.NewTableConnection<Language>();

            // We add a default localization if there is nothing
            if (!_db.GetAll().Any())
            {
                Add(GetDefaultLanguage());
            }
        }

        private static Language GetDefaultLanguage()
        {
            var serializedLanguage = System.Text.Encoding.Default.GetString(Properties.Resources.DefaultLocalization);

            return JsonConvert.DeserializeObject<Language>(serializedLanguage);
        }

        public void Add(Language language)
        {
            _db.Add(language);
        }

        public Language Find(string languageCode)
        {
            return _db.Find("LanguageTag", languageCode).FirstOrDefault();
        }

        public void Update(Language language)
        {
            _db.Update(language);
        }

        public void SetLanguage(string languageCode)
        {
            Language = Find(languageCode);
        }

        public void SetLanguage(Language language)
        {
            Language = language;
        }

        public IEnumerable<Language> GetAll()
        {
            return _db.GetAll();
        }

        public void Export(string filePath, Language language)
        {
            var output = JsonConvert.SerializeObject(language, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }

        public void Import(string filePath)
        {
            var import = JsonConvert.DeserializeObject<Language>(File.ReadAllText(filePath));

            if (_db.Exists("LanguageTag", import.LanguageTag))
            {
                var temp = _db.Find("LanguageTag", import.LanguageTag).FirstOrDefault();
                _db.Delete(temp);
            }

            _db.Add(import);
        }
    }
}
