namespace CH02_OOPS;

/// <summary>
/// A delegate is a function/method pointer.
/// Main Application of Delegate is to have call back function.
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
        CallingFunction();
    }
    public void TestCustomDelegate()
    {
        //Declaration/Instantiation of a delegate
        ArithmaticDelegate myDelegate = Addition;
        var result = myDelegate.Invoke(10, 3);//Calling method1
        result = myDelegate(10, 3);//Calling method2

        myDelegate = Subtraction;
        result = myDelegate(10, 3);//will call subtract method

        myDelegate = Division;
        result = myDelegate(10, 3);//will call divide method

        myDelegate = Multiplication;
        result = myDelegate(10, 3);//will call multiply method

        ///MULTIDELEGATE
        ArithmaticDelegate multiDelegate = Addition;
        multiDelegate += Subtraction;
        multiDelegate += Division;
        multiDelegate += Multiplication;
        //multiDelegate -= Divide;//This is to remove the address of divide method from the delegate.
        
        //Invoking Multidelegate
        result = multiDelegate.Invoke(10, 3);
    }
    #region Arithmatic Methods
    public int Addition(int a, int b)
    {
        Console.WriteLine(a + b);
        return a + b;
    }

    public int Subtraction(int a, int b)
    {
        Console.WriteLine(a - b);
        return a - b;
    }

    public int Division(int a, int b)
    {
        Console.WriteLine(a / b);
        return a / b;
    }

    public int Multiplication(int a, int b)
    {
        Console.WriteLine(a * b);
        return a * b;
    }
    #endregion
    //----------CALL BACK FUNCTIONS
    public void TestCallBackFunction() //Caller method
    {       
        DoArithmaticOperation(10, 3, Addition);//in this method, Addition is a call back function
        //which will be called from called function.
        DoArithmaticOperation(10, 3, Subtraction);//subtraction is callback function
        DoArithmaticOperation(10, 3, Multiplication);//multiplication is callback function
        DoArithmaticOperation(10, 3, Division);//division is call back function
    }

    //--------------CALLED METHODS-----------------------------
    public void DoArithmaticOperation(int a, int b, ArithmaticDelegate d)//Called method
    {        
        d.Invoke(a, b);//call back function/method is called
    }
    //Call back function is heavily used in LINQ

    //ANother example of Call back function
    public void CallingFunction()
    {
        LongRunningOperation(PrintMethod);
    }
    public void PrintMethod(int i)
    {
        Console.WriteLine($"Status is {i}");
    }

    ////---------------------------
    public delegate void PrintDelegate(int count);
    public void LongRunningOperation(PrintDelegate statusDelegate)
    {
        int i = 15;
        while (i>0)
        {
            Thread.Sleep(1000);
            statusDelegate.Invoke(i);
            i--;
        }
    }
}