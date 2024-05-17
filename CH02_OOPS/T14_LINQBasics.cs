namespace CH02_OOPS;

public class T14_LINQBasics
{
    private List<Student> students;

    public T14_LINQBasics()
    {
        students = new List<Student>()
        {
            //In-Memory Collection
            new Student{Id = 1, Name = "Fisrt", Age = 11, Gender="M"},
            new Student{Id = 2, Name = "Second", Age = 12, Gender="F"},
            new Student{Id = 3, Name = "Third", Age = 13, Gender="M"},
            new Student{Id = 4, Name = "Fourth", Age = 14, Gender="F"},
        };
    }

    public void Test()
    {
        TestWhere();
    }

    public void TestWhere()
    {
        //Filtering from a list
        var studentList = students.Where(FilteringFunction).ToList();
        studentList = students.Where(s => s.Age > 12).ToList();
        //Called Function is Where Method
    }

    public bool FilteringFunction(Student student)
    {
        return student.Age > 12;
    }
}