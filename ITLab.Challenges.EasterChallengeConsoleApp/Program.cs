using ITLab.Challenges.EasterChallengeInfra;
using ITLab.Challenges.EasterChallengeModels;
using ITLab.Challenges.EasterChallengeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLab.Challenges.EasterChallengeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor original = Console.ForegroundColor;

            Console.WriteLine("\nInform a year so the calculator can show us on which day Easter Bunny showed up.");
            string year = Console.ReadLine();

            int year_ = 0;
            if (!int.TryParse(year.ToString(), out year_))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dude, I was expecting only numbers here. Try again, you can do better.");
                Console.ForegroundColor = original;

                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                return;
            }

            Calculator calculator = new Calculator();
            Result calculate = calculator.Calculate(year_);

            if(calculate.IsSuccessful)
            {
                EasterDateSummary summary = (EasterDateSummary)calculate.Return;

                Console.WriteLine("Date: " + summary.EasterDatePortugueseShort);
                Console.WriteLine("Date (detailed): " + summary.EasterDatePortugueseLong);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(calculate.ErrorMessage);
                Console.ForegroundColor = original;
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
