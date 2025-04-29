using System;
using System.Linq;
using Variant11;
using UniversityTeachers;
using Menu;
using UniversityTeachers;
namespace Menu
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Run Array Processing (First Program)");
                Console.WriteLine("2. Run University Teachers Analysis (Second Program)");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                // Read users choice
                switch (Console.ReadLine())
                {
                    case "1":
                        RunArrayProcessing(); 
                        break;
                    case "2":
                        RunUniversityTeachers(); 
                        break;
                    case "3":
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        Errors.HoldScreen(); 
                        break;
                }
            }
        }

        // Using arrays
        private static void RunArrayProcessing()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Running Array Processing...");

                var arrayA = new ArrayManager();
                Console.WriteLine("Input array A:");
                arrayA.ReadFromInput();

                var arrayB = new ArrayManager();
                Console.WriteLine("Input array B:");
                arrayB.ReadFromInput();

                int[] arrayC = ArrayProcessor.GenerateArrayC(arrayA, arrayB);
                Console.WriteLine($"Generated array C: {string.Join(" ", arrayC)}");
            }
            catch (Exception ex)
            {
                Errors.ShowError(ex.Message); 
            }
            Errors.HoldScreen(); 
        }

        // teachers analyzer
        private static void RunUniversityTeachers()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Running University Teachers Analysis...");

                var teachers = UniversityDataProcessor.inputTeachers().ToList();
                UniversityDataProcessor.PrintTeachersByDepartment(teachers);

                var departmentAverages = UniversityDataProcessor.CalculateAverageFirstTwoMonths(teachers);
                Console.WriteLine("\nAverage workload for first two months by department:");

                foreach (var (department, avg) in departmentAverages)
                {
                    Console.WriteLine($"{department}: {avg:F1} hours");
                }

                var universityAverage = UniversityDataProcessor.CalculateUniversityAverage(teachers);
                Console.WriteLine($"\nUniversity monthly average: {universityAverage:F1} hours");

                var aboveAverageTeachers = UniversityDataProcessor.FindTeachersAboveAverage(teachers, universityAverage);
                Console.WriteLine("\nTeachers above university average:");
                if (aboveAverageTeachers.Any())
                {
                    foreach (var teacher in aboveAverageTeachers)
                    {
                        Console.WriteLine($"{teacher.LastName} ({teacher.Department})");
                    }
                }
                else
                {
                    Console.WriteLine("No teachers exceed the university average workload.");
                }
            }
            catch (Exception ex)
            {
                Errors.ShowError(ex.Message); // Show an error
            }
            Errors.HoldScreen(); // Pause
        }
    }
}
