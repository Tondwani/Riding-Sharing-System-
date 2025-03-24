using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Utilities
{
    public static class InputHelper
    {
        // Get string input from the user
        public static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        // Get integer input from the user
        public static int GetIntegerInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        // Get decimal input from the user
        public static decimal GetDecimalInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
        }

        // Get yes/no input from the user
        public static bool GetYesNoInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (y/n): ");
                string input = Console.ReadLine()?.ToLower() ?? string.Empty;
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                if (input == "n" || input == "no")
                {
                    return false;
                }
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }
    }
}
