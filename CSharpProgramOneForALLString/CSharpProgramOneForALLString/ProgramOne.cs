using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgramOneForALLString
{
    class ProgramOne
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("     String Practice Program   ");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Reverse the String.");
                Console.WriteLine("2. Check Palindrome.");
                Console.WriteLine("3. Count Vowels and Consonents");
                Console.WriteLine("4. Remove Extra Space and Capitalize (Your Example)");
                Console.WriteLine("5. Find Longest Word");
                Console.WriteLine("6. Count Word Frequency");
                Console.WriteLine("7. Exit");
                Console.Write("\n Enter your choose from (1-7): ");

                string choice = Console.ReadLine()!;
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ReverseString();
                        break;
                    case "2":
                        CheckPalindrome();
                        break;
                    case "3":
                        CountVowelsAndConsonents();
                        break;
                    case "4":
                        RemoveSpaceAndCapitalize();
                        break;
                    case "5":
                        FindLongestWord();
                        break;
                    case "6":
                        WordFrequency();
                        break;
                    case "7":
                        Console.WriteLine("Exiting the Programs...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ReverseString()
        {
            Console.Write("Enter a String: ");
            string input = Console.ReadLine()!;
            string reversed = new string(input.Reverse().ToArray());
            Console.WriteLine($"Reversed String : {reversed}");

        }

        static void CheckPalindrome()
        {
            Console.Write("Enter a String: ");
            string input = Console.ReadLine()!;
            string cleaned = new string(input.ToLower().Where(char.IsLetterOrDigit).ToArray());
            string reversed = new string(cleaned.Reverse().ToArray());
            Console.WriteLine(cleaned == reversed ? "The Given string is Palindrome" : "The Given string is Not Palindrome");
        }

        static void CountVowelsAndConsonents()
        {
            Console.Write("Enter a String: ");
            string input = Console.ReadLine()!.ToLower();
            int vowels = input.Count(c => "aeiou".Contains(c));
            int consonents = input.Count(c => char.IsLetter(c) && !"aeiou".Contains(c));
            Console.WriteLine($"No of Vowels : {vowels} , No of Consonents : {consonents} ");
        }

        static void RemoveSpaceAndCapitalize()
        {
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine()!;
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var reversedWords = words.Reverse();

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            var capitalized = reversedWords.Select(w => textInfo.ToTitleCase(w.ToLower()));
            string result = string.Join(" ", capitalized);

            Console.WriteLine($"Formatted Result: {result}");
        }

        static void FindLongestWord()
        {
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine()!;
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string longest = words.OrderByDescending(w => w.Length).FirstOrDefault()!;
            Console.WriteLine($"Longest Word: {longest}");
        }

        static void WordFrequency()
        {
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine()!.ToLower();
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var frequency = words.GroupBy(w => w)
                                 .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine("\nWord Frequency:");
            foreach (var item in frequency)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }


    }
}
