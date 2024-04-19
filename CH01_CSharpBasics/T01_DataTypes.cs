namespace CH01_CSharpBasics
{
    public class T01_DataTypes
    {
        public void Test()
        {
            
        }
        public void IntegerDataType()
        {
            byte ub = 255; //0 to 255
            sbyte sb = 127; //-128 to 127

            short ss = 32767;//signed -32768 to 32767
            ushort us = 65535;//unsigned 0 to 65535

            int si = 2147483647; //-2,147,483,648 to 2,147,483,647
            uint ui = 4294967295;//0 to 4,294,967,295

            long sl = 9223372036854775807;//-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
            ulong ul = 18446744073709551615;//0 to 18,446,744,073,709,551,615
        }
    }
}
