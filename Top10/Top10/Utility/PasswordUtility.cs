using System;
using System.Linq;
using System.Text;
using Top10.BLL;

namespace Top10.Utility
{
    public static class PasswordUtility
    {
        private static UserManager _userManager;
        private static UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        public static string GetUniqueRandomPassword(int length = 7)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";
            var stringBuilder = new StringBuilder();
            var random = new Random();
            string password;
            do
            {
                stringBuilder.Clear();
                while (0 < length--)
                    stringBuilder.Append(allowedChars[random.Next(allowedChars.Length)]);
                password = stringBuilder.ToString();
                password.ToList().Shuffle();
            } while (UserManager.IsPasswordExists(password));
            return password;
        }
    }
}