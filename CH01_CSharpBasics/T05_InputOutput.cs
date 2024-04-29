namespace CH01_CSharpBasics;

public class T05_InputOutput
{
    public void Test()
    {
        TestOutput();
    }
    public void TestInput()
    {
        var result = Console.ReadLine();//It is used to accept user input and return string when user presses Enter

        var result1 = Console.Read();//It is used to accept user input as a character and returns its ascii value when user presses enter.

        var result2 = Console.ReadKey();
    }

    public void TestOutput()
    {
        //WriteLine method prints on new line
        Console.WriteLine("Hello");
        Console.WriteLine("World");

        //Write method prints where cursor is present.
        Console.Write("Hello");
        Console.Write("World");
    }
}
