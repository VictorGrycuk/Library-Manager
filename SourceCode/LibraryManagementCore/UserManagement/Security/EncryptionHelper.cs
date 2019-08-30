using System;
using System.Security.Cryptography;
using System.Text;

namespace Base.Architecture.UserManagement.Security
{
    internal static class EncryptionHelper
    {
        private static byte[] GenerateSalt(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return Encoding.ASCII.GetBytes(sb.ToString());
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static byte[] HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedHash = Combine(Encoding.ASCII.GetBytes(password), GenerateSalt(password));

                return sha256.ComputeHash(combinedHash);
            }
        }

        public static bool ComparePasswords(string inputPassword, string storedPassword)
        {
            return Convert.ToBase64String(HashPassword(inputPassword)) == storedPassword;
        }
    }
}
