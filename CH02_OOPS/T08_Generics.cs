namespace CH02_OOPS;
/// <summary>
/// Generics is a feature in c# that allows us to make a class or method, etc general.
/// A generic class allows user to pass one or more types during its instantiation.
/// A generic method allows user to pass one or more types during its call.
/// </summary>
public class T08_Generics
{
    ///GENERIC METHODS
    public void TestGenericMethods()
    {
        AGenericMethod<int>(10);
        AGenericMethod<string>("Hello");
        AGenericMethod<int, float, bool>(10, 1.3f, true);
    }
    public void AGenericMethod<T>(T value)
    {
        
    }
    //public T AnotherGenericMethod<T>(string value)
    //{
    //    T obj = (T);
    //    return obj;
    //}
    public void AGenericMethod<T1,T2,T3>(T1 value1, T2 value2, T3 value3)
    {
        Console.WriteLine(value1);
        Console.WriteLine(value2);
        Console.WriteLine(value3);
    }

    //----------------------------------------------------
    /// <summary>
    /// GENERIC CLASSES
    /// </summary>
    public void TestGenericClass()
    {
        T08_Generics.AGenericClass<int> obj = new AGenericClass<int>();
        obj.IntProperty = 1;
        obj.GenericProperty = 1;
        T08_Generics.AGenericClass<string> obj1 = new AGenericClass<string>();
        obj1.GenericProperty = "Hello";

        var obj2 = new T08_Generics.AnotherGenericClass<int, int, int>();
        obj2.MyProperty1 = 1;
        obj2.MyProperty2 = 1;
        obj2.MyProperty3 = 1;
        var obj3 = new T08_Generics.AnotherGenericClass<int, float, string>();
        obj3.MyProperty1 = 1;
        obj3.MyProperty2 = 1.3f;
        obj3.MyProperty3 = "Hello";

        var obj4 = new T08_Generics.AnotherGenericClass<T08_Generics, T08_Generics, T08_Generics>();
        obj4.MyProperty1 = new T08_Generics();
        obj4.MyProperty2 = new T08_Generics();
        obj4.MyProperty3 = new T08_Generics();
    }
    public class AGenericClass<T>
    {
        public int IntProperty { get; set; }
        public T GenericProperty { get; set; }
    }

    public class AnotherGenericClass<T1, T2, T3>
    {
        public T1 MyProperty1 { get; set; }
        public T2 MyProperty2 { get; set; }
        public T3 MyProperty3 { get; set; }
    }
}
