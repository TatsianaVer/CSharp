using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Errors
    {
        public static void ShowError(string message)
        {
            Console.WriteLine($"\nError: {message}");
        }

        public static void HoldScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
