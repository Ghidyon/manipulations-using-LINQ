using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulationsUsingLinq
{
    public static class Database
    {
        private static List<User> _Users = new();

        public static void AddUser(User user)
        {
            _Users.Add(user);
            Console.WriteLine("User Successfully Enrolled!");
            Console.WriteLine("Your BVN is: " + user.BVN);
        }

        public static string RetrieveBVN(ulong accountNumber)
        {
            bool IsFound = _Users.Any(user => user.AccountNumber == accountNumber);

            if (IsFound)
            {
                var bvn = (from user in _Users
                        where user.AccountNumber == accountNumber
                        select user.BVN).ToList();
                return string.Join("", bvn);
            }
            return "You do not have a BVN, please enroll!";
        }

        public static bool IsExistingUser(string lastName, string firstName, string middleName, ulong accountNumber)
        {
            return _Users.Any(user => (user.FirstName == firstName && user.LastName == lastName && user.MiddleName == middleName)
            || user.AccountNumber == accountNumber);
        }
    }
}
