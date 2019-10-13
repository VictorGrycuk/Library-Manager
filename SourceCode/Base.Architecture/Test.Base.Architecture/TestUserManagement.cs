using System;
using System.IO;
using Base.Architecture.DatabaseManager;
using Base.Architecture.UserManagement;
using Base.Architecture.UserManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace Test.Base.Architecture
{
    [TestClass]
    public class TestUserManagement
    {
        private readonly DBManager _dbManager;
        private readonly UserManager _userManagement;
        private readonly User _dummyUser;

        public TestUserManagement()
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
            _userManagement = new UserManager(_dbManager);

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
            Assert.Throws<UnauthorizedAccessException>(() => _userManagement.StoreUser(_dummyUser, "password"));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Find_User_Without_Logging_In()
        {
            Assert.Throws<UnauthorizedAccessException>(() => _userManagement.FindUser(UserManager.Field.Username, "admin"));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Update_User_Without_Logging_In()
        {
            Assert.Throws<UnauthorizedAccessException>(() => _userManagement.UpdateUser(_dummyUser));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Update_User_Password_Without_Logging_In()
        {
            Assert.Throws<UnauthorizedAccessException>(() => _userManagement.UpdatePassword(_dummyUser, "new password"));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Be_Created_With_An_Admin_Account()
        {
            Assert.NotNull(_userManagement.LogIn("admin", "admin"));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Allow_Store_New_User_After_Login()
        {
            _userManagement.LogIn("admin", "admin");
            _userManagement.StoreUser(_dummyUser, "P@ssw0rd");
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Allow_Find_User_After_Login()
        {
            _userManagement.LogIn("admin", "admin");
            _userManagement.StoreUser(_dummyUser, "P@ssw0rd");

            Assert.NotNull(_userManagement.FindUser(UserManager.Field.Username, _dummyUser.Username));
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Allow_Update_User_After_Login()
        {
            _userManagement.LogIn("admin", "admin");
            _userManagement.StoreUser(_dummyUser, "P@ssw0rd");
            _dummyUser.Name = "UpdateDummyName";

            _userManagement.UpdateUser(_dummyUser);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Empty_Password()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, " "));
            Assert.Equal("Password should not be empty", exception.Message);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Lower_Character()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, "P@SSW0RD"));
            Assert.Equal("Password should contain At least one lower case letter", exception.Message);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Uppercase_Character()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, "p@ssw0rd"));
            Assert.Equal("Password should contain At least one upper case letter", exception.Message);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_With_Less_Than_8_Character()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, "P@ssw0r"));
            Assert.Equal("Password should not be less than 8 characters", exception.Message);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Numeric_Characters()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, "P@ssword"));
            Assert.Equal("Password should contain At least one numeric value", exception.Message);
            _dbManager.Dispose();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Special_Characters()
        {
            _userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<FormatException>(() => _userManagement.UpdatePassword(_dummyUser, "Passw0rd"));
            Assert.Equal("Password should contain At least one special case characters", exception.Message);
            _dbManager.Dispose();
        }
    }
}
