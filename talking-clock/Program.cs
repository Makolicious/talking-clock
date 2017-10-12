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

        private static string[] tens = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty" };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a time in the format <hh>:<mm>");

        start:
            int timeHour;
            int timeMinute;
            int stringLength = 5;
            bool isMorning = true;
            string timeOutput = "The time is ";
            string userInput = Console.ReadLine();

            try
            {
                if (userInput.Length != stringLength || userInput.Contains(":") == false)
                {
                    Console.WriteLine("Please enter a valid time in the format <hh>:<mm>");
                    goto start;
                }
                else
                {
                    timeHour = Int32.Parse(userInput.Substring(0, 2));
                    timeMinute = Int32.Parse(userInput.Substring(3));

                    if (Enumerable.Range(0, 23).Contains(timeHour) && Enumerable.Range(0, 59).Contains(timeMinute))
                    {
                        if (timeHour >= 12 && timeHour != 24)
                        {
                            timeHour -= 12;
                            isMorning = false;
                        }
                        else if (timeHour == 0 || timeHour == 24)
                            timeHour = 12;

                        timeOutput += ones[timeHour];

                        if (timeMinute == 0)
                            timeOutput += " O'Clock";
                        else if (Enumerable.Range(1, 9).Contains(timeMinute))
                            timeOutput += " oh " + ones[timeMinute];
                        else if (Enumerable.Range(10, 19).Contains(timeMinute))
                            timeOutput += " " + ones[timeMinute];
                        else if (Enumerable.Range(20, 59).Contains(timeMinute))
                            if (timeMinute % 10 == 0)
                                timeOutput += " " + tens[timeMinute / 10];
                            else
                                timeOutput += " " + tens[(timeMinute - (timeMinute % 10)) / 10] + " " + ones[timeMinute % 10];
                    }

                    if (isMorning != true)
                        timeOutput += " PM.";
                    else
                        timeOutput += " AM.";

                    Console.WriteLine(timeOutput);
                    goto start;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid time in the format <hh>:<mm>");
                goto start;
            }
        }
    }
}