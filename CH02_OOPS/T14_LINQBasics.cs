namespace CH02_OOPS;

/// <summary>
/// LINQ is a query language that helps in performing various operations like
/// -Where for filtering
/// -Select for selecting one or more properties/columns of dataset
/// -Count
/// -Min
/// -Max
/// -Take
/// -Skip
/// -First
/// -FirstOrDefault
/// -Last
/// -LastOrDefault
/// -Single
/// -SingleOrDefalut
/// -Distinct
/// </summary>
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

    public void TestSelect()
    {
        //Selecting single column/property of data set
        var studentIdList = students.Select(SelectorMethod).ToList();
        studentIdList = students.Select(s => s.Id).ToList();
        var studentNameList = students.Select(s => s.Name).ToList();

        //Selecting multiple columns of data set
        var studentList = students.Select(s => new { s.Id, s.Name }).ToList();

        //Selecting multiple columns using another class
        var subStudentList = students
            .Select(s => new SubStudent() { Id = s.Id.ToString(), StudentName = s.Name })
            .ToList();
        subStudentList = students
            .Select(s => new SubStudent(s.Id.ToString(), s.Name))
            .ToList();
    }

    public class SubStudent
    {
#pragma warning disable

        public SubStudent()
        {
        }

#pragma warning restore

        public SubStudent(string id, string name)
        {
            this.Id = id;
            this.StudentName = name;
        }

        public string Id { get; set; }
        public string StudentName { get; set; }
    }

    public int SelectorMethod(Student student)
    {
        return student.Id;
    }

    public void TestWhere()
    {
        //Where is a filtering method and requires a function
        //Filtering from a list
        var studentList = students.Where(FilteringFunction).ToList();
        studentList = students.Where(s => s.Age > 12).ToList();
        studentList = students.Where(s => s.Name.Contains('o')).ToList();
        studentList = students.Where(s => s.Name.Length == 6 && s.Name.Contains('o')).ToList();
        //Called Function is Where Method
    }

    public bool FilteringFunction(Student student)
    {
        return student.Age > 12;
    }
}