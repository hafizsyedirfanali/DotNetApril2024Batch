namespace CH02_OOPS;
/// <summary>
/// Constructors are like methods without return type.
/// The primary task of a constructor is to create instance of a class
/// We can associate some task within a constructor.
/// We can have multiple constructors like 
/// parameterless (default)(hidden/visible), parameterized(visible).
/// We can have constructor overloading by different signatures/definations
/// We can achieve dependency injection using constructor
/// We have Copy Constructor used to duplicate the class instance with values (Rarely Used due to DRY principle)
/// We have private constructor used to create instance of the class from within the class only.
/// </summary>
public class T02_Constructors
{
    public void Test()
    {
        //Calling private Constructor
        T02_Constructors t = new T02_Constructors(10, "Student", new T02_Constructors());
    }
    public int Age { get; set; }
    public string Name { get; set; }
    public T02_Constructors Obj {  get; }
    private T02_Constructors(int age, string name, T02_Constructors obj)
    {
        this.Age = age;
        this.Name = name;
    }
    public T02_Constructors()//default/parameterless constructor
    {
        //When we do not specify any constructor for a class
        //compiler creates a hidden default constructor for it.
        //if we create any constructor (parameterless or parameterized)
        //then compiler will not create any constructor.
    }
    public T02_Constructors(string name)
    {

    }
    public T02_Constructors(string name, string address)
    {
        
    }
    public T02_Constructors(string name, int age)
    {

    }
    public T02_Constructors(int age, string name)
    {

    }
    public T02_Constructors(T02_Constructors obj)//Copy Constructor
    {
        Obj = obj;
        this.Age = obj.Age;
        this.Name = obj.Name;
    }
}
