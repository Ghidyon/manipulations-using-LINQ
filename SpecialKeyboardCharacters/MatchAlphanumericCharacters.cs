using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SpecialKeyboardCharacters
{
    public static class MatchAlphanumericCharacters
    {
        public static void Run()
        {
            Dictionary<char, int> charactersDictionary = new()
            {
                { ')', 1 },
                { '(', 2 },
                { '*', 3 },
                { '&', 4 },
                { '^', 5 },
                { '%', 6 },
                { '$', 7 },
                { '#', 8 },
                { '@', 9 },
                { '!', 0 }
            };

            Console.WriteLine("\nInput any of the following characters [!, ), (, *, &, ^, %, $, #, @] to match the numbers 0 - 9");
            string input = Console.ReadLine().Trim();
            Regex regex = new Regex(@"^[\*|\&|\(|\)|\^|\%|\$|\#|\@|\!]+$");

            while (string.IsNullOrEmpty(input) || !regex.IsMatch(input))
            {
                Console.WriteLine("Please enter a valid input!");
                Console.WriteLine("\nInput any of the following characters [!, ), (, *, &, ^, %, $, #, @], to match the numbers 0 - 9");
                input = Console.ReadLine().Trim();
                input = regex.IsMatch(input) ? input : null;
            }

            string outputQuery = null;
            string outputMethod = null;

            foreach (char c in input)
            {
                var querySyntax = from value in charactersDictionary
                                  where value.Key == c
                                  select value.Value;

                foreach (var value in querySyntax)
                {
                    outputQuery += value;
                }

                var methodSyntax = charactersDictionary.Where(value => value.Key == c);

                foreach (var value in methodSyntax)
                {
                    outputMethod += value.Value;
                }
            }

            Console.WriteLine($"\nOutput Using Query Syntax: {outputQuery}");
            Console.WriteLine($"\nOutput Using Method Syntax: {outputMethod}");
        }
    }
}
