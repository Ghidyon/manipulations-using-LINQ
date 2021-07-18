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
        }

        public static string RetrieveBVN(ulong accountNumber)
        {
            /*var querySyntax = (from user in _Users
                              where user.AccountNumber where
                              select user.BVN).ToString();*/
            //return querySyntax;
            //var querySyntax = (from user in _Users
            //                   select user.AccountNumber);
            //var accountNumbers = (from accNumbers in querySyntax
            //                     where accNumbers.Contains(accountNumber)
            //                     select querySyntax);
            //return accountNumbers.ToString();
            return "";
        }
    }
}
