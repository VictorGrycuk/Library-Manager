using Base.Architecture.DatabaseManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Base.Architecture.MultiLanguageManager
{
    public class Multilanguage
    {
        public Language Language;
        private readonly TableManager<Language> _db;

        public Multilanguage(DBManager dbManager)
        {
            _db = dbManager.NewTableConnection<Language>();
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

    public class Language
    {
        public Guid Id { get; set; }
        public string LanguageTag { get; set; }
        public Dictionary<string, string> Controls { get; set; }

        public Language() { Controls = new Dictionary<string, string>(); }

        public Language(string languageTag)
        {
            LanguageTag = languageTag;
            Controls = new Dictionary<string, string>();
        }

        public string GetText(string controlName)
        {
            return Controls[controlName];
        }
    }
}
