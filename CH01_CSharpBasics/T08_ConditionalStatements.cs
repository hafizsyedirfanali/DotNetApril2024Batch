using System.Security.Cryptography.X509Certificates;

namespace CH01_CSharpBasics;
/// <summary>
/// We have following conditional statements
/// 1. If-Else
/// 2. Switch
/// 3. Ternary operator (T03_Operators)
/// </summary>
public class T08_ConditionalStatements
{
    public void Test()
    {
        SwitchCase();
    }
    public void IfElseLadder()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Result Generator App");
            Console.WriteLine("Enter your percentage");
            float percentage = Convert.ToSingle(Console.ReadLine());
            if (percentage < 0)
            {
                Console.WriteLine("Invalid Percentage");
            }
            else if (percentage < 40)
            {
                Console.WriteLine("FAIL");
            }
            else if (percentage < 50)
            {
                Console.WriteLine("Third Class");
            }
            else if (percentage < 60)
            {
                Console.WriteLine("Second Class");
            }
            else if (percentage < 75)
            {
                Console.WriteLine("First Class");
            }
            else if (percentage <= 100)
            {
                Console.WriteLine("Distinction");
            }
            else
            {
                Console.WriteLine("Invalid Percentage");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void IfElseNested()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Result Generator App");
            Console.WriteLine("Enter your percentage");
            float percentage = Convert.ToSingle(Console.ReadLine());
            if (percentage < 40)
            {
                Console.WriteLine("FAIL");
            }
            else 
            {
                Console.WriteLine("PASS");
                if(percentage < 60)
                {
                    if(percentage < 50)
                    {
                        Console.WriteLine("Third Class");
                    }
                    else
                    {
                        Console.WriteLine("Second Class");
                    }
                }
                else
                {
                    if( percentage < 75)
                    {
                        Console.WriteLine("First Class");
                    }
                    else
                    {
                        Console.WriteLine("Distinction");
                    }
                }
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void SwitchCase()
    {
        bool toContinue = true;
        while (toContinue)
        {
            Console.WriteLine("Enter your choice");
            Console.WriteLine("Press 1 for Addition");
            Console.WriteLine("Press 2 for Subtraction");
            Console.WriteLine("Press 3 for Multiplication");
            Console.WriteLine("Press 4 for Division");
            Console.WriteLine("Press 5 for Exit");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1'://get two values from user and display sum
                    Console.WriteLine("Addition Operation");
                    break;
                case '2':
                    Console.WriteLine("Subtraction Operation");
                    break;
                case '3':
                    Console.WriteLine("Multiplication Operation");
                    break;
                case '4':
                    Console.WriteLine("Division Operation");
                    break;
                case '5':
                    toContinue = false;
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
