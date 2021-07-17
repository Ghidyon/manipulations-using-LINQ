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
            List<string> words = new List<string> { "lorem", "ipsum", "john", "doe", "lazy", "brown", "fox", "dinner", "nipple", "obi", "cubana" };
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
    }
}
