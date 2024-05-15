namespace CH02_OOPS;

/// <summary>
/// There are three standard delegates, all of them are generic and have multiple overloads, except predicate
/// 1. Action - It is used with those functions that do not return any value (return type = void)
/// 2. Func
/// 3. Predicate
/// </summary>
public class T11_StandardDelegates
{
    public void Test()
    {
        TestPredicateDelegate();
    }

    #region ACTION DELEGATE

    public void TestActionDelegate()
    {
        //in specifies the type of input parameter and out specifies the return type
        Action<int> action = MethodForActionDelegate; action.Invoke(10);
        Action<int, int> action1 = MethodForActionDelegate; action1.Invoke(10, 20);
    }

    public void MethodForActionDelegate(int a)
    { }

    public void MethodForActionDelegate(int a, int b)
    { }

    #endregion ACTION DELEGATE

    #region FUNC DELEGATE

    public void TestFuncDelegate()
    {
        Func<int> func1 = GenerateANumber;
        var num = func1.Invoke();
        Func<int, int> func2 = IncrementNumber;
    }

    public int GenerateANumber()
    { return new Random().Next(0, 100); }

    public int IncrementNumber(int number)
    { return ++number; }

    #endregion FUNC DELEGATE

    #region PREDICATE DELEGATE

    public void TestPredicateDelegate()
    {
        //Predicate has a strict return type of boolean
        Predicate<int> predicate = IsNumberEven;
        var result = predicate.Invoke(4);
        Console.WriteLine(result);
    }

    public bool IsNumberOdd(int number)
    {
        return number % 2 != 0;//Logic for odd number
    }

    public bool IsNumberEven(int number)
    {
        return number % 2 == 0;//Logic for even number
    }

    #endregion PREDICATE DELEGATE

    #region Action Delegate as a Call back function

    public void ActionCallerFunction()
    {
        ActionCalledFunction(ActionPrintMethod, "Greetings");
    }

    public void ActionPrintMethod(string message)
    {
        Console.WriteLine(message);
    }

    public void ActionCalledFunction(Action<string> print, string message)
    {
        print.Invoke(message);
    }

    #endregion Action Delegate as a Call back function

    #region Func Delegate as a call back function

    public void FuncCallerFunction()
    {
        FuncCalledFunction(GenerateAnyNumber);
    }

    public int GenerateAnyNumber()
    {
        return 0;
    }

    public void FuncCalledFunction(Func<int> func)
    {
        func.Invoke();
    }

    #endregion Func Delegate as a call back function

    #region Predicate Delegate as a call back function

    public void PredicateCallerFunction()
    {
        PredicateCalledFunction(IsNumberEven, 10);
        PredicateCalledFunction(IsNumberOdd, 10);
    }

    public void PredicateCalledFunction(Predicate<int> predicate, int number)
    {
        var result = predicate.Invoke(number);
        Console.WriteLine($"Result:{result}");
    }

    #endregion Predicate Delegate as a call back function
}