namespace CH01_CSharpBasics;
/// <summary>
/// Type Conversion : Type Casting : Parsing
/// 1. Implicit: Automatic
/// 2. Explicit: Manual
/// </summary>
public class T02_TypeConversion
{
    public void Test()
    {
        CastingUsingConvertClass();
    }
    public void CastUsingParseMethod()
    {
        string str = "9223372036854775807";
        byte b = byte.Parse(str);
        short s = short.Parse(str);
        int i = int.Parse(str);
        long l = long.Parse(str);
    }
    public void CastingUsingTryParse()
    {
        ///This casting method never throws exception.
        string str = "9223372036854775807";
        var isSuccess = long.TryParse(str, out long resultLong);
        isSuccess = int.TryParse(str, out int resultInt);
        isSuccess = short.TryParse(str, out short resultShort);
        isSuccess = byte.TryParse(str, out byte resultByte);
        isSuccess = float.TryParse(str, out float resultFloat);
        isSuccess = double.TryParse(str, out double resultDouble);
        isSuccess = decimal.TryParse(str, out  decimal resultDecimal);
        isSuccess = char.TryParse(str, out char  resultChar);
        isSuccess = bool.TryParse(str, out bool resultBool);
    }
    public void CastingUsingConvertClass()
    {
        //Convert class will convert only valid casting.
        //If we try to convert invalid casting, it will throw exception.
        long l = Convert.ToInt64(9223372036854775807);
        int i = Convert.ToInt32(l);
        short s = Convert.ToInt16(i);
        byte b = Convert.ToByte(s);
        float f = 1.3f;
        i = Convert.ToInt32(f);
        char c = Convert.ToChar(i);
        string str = "1l";
        i = Convert.ToInt32(str);
    }
    public void TestExplicit()
    {
        //While doing explicit conversion, we are responsible 
        //for any data loss.
        long l = 9223372036854775807;
        int i = (int)l;
        short s = (short)i;
        byte b = (byte)s;

        float f = 1.5f;
        i = (int)f;

        char c = (char)b;
        string str = "1";
        
    }
    public void TestImplicit()
    {
        ///Implicit conversion among integers
        byte b = 255;
        short s = b;
        int i = s;
        long l = i;
        //we cannot cast higher into lower 


        ///Implicit conversion between integer and float
        float f = b;
        f = s;
        f = i;
        f = l;
        //we cannot cast/convert float to int due to loss of fractional value


        //Implicit conversion between char and int is not allowed,
        //Similarly, conversion between int and boolean is also not allowed.

        
    }
}
