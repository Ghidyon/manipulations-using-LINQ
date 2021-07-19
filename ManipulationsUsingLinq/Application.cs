using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulationsUsingLinq
{
    public static class Application
    {
        public static void Run()
        {
            Console.WriteLine("\nBVN Enrollment App");

            bool hasSessionEnded = false;
            do
            {
                // prompt user to perform an operation
                Console.WriteLine("\nPress the matching number key to:\n1. Enroll for BVN \n2. Check BVN\n3. End");
                string option = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please input a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress the matching number key to:\n1. Enroll for BVN \n2. Check BVN\n3. End");
                    option = Console.ReadLine().Trim();
                }
                var operation = ServiceOperations.MatchOption(option);

                if (operation == BVNOperations.EnrollForBVN)
                {
                    Console.WriteLine("Enter First Name");
                    string firstName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(firstName))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid name!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                    }

                    Console.WriteLine("Enter Last Name");
                    string lastName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(lastName))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid name!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                    }

                    Console.WriteLine("Enter Middle Name");
                    string middleName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(middleName))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid name!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter Middle Name");
                        middleName = Console.ReadLine();
                    }

                    Console.WriteLine("Select your Gender:\n1. Male \n2. Female");
                    string gender = Console.ReadLine().Trim();

                    while (string.IsNullOrWhiteSpace(gender) || (gender != "1" && gender != "2"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Gender Selection");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Select your Gender using the number key: \n1. Male \n2. Female");
                        gender = Console.ReadLine().Trim();
                    }

                    Gender selectedGender = ServiceOperations.GenderSelection(gender);

                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();

                    while (!ServiceOperations.EmailRegex.IsMatch(email))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid email!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                    }

                    Console.WriteLine("Enter Date Of Birth");
                    var dob = Console.ReadLine().Trim();

                    DateTime dobValue;
                    while (string.IsNullOrWhiteSpace(dob) || !(DateTime.TryParse(dob, out dobValue)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid date!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter Date of Birth");
                        dob = Console.ReadLine();
                    }

                    DateTime dateOfBirth = DateTime.Parse(dob);

                    if ((DateTime.Now.Year - dateOfBirth.Year) < 18)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You're not eligible to enroll!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("Enter Account Number");
                        string accNumber = Console.ReadLine();

                        while (!ServiceOperations.TenDigitRegex.IsMatch(accNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a 10-digit account number!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter Account Number");
                            accNumber = Console.ReadLine();
                        }

                        ulong accountNumber = ulong.Parse(accNumber);

                        var data = Database.AccessDatabase();

                        var existingUser = data.Any(d => (d.FirstName == firstName && d.LastName == lastName && d.MiddleName == middleName) || d.AccountNumber == accountNumber);
                        if (existingUser)
                        {
                            Console.WriteLine("You cannot enroll more than once!"); 
                        }
                        else
                        {
                            long bvn = ServiceOperations.GetNextInt64();
                            Console.WriteLine(bvn);

                            User newUser = new()
                            {
                                LastName = ServiceOperations.CapitalizeFirstLetter(lastName),
                                FirstName = ServiceOperations.CapitalizeFirstLetter(firstName),
                                MiddleName = ServiceOperations.CapitalizeFirstLetter(middleName),
                                Sex = selectedGender,
                                Email = email.ToLower(),
                                DateOfBirth = dateOfBirth,
                                AccountNumber = accountNumber,
                                BVN = bvn
                            };

                            Database.AddUser(newUser);
                        }
                    }
                }
                
                if (operation == BVNOperations.CheckBVN)
                {
                    Console.WriteLine("\nEnter Account Number");
                    string number = Console.ReadLine();
                    
                    while (!ServiceOperations.TenDigitRegex.IsMatch(number))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease enter your 10-digit account number");
                        Console.ForegroundColor = ConsoleColor.White;
                        number = Console.ReadLine();
                    }
                    
                    ulong accountNumber = ulong.Parse(number);

                    string BVN = Database.RetrieveBVN(accountNumber);
                    Console.WriteLine(BVN);
                }
                
                if (operation == BVNOperations.End)
                {
                    hasSessionEnded = true;
                    Console.WriteLine("Your Session Has Ended!");
                }

            } while (!hasSessionEnded);
        }
    }
}
