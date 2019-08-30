using System;
using System.IO;
using Base.Architecture.UserManagement.Models;
using Xunit;

namespace Base.Architecture.UserManagement.Tests
{
    public class UserManagementTests
    {
        private readonly string db_dir;
        private readonly User dummyUser;

        public UserManagementTests()
        {
            db_dir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "test.db");

            dummyUser = new User
            {
                Username = "DummyUserName",
                Name = "DummyName",
                LastName = "DummyLastName"
            };
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_User_Creation_Without_Logging_In()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            Assert.Throws<Exception>(() => userManagement.StoreUser(dummyUser, "password"));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Find_User_Without_Logging_In()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            Assert.Throws<Exception>(() => userManagement.FindUser(UserManagementCore.Field.Username, "admin"));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Update_User_Without_Logging_In()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            Assert.Throws<Exception>(() => userManagement.UpdateUser(dummyUser));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Update_User_Password_Without_Logging_In()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "new password"));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Be_Created_With_An_Admin_Account()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            Assert.NotNull(userManagement.LogIn("admin", "admin"));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Allow_Store_New_User_After_Login()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");
            userManagement.StoreUser(dummyUser, "P@ssw0rd");
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Allow_Find_User_After_Login()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");
            userManagement.StoreUser(dummyUser, "P@ssw0rd");

            Assert.NotNull(userManagement.FindUser(UserManagementCore.Field.Username, dummyUser.Username));
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Allow_Update_User_After_Login()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");
            userManagement.StoreUser(dummyUser, "P@ssw0rd");
            dummyUser.Name = "UpdateDummyName";

            userManagement.UpdateUser(dummyUser);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Empty_Password()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, " "));
            Assert.Equal("Password should not be empty", exception.Message);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Lower_Character()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "P@SSW0RD"));
            Assert.Equal("Password should contain At least one lower case letter", exception.Message);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Uppercase_Character()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "p@ssw0rd"));
            Assert.Equal("Password should contain At least one upper case letter", exception.Message);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_With_Less_Than_8_Character()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "P@ssw0r"));
            Assert.Equal("Password should not be less than 8 characters", exception.Message);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Numeric_Characters()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "P@ssword"));
            Assert.Equal("Password should contain At least one numeric value", exception.Message);
            userManagement.CloseConnection();
        }

        [Fact]
        public void UserManagement_Should_Not_Allow_Passwords_Without_A_Special_Characters()
        {
            File.Delete(db_dir);
            var userManagement = new UserManagementCore(db_dir);
            userManagement.LogIn("admin", "admin");

            var exception = Assert.Throws<Exception>(() => userManagement.UpdatePassword(dummyUser, "Passw0rd"));
            Assert.Equal("Password should contain At least one special case characters", exception.Message);
            userManagement.CloseConnection();
        }
    }
}
