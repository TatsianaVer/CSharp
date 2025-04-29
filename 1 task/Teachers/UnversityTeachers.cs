using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTeachers
{
    class Programm
    {
        static void Run()
        {
            try
            {
                var teachers = UniversityDataProcessor.inputTeachers().ToList();

                Console.WriteLine("\nAll teachers by department:");
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
                Console.WriteLine($"Critical error: {ex.Message}");
            }
        }
    }
}
