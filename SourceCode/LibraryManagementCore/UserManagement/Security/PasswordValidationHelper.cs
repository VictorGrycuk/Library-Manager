using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Base.Architecture.UserManagement.Security
{
    internal static class PasswordValidationHelper
    {
        public static void ValidatePassword(string password)
        {
            var input = password;
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasLowerChar = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasNumber = new Regex(@"[0-9]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                errorMessages.Add("Password should contain At least one lower case letter");
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                errorMessages.Add("Password should contain At least one upper case letter");
            }
            else if (password.Length < 8)
            {
                errorMessages.Add("Password should not be less than 8 characters");
            }
            else if (!hasNumber.IsMatch(input))
            {
                errorMessages.Add("Password should contain At least one numeric value");
            }
            else if (!hasSymbols.IsMatch(input))
            {
                errorMessages.Add("Password should contain At least one special case characters");
            }

            if (errorMessages.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
