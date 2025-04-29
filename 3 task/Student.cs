

public abstract class Student
{
    private readonly List<Course> _courses = new List<Course>();
    public string Name { get; }

    protected Student(string name) => Name = name;

    public void AddCourse(string name, double credit, double grade)
        => _courses.Add(new Course(name, credit, grade));

    public abstract double CalculateGpa();

    protected IEnumerable<Course> Courses => _courses;
}
