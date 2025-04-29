using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PhdStudent : Student
{
    private const double ResearchWeight = 1.5;

    public PhdStudent(string name) : base(name) { }

    public override double CalculateGpa()
    {
        double totalWeightedPoints = 0.0;
        double totalWeightedCredits = 0.0;

        foreach (var course in Courses)
        {
            var weight = course.Name.StartsWith("Research") ? ResearchWeight : 1.0;
            totalWeightedPoints += course.Grade * course.Credit * weight;
            totalWeightedCredits += course.Credit * weight;
        }

        return totalWeightedCredits == 0 ? 0 : totalWeightedPoints / totalWeightedCredits;
    }
}

