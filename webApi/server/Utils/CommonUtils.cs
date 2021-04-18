using System;
using System.Security.Cryptography;
using System.Text;

namespace server.Utils
{
    public static class CommonUtils
    {
        public static int CalculateAge(DateTime date)
        {
            return DateTime.Now.Year - date.Year;
        }

        public static bool CheckPasswordsSame(string newPassword, string oldPassword)
        {
            return newPassword == oldPassword;
        }

    }
}
