using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ManipulationsUsingLinq
{
    public static class Manipulations
    {
        public static void Run()
        {

            // Query that shuffles sorted list of words
            List<string> words = new() { "lorem", "ipsum", "john", "doe", "lazy", "brown", "fox", "dinner", "nipple", "obi", "cubana" };
            Console.WriteLine($"List of Words: { string.Join(", ", words)}");

            var random = new Random();

            Console.WriteLine("\nMethod Syntax");
            var methodSyntax = words.OrderBy(word => random.Next());
            Console.WriteLine($"Random List of Words: {string.Join(", ", methodSyntax)}");

            Console.WriteLine("\nQuery Syntax");
            var querySyntax = from word in words
                              orderby random.Next()
                              select word;
            Console.WriteLine($"Random List of Words: {string.Join(", ", querySyntax)}");
        }

        public static void MatchAlphanumericCharacters()
        {
            Dictionary<char, int> charactersDictionary = new()
            {
                {')', 1 },
                {'(', 2 },
                {'*', 3 },
                {'&', 4 },
                {'^', 5 },
                {'%', 6 },
                {'$', 7 },
                {'#', 8 },
                {'@', 9 },
                {'!', 0 }
            };

            Console.WriteLine("\nInput any of the following characters [ ), (, *, &, ^, %, $, #, @, ! ]");
            string input = Console.ReadLine().Trim();
            Regex regex = new Regex(@"\b(\D\W\S[\*|\&|\(|\)|\^|\%|\$|\#|\@|\!])");
            while (string.IsNullOrEmpty(input) || !regex.IsMatch(input))
            {
                Console.WriteLine("Please enter a valid input!");
                Console.WriteLine("\nInput any of the following characters [ ), (, *, &, ^, %, $, #, @, ! ]");
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
