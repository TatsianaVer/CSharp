using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        // Пример использования
        var undergrad = new UndergraduateStudent("Alice");
        undergrad.AddCourse("Mathematics", 3, 4.0);
        undergrad.AddCourse("Physics", 4, 3.5);
        Console.WriteLine($"Undergraduate GPA: {undergrad.CalculateGpa():F2}"); // 3.71

        var phd = new PhdStudent("Bob");
        phd.AddCourse("Research Project", 6, 4.0);
        phd.AddCourse("Seminar", 2, 3.8);
        Console.WriteLine($"PhD GPA: {phd.CalculateGpa():F2}"); // 4.00
    }
}
