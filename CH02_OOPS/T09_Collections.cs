namespace CH02_OOPS;

/// <summary>
/// A collection is of generic type.
/// The primary collection is an Array.
/// The examples of collection is
/// 1. Array - CH01-T07
/// 2. List
/// 3. Queue
/// 4. Stack
/// 5. Tuple - Used to return multiple objects
/// 6. ICollection
/// 7. IList
/// 8. IEnumerable
/// 9. IQuerable
/// </summary>
public class T09_Collections
{
    public void Test()
    {
        var result = TestTuple(new Student() { Id = 1, Name = "AA", Age = 11 });
        var result1 = ReturnSingleObject(new Student() { Id = 1, Name = "AA", Age = 11 });
    }

    public void TestList()
    {
        //Valued Type List
        List<int> list = new List<int>() { 1, 2, 3 };

        list.Add(1);

        var list2 = new List<int>() { 10, 20, 30 };
        list.AddRange(list2);
        //Reference Type
        List<string> strings = new List<string>() { "Hello", "World" };

        strings.Add("Next Item");

        List<string> strings1 = new List<string>() { "First", "Second", "Third" };
        strings.AddRange(strings1);

        //Complex Reference type
        Student s1 = new Student() { Age = 1, Id = 1, Name = "AAA" };
        Student s2 = new Student() { Age = 4, Id = 2, Name = "BBB" };
        Student s3 = new Student() { Age = 5, Id = 3, Name = "CCC" };
        List<Student> students = new List<Student>() { s1, s2, s3 };
        students.Add(s1);

        List<Student> students1 = new List<Student>();
        students1.AddRange(students);
        students1.Add(s3);

        List<Student> students2 = students1;//Student2 will refer same list
        students2.Add(s1);
    }

    public void TestQueue()
    {
        Student s1 = new Student() { Age = 1, Id = 1, Name = "AAA" };
        Student s2 = new Student() { Age = 4, Id = 2, Name = "BBB" };
        Student s3 = new Student() { Age = 5, Id = 3, Name = "CCC" };

        Queue<Student> queue = new Queue<Student>();
        queue.Enqueue(s1);
        queue.Enqueue(s2);
        queue.Enqueue(s3);

        var s11 = queue.Dequeue();
        var s12 = queue.Dequeue();
        var s13 = queue.Dequeue();
        bool isSuccess = queue.TryDequeue(out Student? s14);
        queue.Enqueue(s1);
    }

    public void TestStack()
    {
        Student s1 = new Student() { Age = 1, Id = 1, Name = "AAA" };
        Student s2 = new Student() { Age = 4, Id = 2, Name = "BBB" };
        Student s3 = new Student() { Age = 5, Id = 3, Name = "CCC" };
        Stack<Student> stack = new Stack<Student>();
        stack.Push(s1);
        stack.Push(s2);
        stack.Push(s3);

        var s21 = stack.Pop();
        var s22 = stack.Pop();
        var s23 = stack.Pop();
        bool isSuccess = stack.TryPop(out Student? s24);
    }

    public (int Id, string Name, int Age) TestTuple(Student student)
    {
        return (student.Id, student.Name, student.Age);
        //return (1, "Hello", 12);
    }

    public Student ReturnSingleObject(Student student)
    {
        //return new Student()
        //{
        //    Name = student.Name,
        //    Id = student.Id,
        //    Age = student.Age
        //};
        return student;
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}