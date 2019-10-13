using System;
using Base.Architecture.UserManagement.Security;

namespace Base.Architecture.UserManagement.Models
{
    internal class DetailedUser : User
    {
        public string Password { get; set; }
        public Guid ID { get; set; }

        public void SetPassword(string password)
        {
            var encryptedPassword = EncryptionHelper.HashPassword(password);

            Password = Convert.ToBase64String(encryptedPassword);
        }

        public bool ValidatePassword(string password)
        {
            return EncryptionHelper.ComparePasswords(password, Password);
        }
    }

    public static class ExtensionMethods
    {
        internal static User ToUser(this DetailedUser detailedUser)
        {
            return new User
            {
                Username = detailedUser.Username,
                Name = detailedUser.Name,
                LastName = detailedUser.LastName,
                DateCreated = detailedUser.DateCreated,
                LastAccessed = detailedUser.LastAccessed
            };
        }
    }
}
