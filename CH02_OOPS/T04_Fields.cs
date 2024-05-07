namespace CH02_OOPS;
/// <summary>
/// Fields are the variables, without get and set methods.
/// A field can be
/// 1. Read write
/// 2. Read only
/// 3. Public (not recommended) & private
/// </summary>
public class T04_Fields
{
    private int count;//read write
    private readonly int age = 10;//readonly field can be assigned with declaration
    private const float pi = 3.14f;//a const variable can be assigned during declaration only.
    public T04_Fields()
    {
        age = 10;//readonly field can be assigned in constructor
    }
    public void Test()
    {
        count = 10;//Write
        Console.WriteLine(count);//Read
        
        Console.WriteLine(age);
    }
}
