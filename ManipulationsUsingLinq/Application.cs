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
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();

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
                    Console.WriteLine(accountNumber);

                    // parse a/c number to query database for bvn
                    //string BVN = Database.RetrieveBVN(accountNumber);
                    //if (BVN.Any())
                    //{
                    //    Console.WriteLine($"BVN: {BVN}");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("You do not have a BVN, please enroll!");
                    //}
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
