using System;
using System.Collections.Generic;
using System.IO;
using Base.Architecture.DatabaseManager;
using Base.Architecture.UserManagement;
using Base.Architecture.UserManagement.Models;
using Base.Architecture.MultiLanguageManager;
using Xunit;

namespace Base.Architecture.Tests
{
    public class MultilanguageTests
    {
        private readonly DBManager _dbManager;
        private readonly UserManagementCore _userManagement;
        private readonly User _dummyUser;

        public MultilanguageTests()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            var dbDir = string.Empty;
            if (directoryInfo != null)
            {
                dbDir = Path.Combine(directoryInfo.FullName, this + ".db");

                if (File.Exists(dbDir))
                {
                    File.Delete(dbDir);
                }
            }

            _dbManager = new DBManager(dbDir);
            _userManagement = new UserManagementCore(_dbManager);

            _dummyUser = new User
            {
                Username = "DummyUserName",
                Name = "DummyName",
                LastName = "DummyLastName"
            };
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_User_Creation_Without_Logging_In()
        {
            var manager = new Multilanguage(_dbManager);
            var language = new Language("en-us");
            language.Controls.Add("test", "test") ; //= controls;

            manager.Add(language);
            var test = manager.Find("en-us");
            _dbManager.Dispose();
        }
    }
}
