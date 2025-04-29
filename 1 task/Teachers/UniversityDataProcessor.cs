using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTeachers
{
    public static class UniversityDataProcessor
    {
        public static IEnumerable<Teacher> inputTeachers()
        {
            var teachers = new List<Teacher>();

            Console.WriteLine("Enter teacher data (type 'exit' to finish):");
            while (true)
            {
                try
                {
                    Console.Write("Last name: ");
                    var lastName = Console.ReadLine();
                    if (string.Equals(lastName, "exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    Console.Write("Department: ");
                    var department = Console.ReadLine();
                    if (string.Equals(department, "exit", StringComparison.OrdinalIgnoreCase))

                        Console.Write("Enter monthly workload (10 space-separated numbers): ");
                    var workloadInput = Console.ReadLine()?.Split(' ');

                    if (workloadInput?.Length != 10)
                    {
                        throw new FormatException("Exactly 10 numbers required");
                    }

                    var workLoad = workloadInput.Select(int.Parse).ToArray();

                    teachers.Add(new Teacher(lastName, department, workLoad));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Please try again.");
                }
            }
            return teachers;
        }

        public static void PrintTeachersByDepartment(IEnumerable<Teacher> teachers)
        {
            var grouped = teachers.OrderBy(t => t.Department).ThenBy(t => t.LastName).GroupBy(t => t.Department);

            foreach (var departmentGroup in grouped)
            {
                Console.WriteLine($"\nDepartment: {departmentGroup.Key}");
                foreach (var teacher in departmentGroup)
                {
                    Console.WriteLine($"- {teacher.LastName}: Annual workLoad {teacher.AnnualWorkLoad} hours");
                }
            }
        }

        public static Dictionary<string, double> CalculateAverageFirstTwoMonths(IEnumerable<Teacher> teachers)
        {
            return teachers.GroupBy(t => t.Department).ToDictionary(g => g.Key, g => g.Average(t => (t[0] + t[1]) / 2.0));
        }

        public static IEnumerable<Teacher> FindTeachersAboveAverage(IEnumerable<Teacher> teachers, double universityAverage)
        {
            return teachers.Where(t => t.MounthlyWorkload.Any(h => h > universityAverage));
        }

        public static double CalculateUniversityAverage(IEnumerable<Teacher> teachers)
        {
            var totalHours = teachers.Sum(t => t.MounthlyWorkload.Sum());
            var totalMonths = teachers.Count() * 10;
            
            return totalMonths > 0 ? (double)totalHours/ totalMonths : 0;
        }
    }
}
