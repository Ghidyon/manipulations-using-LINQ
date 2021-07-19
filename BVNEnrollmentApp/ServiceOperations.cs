using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace BVNEnrollmentApp
{
    public static class ServiceOperations
    {
        public static readonly Regex NameRegex = new(@"^[a-zA-z]+$");
        public static readonly Regex TenDigitRegex = new(@"^\d{10}$");
        public static readonly Regex EmailRegex = new(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        //public static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");

        public static BVNOperations MatchOption(string option)
        {
            return option switch
            {
                "1" => BVNOperations.EnrollForBVN,
                "2" => BVNOperations.CheckBVN,
                "3" => BVNOperations.End,
                _ => BVNOperations.ChooseOptions
            };
        }

        public static Gender GenderSelection(string gender)
        {
            return gender switch
            {
                "1" => Gender.Male,
                "2" => Gender.Female,
                _ => Gender.SelectGender
            };
        }

        public static string CapitalizeFirstLetter(string word)
        {
            string newWord = word.ToLower();
            return char.ToUpper(newWord[0]) + newWord.Substring(1);
        }

        public static long GetNextInt64()
        {
            var bytes = new byte[sizeof(Int64)];
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
            Gen.GetBytes(bytes);

            long random = BitConverter.ToInt64(bytes, 0);

            //Remove any possible negative generator numbers and shorten the generated number to 11-digits
            string pos = random.ToString().Replace("-", "").Substring(0, 11);

            return Convert.ToInt64(pos);
        }

        public static string PromptUser(string field, string hint)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{hint}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{field}");
            return Console.ReadLine().Trim();
        }
    }
}
