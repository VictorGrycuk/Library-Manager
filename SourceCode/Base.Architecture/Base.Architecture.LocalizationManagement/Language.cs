using System;
using System.Collections.Generic;

namespace Base.Architecture.LocalizationManagement
{
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
