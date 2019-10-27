using Base.Architecture.DatabaseManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace LibraryManagementCore
{
    public class DatabaseIntegrity
    {
        private readonly TableManager<DatabaseStatus> _db;
        private readonly Dictionary<string, DatabaseStatus> _registeredDatabases = new Dictionary<string, DatabaseStatus>();

        public DatabaseIntegrity(DBManager dbConfiguration)
        {
            _db = dbConfiguration.NewTableConnection<DatabaseStatus>();
        }

        public void RegisterNewDB(string name, string path)
        {
            // Either get the one stored or create a new one
            var status = _db.Find("Name", name).FirstOrDefault() ?? new DatabaseStatus
            {
                Id = Guid.NewGuid(),
                Name = name,
                Path = path,
                Hash = SHA256CheckSum(path)
            };


            _registeredDatabases.Add(name, status);
        }

        public void SaveDatabaseHash(string name)
        {
            var status = _db.Find("Name", name).FirstOrDefault();

            // If it exists, we simply update its hash and update the record
            if (status != null)
            {
                status.Hash = SHA256CheckSum(status.Path);
                _db.Update(status);
            }

            // If it doesn't exist, we use the one we initially stored, update its hash, and store it
            else
            {
                status = _registeredDatabases[name];
                status.Hash = SHA256CheckSum(status.Path);
                _db.Add(status);
            }
        }

        public bool CheckIntegrity(string name)
        {
            return _registeredDatabases[name].Hash == SHA256CheckSum(_registeredDatabases[name].Path);
        }

        public bool Exists(string name)
        {
            return _db.Exists("Name", name);
        }

        public static string SHA256CheckSum(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(sha256.ComputeHash(fileStream));
            }
        }
    }

    public class DatabaseStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
    }
}
