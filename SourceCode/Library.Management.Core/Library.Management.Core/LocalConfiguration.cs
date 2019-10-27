using System.IO;
using Newtonsoft.Json;

namespace LibraryManagementCore
{
    public class LocalConfiguration
    {
        public string ApplicationSettings { get; set; }
        public string Database { get; set; }
        public string Localization { get; set; }

        public LocalConfiguration()
        { }

        public LocalConfiguration(string filePath)
        {
            var config = JsonConvert.DeserializeObject<LocalConfiguration>(File.ReadAllText(filePath));
            ApplicationSettings = config.ApplicationSettings;
            Database = config.Database;
            Localization = config.Localization;
        }

        public void SaveToFile(string filePath)
        {
            var output = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
