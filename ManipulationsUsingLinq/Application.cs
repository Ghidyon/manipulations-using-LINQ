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
            Console.WriteLine("BVN Enrollment App\n");

            bool hasSessionEnded = false;
            do
            {
                // prompt user to perform an operation
                Console.WriteLine("Press the matching number key to\n1. Enroll for BVN \n2. Check BVN\n3. End");
                string option = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(option) || (option != "1" && option != "2" && option != "3"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please input a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press the matching number key to\n1. Enroll for BVN \n2. Check BVN");
                    option = Console.ReadLine().Trim();
                }
                var operation = ServiceOperations.MatchOption(option);

                if (operation == BVNOperations.EnrollForBVN)
                {

                }
                
                if (operation == BVNOperations.CheckBVN)
                {

                }
                
                if (operation == BVNOperations.End)
                {
                    hasSessionEnded = true;
                }

            } while (!hasSessionEnded);
        }
    }
}
