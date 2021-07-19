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
                Console.WriteLine("\nPress the matching number key to:\n1. Enroll for BVN \n2. Check BVN\n3. End");
                string option = Console.ReadLine().Trim();

                while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3"))
                {
                    option = ServiceOperations.PromptUser("Press the matching number key to:\n1. Enroll for BVN" +
                        "\n2. Check BVN\n3. End", "Please input a valid number").Trim();
                }

                var operation = ServiceOperations.MatchOption(option);

                if (operation == BVNOperations.EnrollForBVN)
                {
                    Console.WriteLine("\nEnter First Name");
                    string firstName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(firstName))
                    {
                        firstName = ServiceOperations.PromptUser("Enter First Name", "Please enter a valid name!");
                    }

                    Console.WriteLine("\nEnter Last Name");
                    string lastName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(lastName))
                    {
                        lastName = ServiceOperations.PromptUser("Enter Last Name", "Please enter a valid name!");
                    }

                    Console.WriteLine("\nEnter Middle Name");
                    string middleName = Console.ReadLine();

                    while (!ServiceOperations.NameRegex.IsMatch(middleName))
                    {
                        middleName = ServiceOperations.PromptUser("Enter Middle Name", "Please enter a valid name!");
                    }

                    Console.WriteLine("\nSelect your Gender:\n1. Male \n2. Female");
                    string gender = Console.ReadLine().Trim();

                    while (string.IsNullOrWhiteSpace(gender) || (gender != "1" && gender != "2"))
                    {
                        gender = ServiceOperations.PromptUser("Select your Gender using the number key: \n1. Male \n2. Female", "Invalid Gender Selection");
                    }

                    Gender selectedGender = ServiceOperations.GenderSelection(gender);

                    Console.WriteLine("\nEnter Email");
                    string email = Console.ReadLine();

                    while (!ServiceOperations.EmailRegex.IsMatch(email))
                    {
                        email = ServiceOperations.PromptUser("Enter Email", "Please enter a valid email!");
                    }

                    Console.WriteLine("\nEnter Date Of Birth");
                    var dob = Console.ReadLine().Trim();

                    DateTime dobValue;
                    while (string.IsNullOrWhiteSpace(dob) || !(DateTime.TryParse(dob, out dobValue)))
                    {
                        dob = ServiceOperations.PromptUser("Enter date of birth", "Please enter a valid date");
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
                        Console.WriteLine("\nEnter Account Number");
                        string accNumber = Console.ReadLine();

                        while (!ServiceOperations.TenDigitRegex.IsMatch(accNumber))
                        {
                            accNumber = ServiceOperations.PromptUser("Enter Account Number", "Please enter a 10-digit account number!");
                        }

                        ulong accountNumber = ulong.Parse(accNumber);

                        bool existingUser = Database.IsExistingUser(lastName, firstName, middleName, accountNumber);
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
