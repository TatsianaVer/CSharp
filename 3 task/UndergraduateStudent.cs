using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UndergraduateStudent : Student
{
    public UndergraduateStudent(string name) : base(name) { }

    public override double CalculateGpa()
    {
        double totalGradePoints = 0.0;
        double totalCredits = 0.0;

        foreach (var course in Courses)
        {
            totalGradePoints += course.Grade * course.Credit;
            totalCredits += course.Credit;
        }

        return totalCredits == 0 ? 0 : totalGradePoints / totalCredits;
    }
}

