using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Course
{
    public string Name { get; }
    public double Credit { get; }
    public double Grade { get; }

    public Course(string name, double credit, double grade)
    {
        Name = name;
        Credit = credit;
        Grade = grade;
    }
}
