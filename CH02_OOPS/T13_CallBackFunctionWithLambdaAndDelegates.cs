namespace CH02_OOPS;

public class T13_CallBackFunctionWithLambdaAndDelegates
{
    public void Test()
    {
        TestCallBackFunction();
    }

    public void TestCallBackFunction()
    {
        CalledFunction((s) =>
        {
            Console.WriteLine(s);
        });
        CalledFunction(s => Console.WriteLine(s));
        CalledFunction(Console.WriteLine);

        IncrementMethod(x => ++x, 10);

        var result = ArithmaticMethod((x, y) => x + y, 10, 11); Console.WriteLine(result); ;
    }

    /// <summary>
    /// Following function is asking for a function address/reference
    /// that may be called and passed a string parameter and that will
    /// print the passed message
    /// </summary>
    /// <param name="printDelegate"></param>
    public void CalledFunction(Action<string> printDelegate)
    {
        printDelegate.Invoke("Message");
    }

    public int IncrementMethod(Func<int, int> func, int number)
    {
        var result = func.Invoke(number);
        return result;
    }

    public int ArithmaticMethod(Func<int, int, int> func, int x, int y)
    {
        var result = func.Invoke(x, y);
        return result;
    }
}