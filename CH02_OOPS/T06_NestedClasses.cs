namespace CH02_OOPS;
/// <summary>
/// Nested Classes are the classes defined within the class
/// The class within the namespace is called TYPE which is different from the class within class
/// The difference lies within access.[access modifiers]
/// </summary>
public class T06_NestedClasses
{
    public void Test()
    {
        T06_NestedClasses t2 = new T06_NestedClasses();
        //t2.NestedClass - a nested class cannot be accessed from object of its home class

        //Inner class members can only be accessed after creating instance of member's home class.
        //following use of . operator specifies FULLY QUALIFIED NAMESPACE
        T06_NestedClasses.NestedClass t = new T06_NestedClasses.NestedClass();
        t.NestedClassProperty = 10;

        T06_NestedClasses.NestedClass.Nested1Class t1 = new();
        t1.Nested1ClassProperty = 10;
    }
    public class NestedClass
    {
        public int NestedClassProperty { get; set; }
        public class Nested1Class
        {
            public int Nested1ClassProperty { get; set; }
        }
    }
}
