using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNEnrollmentApp
{
    public static class Database
    {
        private static List<User> _Users = new();
        private static IEnumerable<User> _BannedUsers()
        {
            return new List<User>{
                new User{LastName = "Richards", FirstName = "James", MiddleName = "Walter", Sex = Gender.Male,
                        Email = "jamesrichards@gmail.com", DateOfBirth = new DateTime(17/4/1992), AccountNumber = 0054721651, BVN = 22232348971 },
                new User{LastName = "Thomas", FirstName = "Bill", MiddleName = "Johnson", Sex = Gender.Male,
                        Email = "billthomas@gmail.com", DateOfBirth = new DateTime(7/6/1994), AccountNumber = 3241548830, BVN = 57490879673 },
                new User{LastName = "Rodgers", FirstName = "Jane", MiddleName = "Annabel", Sex = Gender.Female,
                        Email = "janerodgers@gmail.com", DateOfBirth = new DateTime(11/11/1995), AccountNumber = 2759980234, BVN = 66226226842 },
            };
        }

        public static void AddUser(User user)
        {
            _Users.Add(user);
            Console.WriteLine("\nUser Successfully Enrolled!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your BVN is: " + user.BVN);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static string RetrieveBVN(ulong accountNumber)
        {
            var bvn = (from user in _Users
                       where user.AccountNumber == accountNumber
                       select user.BVN).ToList();

            var bannedUser = (from user in _BannedUsers()
                              where user.AccountNumber == accountNumber
                              select new
                              {
                                  LastName = user.LastName,
                                  FirstName = user.FirstName,
                                  MiddleName = user.MiddleName,
                                  AccountNumber = user.AccountNumber,
                                  Email = user.Email
                              });

            if (bvn != null && bvn.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string displayBVN = string.Join("", bvn);
                return $"Your BVN: {displayBVN}";
            }
            else if (bannedUser != null && bannedUser.Any())
            {
                // raise an event , fire alarm, send EMAIL to CBN
                string lastName = "";
                string firstName = "";
                string middleName = "";
                ulong accountNo = 0;
                string email = "";

                foreach (var model in bannedUser)
                {
                    lastName = model.LastName;
                    firstName = model.FirstName;
                    middleName = model.MiddleName;
                    accountNo = model.AccountNumber;
                    email = model.Email;
                }

                var bannedUserModel = new Events.EventArgsModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName[0],
                    AccountNumber = accountNo,
                    Email = email
                };

                var notify = new Events.Event();

                //Subscription
                notify.SendEmail += Events.EventHandler.DetailsOfSentEmail;

                notify.RunEvent(bannedUserModel);

                Console.ForegroundColor = ConsoleColor.Red;
                return "Your account is restricted!";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "You do not have a BVN, please enroll!";
        }

        public static bool IsExistingUser(string lastName, string firstName, string middleName, ulong accountNumber)
        {
            bool isExistingUser = _Users.Any(user => (user.FirstName == firstName && user.LastName == lastName && user.MiddleName == middleName)
            || user.AccountNumber == accountNumber);
            bool isExistingBannedUser = _BannedUsers().Any(user => (user.FirstName == firstName && user.LastName == lastName && user.MiddleName == middleName)
            || user.AccountNumber == accountNumber);

            return (isExistingUser || isExistingBannedUser);
        }
    }
}
