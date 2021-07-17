using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine("Input any of the following characters [ ), (, *, &, ^, %, $, #, @, ! ]");
            string input = Console.ReadLine();
            List<int> output = new();

            foreach (char c in input)
            {
                output.Add(charactersDictionary[c]);
            }

            Console.WriteLine($"\nOutput: { string.Join("", output) }");
        }
    }
}
