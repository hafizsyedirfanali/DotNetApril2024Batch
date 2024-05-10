namespace CH02_OOPS;

/// <summary>
/// A collection is of generic type.
/// The primary collection is an Array.
/// The examples of collection is
/// 1. Array - CH01-T07
/// 2. List
/// 3. Queue
/// 4. Stack
/// 5. Tuple
/// 6. ICollection
/// 7. IList
/// 8. IEnumerable
/// 9. IQuerable
/// </summary>
public class T09_Collections
{
    public void Test()
    {
        TestList();
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
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}