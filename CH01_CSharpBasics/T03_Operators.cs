namespace CH01_CSharpBasics;
/// <summary>
/// 1. Assignment operators
/// 2. Relational operators
/// 3. Arithmatic operators
/// 4. Logical operators, Bitwise, shift
/// 5. Conditional Operators
/// 6. Increment Decrement Operators
/// 7. Null Coalsing Operator
/// 8. Null Forgiving Operator
/// </summary>
public class T03_Operators
{
    public void Test()
    {
        IncrementDecrementOperators();
    }
    public void IncrementDecrementOperators()
    {
        //It has PreIncrement, Post Increment, Pre Decrement & Post Decrement operators
        //       ++a            a++             --a            a--
        //Post increment operator increments value at the last.
        int a = 10;
        var result = a++;//value of a(10) will be assigned to result, then value in a will be incremented
        var result1 = ++a;//it increments first then assigns the incremented value
        var result2 = a--;//it assigns the value to result then decrements a
        var result3 = --a;//it decrements first then assigns the decremented value.
        a = 10;
        Console.WriteLine(a++);
        Console.WriteLine(++a);
        Console.WriteLine(--a);
        Console.WriteLine(a--);
    }
    public void NullForgivingOperator()
    {
        string? a = null;
        //if it is sure that variable a will definately 
        //get a value here
        string result = a!;
        //? operator -- will study after class & Properties
    }
    public void NullCoalsingOperator()
    {
        //It is a conditional Operator, and checks only NUll condition
        string? a = null;

        string result = a == null? "Blank": a;
        result = a ?? "Blank";
        //if a is not null then assign its value
        //else assign "Blank"
    }

    //Arithmatic operators
    public void TestArithmaticOperators()
    {
        int a = 10, b = 3;
        var addition = a + b;
        var subtraction = a - b;
        var multiplication = a * b;
        var divisionQuotient = a / b;
        var divisionRemainder = a % b;
    }
    public void ConditionalOperators()
    {
        //Ternary Operator  ?  :
        int a = 10, b = 30;
        string result = a > 20 ? "Yes" : "No";
        //if condition is true then 
        //var result = "Yes";
        //if condition is false then
        //var result = "No";
        bool result1 = a > 20 ? true : false;
        int result2 = (a > 20 && b < 30) || a == 10 ? 100 : 200;

    }
    public void TestLogicalBitwiseShiftOperators()
    {
        ///  10 Given
        ///  01 Right Shift by 1 = 1
        ///  10 Left shift by 1  = 2
        /// 100 Left shift by 1  = 4
        ///1000 Left shift by 1  = 8
        int a = 2;//10
        var result = a << 1;//Left shift by 1
        result = a >> 1; // Right shift by 1
        result = a << 2; // Left shift by 2
        result = a >> 2; // Right shift by 2

    }
    public void TestLogicalBitwiseOperators()
    {
        //example operand1 = 2, operand2 = 3
        //        operand1 = 10
        //        operand2 = 11
        //        ---------------
        //   Bitwise Anding= 10
        //   Bitwise Oring = 11
        int operand1 = 2, operand2 = 3;
        var result = 2 & 3;//ans = 2

        result = 2 | 3;//ans = 3
    }
    public void TestLogicalOperators()
    {
        //ANDing
        var result = true && true;//True
        result = true && false;//False
        result = false && true;//False
        result = false && false;//False

        //ORing
        result = true || true;//true
        result = true || false;//true
        result = false || true;//true
        result = false || false;//false

        //NOT
        result = !true;//false
        result = !false;//true
    }
    public void TestRelationalOperators()
    {
        int a = 10, b = 3;
        var result = a == b;//is a equals to b? T/F
        result = a != b; //is a not equal to b? T/F
        result = a > b;
        result = a < b;
        result = a <= b;
        result = a >= b;
    }
    public void TestAssignmentOperators()
    {
        int a = 10;        
        a += 3; //a = a + 3;
        a -= 3; //a = a - 3;
        a *= 3; //a = a * 3;
        a /= 3; //a = a / 3;
        a %= 3; //a = a % 3;
        a = 2;
        a >>= 1;//1
        a <<= 1;//2
        a <<= 1;//4
        a <<= 1;//8
    }
}
