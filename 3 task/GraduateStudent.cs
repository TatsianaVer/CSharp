public class GraduateStudent : Student
{
    private const double MinimumGrade = 3.0;

    public GraduateStudent(string name) : base(name) { }

    public override double CalculateGpa()
    {
        double totalGradePoints = 0.0;
        double totalCredits = 0.0;

        foreach (var course in Courses)
        {
            if (course.Grade < MinimumGrade) continue;
            totalGradePoints += course.Grade * course.Credit;
            totalCredits += course.Credit;
        }

        return totalCredits == 0 ? 0 : totalGradePoints / totalCredits;
    }
}
