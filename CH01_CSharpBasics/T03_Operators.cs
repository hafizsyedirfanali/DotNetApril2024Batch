namespace CH01_CSharpBasics;
/// <summary>
/// 1. Assignment operators
/// 2. Relational operators
/// 3. Arithmatic operators
/// 4. Logical operators, Bitwise, shift
/// 5. Conditional Operators
/// 6. Increment Decrement Operators
/// 7. Null Coalsing Operator
/// </summary>
public class T03_Operators
{
    public void Test()
    {
        TestLogicalBitwiseOperators();
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
        var result = 2 & 3;

        result = 2 | 3;
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
