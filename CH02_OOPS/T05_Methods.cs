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
        //Call by Reference using "in"
        int i = 10; int j = 20;
        var result = Add(in i,in j);//the input i and j are readonly and cannot be written or modified

        //Call by reference using "out"
        GetRandomNumber(out int resultRandom);//the input resultRandom can be red but it must be written before exiting the method
        int anotherResultRandom = 10;
        GetRandomNumber(out anotherResultRandom);
        Console.WriteLine(resultRandom);

        //Call by reference using "ref"
        string name = "Akash";
        GetUpperCase(ref name);//the input "name" can be red and written.

        //Calling method with mandatory parameter
        MethodWithMandatoryParameter(10);

        //Calling method with optional parameters
        MethodWithNullableOptionalParameters(10);//second - nullable optional parameter
        MethodWithNonNullableOptionalParameters(10);//second - non nullable optional parameter
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

    public void GetUpperCase(ref string input)
    {
        input = input.ToUpper();
    }

    public void MethodWithMandatoryParameter(int i)
    {

    }
   
    public void MethodWithNullableOptionalParameters(int i, int? j = null)//second parameter is nullable optional parameter
    {

    }
    public void MethodWithNonNullableOptionalParameters(int i, int j = 0)//Second parameter is non nullable optional and set to 0
    {

    }
    
}
