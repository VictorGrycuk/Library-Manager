using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Modules.UserManagement
{
    public class User
    {
        public string Password { get; set; }
        public byte[] Salt { private get; set; }
        public Guid ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public void SetPassword(string password)
        {
            Salt = EncryptionHelper.GenerateSalt();
            var encryptedPassword = EncryptionHelper.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), Salt);

            Password = Convert.ToBase64String(encryptedPassword);
        }

        public bool ValidatePassword(string password)
        {
            var tempPassword = EncryptionHelper.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), Salt);

            return Convert.ToBase64String(tempPassword) == Password;
        }
    }
}
