namespace CH02_OOPS;

/// <summary>
/// A delegate is a function/method pointer.
/// </summary>
public class T10_Delegates
{
    /// <summary>
    /// In the following function, "Test" is a pointer which holds
    /// address of the function.
    /// </summary>
    ///
    public delegate int ArithmaticDelegate(int x, int y);//Defination

    public void Test()
    {
        //Declaration/Instantiation of a delegate
        ArithmaticDelegate myDelegate = Add;
        var result = myDelegate.Invoke(10, 3);//Calling method1
        result = myDelegate(10, 3);//Calling method2

        myDelegate = Subtraction;
        result = myDelegate(10, 3);//will call subtract method

        myDelegate = Divide;
        result = myDelegate(10, 3);//will call divide method

        myDelegate = Multiplication;
        result = myDelegate(10, 3);//will call multiply method

        ///MULTIDELEGATE
        ArithmaticDelegate multiDelegate = Add;
        multiDelegate += Subtraction;
        multiDelegate += Divide;
        multiDelegate += Multiplication;
        //Invoking Multidelegate
        result = multiDelegate.Invoke(10, 3);
    }

    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtraction(int a, int b)
    {
        return a - b;
    }

    public int Divide(int a, int b)
    {
        return a / b;
    }

    public int Multiplication(int a, int b)
    {
        return a * b;
    }
}