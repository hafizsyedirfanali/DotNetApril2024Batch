namespace CH02_OOPS;
/// <summary>
/// A method is a collection of instructions that can return a value and
/// that will be executed when this method is called.
/// A method can be parameterized and non-parameterized.
/// A method can be called by 1) value & 2) reference
/// we can overload the methods.
/// </summary>
public class T05_Methods
{
    public void Test()
    {
        var result = Add(10, 20);
        GetRandomNumber(out int resultRandom);
        Console.WriteLine(resultRandom);
    }
    public void ParameterlessMethod()
    {

    }
    public void Parameterized(int i)
    {

    }
    public void Parameterized(int i, int j)//overload
    {

    }
    public void Parameterized(int i, int j, int k)//overload
    {

    }

    ///CALL BY VALUE    
    public int Sum(int a, int b)
    {
        return a + b;
    }
    ///CALL BY REFERENCE
    ///1. using in keyword
    ///2. using out keyword
    ///3. using ref keyword

    //in Keyword
    public int Add(in int a, in int b)
    {
        return a + b;
    }

    public void GetRandomNumber(out int i)
    {
        i = new Random().Next(100, 1000);
    }
    public int GetRandomNumber()
    {
        return new Random().Next();
    }
}
