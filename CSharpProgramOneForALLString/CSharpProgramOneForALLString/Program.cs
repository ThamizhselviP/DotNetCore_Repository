using System;
using System.Linq;

using System.Globalization;

namespace CSharpProgramOneForALLString
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose program: 1 or 2");
            var input = Console.ReadLine();

            if (input == "1")
                ProgramOne.Run();
            else if (input == "2")
                ProgramTwo.Run();
            else
                Console.WriteLine("Invalid choice");

            Console.ReadLine();
        }
    }
}
