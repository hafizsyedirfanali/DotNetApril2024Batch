namespace CH02_OOPS;
/// <summary>
/// A struct can be created with struct keyword.
/// Mostly it is similar with class/// 
/// A struct is a blueprint.
/// Struct Names must be in UpperCamelCase
/// A struct is a collection of 
/// 1. Constructor (Compulsory - Hidden)
/// 2. Properties
/// 3. Fields
/// 4. Methods
/// 5. Nested struct
/// 6. Class
/// </summary>
public struct T07_Structure
{
    public void Test()
    {
        T07_Structure t = new T07_Structure();//Instantiated with default hidden constructor
        var t1 = new T07_Structure(10);//Instantiated with parameterized constructor.
    }
    //Constructors - overloading of constructor is also possible
    public T07_Structure(int i)
    {
        
    }
    //Methods - Methods overloading is possible
    public int Add(int i, int j)
    {
        return i + j;
    }
    //Fields
    private int count = 0;

    //properties
    public int MyProperty { get; set; }

    //nested struct
    public struct NestedStruct
    {

    }
    //class
    public class NestedClass
    {

    }
    //~T07_Structure() //As it is a valued type - destructor not required
    //{

    //}
}
