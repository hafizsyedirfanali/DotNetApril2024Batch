namespace CH02_OOPS;

/// <summary>
/// Class is a blueprint.
/// Class Names must be in UpperCamelCase
/// A class is a collection of
/// 1. Constructor (Compulsory - Hidden)
/// 2. Properties
/// 3. Fields
/// 4. Methods
/// 5. Nested Classes
/// 6. Structs
/// 7. Destructor (Compulsory - Hidden)
/// 8. Records - Immutable record of data
/// </summary>
public class T01_Classes
{
    public class StudentRecordClass
    {
        public StudentRecordClass(string firstName, string lastName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public record StudentRecord(string FirstName, string LastName);//this is an immutable alternative option of a class

    public void TestRecord()
    {
        var student = new StudentRecord("Hello", "World");
        //student.FirstName = "UpdatedName";//record is an immutable collection of data and cannot be updated because of init.

        var student1 = new StudentRecordClass("FirstName", "LastName");
        student1.FirstName = "UpdatedName";
    }

    public void Test()
    {
        ClassWithProperties p = new ClassWithProperties();
        ClassWithProperties p1 = p;
        ClassWithProperties p2 = new ClassWithProperties();
        T02_Constructors c = new T02_Constructors(new T02_Constructors());
        //Creating an instance of T02_Constructor class with properties
        T02_Constructors c1 = new T02_Constructors()
        {
            Age = 10,
            Name = "Student"
        };
        T02_Constructors c2 = new T02_Constructors(c1);
    }

    public class ClassWithHiddenConstructor
    {
    }

    public class ClassWithVisibleConstructor
    {
        public ClassWithVisibleConstructor()//This is a constructor
        {
            //here we can add set of instructions that will be
            //executed at the time of creation of class instance.
        }
    }

    public class ClassWithProperties
    {
        public int MyProperty1 { get; set; }
        public string? MyProperty2 { get; set; }
        public bool MyProperty3 { get; set; }
    }

    public class ClassWithFields
    {
        private int i;
        private string? s;
    }

    public class ClassWithMethods
    {
        public void Method1()
        {
        }
    }

    public class ClassWithNestedClass
    {
        public class NestedClass
        {
        }
    }

    public class ClassWithStruct
    {
        public struct MyStruct
        {
        }
    }

    public class ClassWithHiddenDestructor
    {
        //In this class destructor is present but hidden
    }

    public class ClassWithVisibleDestructor
    {
        ~ClassWithVisibleDestructor()//This is a destructor
        {
            //here we can add set of instructions that will be
            //executed at the time of removal of class instance.
            //Now a days we don't use it, as we have better options like try-catch-finally or using
        }
    }
}