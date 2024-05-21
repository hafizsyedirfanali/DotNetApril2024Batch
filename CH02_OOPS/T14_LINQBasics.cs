namespace CH02_OOPS;

/// <summary>
/// LINQ is a query language that helps in performing various operations like
/// -Where for filtering
/// -Select for selecting one or more properties/columns of dataset
/// -Count
/// -Min
/// -Max
/// -Take //Used in pagination
/// -Skip //Used in pagination
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
        ExperimentOnSingle();
    }

    public void ExperimentOnSingle()
    {
        for (int i = 0; i < 15; i++)
        {
            var student = students.Where(s => s.Id == 5).SingleOrDefault();
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
        }
    }

    public void TestSingleOrDefault()
    {
        //Single or Default will return an object if sequece/collection contains only one element
        //If sequence contains more than one elements then it will throw exception
        //if sequence contains no elements then it will return null.
        var student = students.Where(s => s.Age > 14).SingleOrDefault();
        //student will contain either data or it will throw exception "Invalid Operation Exception"
        if (student is not null)//With FirstOrDefault if is mandatory
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
    }

    public void TestSingle()
    {
        //Single or Default will return an object if sequece/collection contains only one element
        //If sequence contains more than one elements then it will throw exception
        //if sequence contains no elements then it will throw exception.
        try
        {
            var student = students.Where(s => s.Age > 14).Single();
            //with Last, try catch is mandatory
            //student will contain either data or it will throw exception "Invalid Operation Exception"
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void TestLastOrDefault()
    {
        var student = students.Where(s => s.Age > 14).LastOrDefault();
        //student will contain either data or it will throw exception "Invalid Operation Exception"
        if (student is not null)//With FirstOrDefault if is mandatory
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
    }

    public void TestLast()
    {
        try
        {
            var student = students.Where(s => s.Age > 14).Last();
            //with Last, try catch is mandatory
            //student will contain either data or it will throw exception "Invalid Operation Exception"
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void TestFirstOrDefault()
    {
        var student = students.Where(s => s.Age > 14).FirstOrDefault();
        //student will contain either data or it will throw exception "Invalid Operation Exception"
        if (student is not null)//With FirstOrDefault if is mandatory
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
    }

    public void TestFirst()
    {
        try
        {
            var student = students.Where(s => s.Age > 14).First();
            //with First, try catch is mandatory
            //student will contain either data or it will throw exception "Invalid Operation Exception"
            Console.WriteLine($"ID = {student.Id} Name = {student.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void TestDistinct()
    {
        var genders = students.Select(s => s.Gender).Distinct().ToList();
        foreach (var gender in genders)
        {
            Console.WriteLine(gender);
        }
    }

    public void TestMax()
    {
        var max = students.Max(s => s.Id);
    }

    public void TestMin()
    {
        var min = students.Min(x => x.Age);
    }

    public void TestCount()
    {
        var count = students.Count(s => s.Id > 2);
    }

    public void TestSelectWhere()
    {
        var studentList = students
            .Where(s => s.Name.Contains('o'))//filtered rows
            .Select(s => new { s.Id, s.Name }).ToList();//selected columns
        foreach (var student in studentList)
        {
            Console.WriteLine($"ID = {student.Id} & Name = {student.Name}");
        }
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