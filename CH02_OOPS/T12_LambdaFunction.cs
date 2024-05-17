namespace CH02_OOPS;

/// <summary>
/// It is a function without name, so it can only be called using delegate.
/// </summary>
public class T12_LambdaFunction
{
    public void Test()
    {
    }

    public void TestAnonymousFunction()
    {
        Func<int, int, int> func1 = delegate (int x, int y) { return x + y; };
    }

    public void TestLambdaFunction()
    {
        Greet();

        var action = Greet;
        action.Invoke();

        //Parameterless lambda function returning void.
        action = () =>
        {
            Console.WriteLine("Hello from lambda function");
        };
        action.Invoke();

        //Parameterless lambda function returning int.
        var func1 = () => { return 0; };
        func1 = () => 1;

        //Parameterized lambda functions
        //Single int parameter
        //following are three different allowed versions of lambda function.
        var func2 = (int x) => { return x; };
        Func<int, int> func21 = (x) => { return x; };
        func2 = (x) => x;
        func2 = (x) => new Random().Next(0, x);//Example
        func2 = x => ++x;

        //Two int parameters
        Func<int, int, int> func3 = (x, y) =>
        {
            return x + y;
        };
        func3 = (x, y) => x + y;

        //Two Complex Parameters
        Func<LambdaClass, LambdaClass, int> func4 = (x, y) => 10;
        Func<int, int, LambdaClass> func5 = (x, y) => new LambdaClass();

        Predicate<int> pred1 = (x) => true;
        pred1(10);

        Predicate<int?> isEven = (int? x = 10) => x % 2 == 0;
        isEven(11);
    }

    public int Method2(int x, int y)
    {
        return x + y;
    }

    public int Method1(int x)
    { return x; }

    public void Greet()
    {
        Console.WriteLine("Hello from a function/method");
    }
}

public class LambdaClass
{
    public int MyProperty1 { get; set; }
    public float MyProperty2 { get; set; }
    public string MyProperty3 { get; set; }
}