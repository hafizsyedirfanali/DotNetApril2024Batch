namespace CH01_CSharpBasics;

public class T06_Loops
{
    public void Test()
    {
        ForEach();
    }
    public void DoWhile()
    {
        int counter = 0;
        do
        {
            Console.WriteLine("Do while loop");
            counter++;
        }
        while(counter < 10);
    }

    public void While()
    {
        int counter = 0;
        while(counter < 10)
        {
            Console.WriteLine($"While loop {counter}");
            counter++;
        }
    }

    public void ForLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("For loop {0}",i);
        }   
    }

    public void ForEach()
    {
        int[] rollNos = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        foreach (var rollNo in rollNos)
        {
            Console.WriteLine("Roll NO {0}",rollNo);
        }

        string[] names = { "AA", "BB", "CC", "DD" };
        foreach (var name in names)
        {
            Console.WriteLine($"Name : {name}");
        }
    }
}
