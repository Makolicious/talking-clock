using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talking_clock
{
    class Program
    {
        private static string[] ones = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine","Ten",
                                        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

        private static string[] tens = {"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty"};

        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Enter a time in the format <hh>:<mm>");
            int timeHour;
            int timeMinute;
            bool isMorning = true;
            string timeOutput = "The time is ";
            string userInput = Console.ReadLine();

            try
            {
                timeHour = Int32.Parse(userInput.Substring(0,2));
                timeMinute = Int32.Parse(userInput.Substring(3));
                if (Enumerable.Range(0,23).Contains(timeHour) && Enumerable.Range(0,59).Contains(timeMinute))
                {
                    if (timeHour >= 12 && timeHour != 24)
                    {
                        timeHour -= 12;
                        isMorning = false;
                    }
                    else if (timeHour == 0 || timeHour == 24)
                    {
                        timeHour = 12;
                    }

                    timeOutput += ones[timeHour];

                    if (timeMinute == 0)
                    {
                        timeOutput += " O'Clock";
                    }
                    Console.WriteLine(timeOutput);
                    goto start;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid", e);
                goto start;
            }

            
        }
    }
}
