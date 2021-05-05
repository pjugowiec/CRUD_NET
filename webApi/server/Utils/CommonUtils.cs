using System;
using System.Security.Cryptography;
using System.Text;

namespace server.Utils
{
    public static class CommonUtils
    {


        // <summary>Calculate the age based on the date</summary>
        // <param name="date">Date from which the age will be calculated</param>
        // <returns>Number of years</returns>
        public static int CalculateAge(DateTime date)
        {
            return DateTime.Now.Year - date.Year;
        }

        // <summary>Compare passwords</summary>
        // <param name="newPassword">Argument of type String containing the password from the DTO</param>
        // <param name="oldPassword">Argument of type String containing the password from the user</param>
        // <returns>True if password are the same, if not false</returns>
        public static bool CheckPasswordsSame(string newPassword, string oldPassword)
        {
            return newPassword == oldPassword;
        }

    }
}
