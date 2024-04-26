namespace CH01_CSharpBasics
{
    public class T01_DataTypes
    {
        public void Test()
        {
            
        }
        public void IntegerDataType()//Valued - Default value is 0
        {
            byte ub = 255; //0 to 255
            sbyte sb = 127; //-128 to 127

            ushort us = 65535;//unsigned 0 to 65535
            short ss = 32767;//signed -32768 to 32767

            uint ui = 4294967295;//0 to 4,294,967,295
            int si = 2147483647; //-2,147,483,648 to 2,147,483,647

            ulong ul = 18446744073709551615;//0 to 18,446,744,073,709,551,615
            long sl = 9223372036854775807;//-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        }
        public void FloatingDataType()//Valued - Default value is 0
        {
            float f = 1.2f; // 4bytes
            double d = 1.2d; //8bytes
            double d1 = 1.2;//withoud suffix 'd'. as double is default type
            decimal dm = 1.2m;//suffix m is for decimal //16bytes
        }

        public void CharacterDataType()//Valued - Default value is 0
        {
            char c = 'a';
            Char c1 = 'a';//It is stored as a value and takes a byte
        }

        public void BooleanDataType()//Valued - Default value is 0
        {
            bool b = true;//true is stored as 1
            Boolean b1 = false;//false is stored as 0
        }

        public void StringDataType()//Referenced Type - Default value is null
        {
            //Every referenced type if kept unassigned holds null value.
            string s;//here s holds null value.
            string s1 = "hello";//in this s1 will be in stack and "hello" will be 
            //in heap, whose starting address will be stored in s1 (stack)
            //Garbage Collector is responsible for cleaning the unreferenced data
        }

        public void VarDataType()
        {
            var i = 10;
            var f = 1.2f;
            var db = 1.2;
            var dm = 1.2m;
            var c = 'a';
            var b = true;
            var s = "hello";
        }
        public void ObjectDataType()//it is a compile time datatype (Frequently as compared to Dynamic)
        {
            //it verifies data at compile time.
            object o = 1.2;
        }
        public void DynamicDataType()//it is a runtime datatype (Rare)
        {
            //as it verifies data at runtime and if data is non convertible,
            //it throws exception, which crashes the app
            dynamic d = 1.2;
        }
        public void NullableDataType()
        {
            //After Migration to .net 6 version
            //Nullabes are marked with ? to indicate that they are nullables

            //Referenced nullable Variables
            string? s;//here s will have null value
            //All class objects are nullables, will hold null value if unassigned.
            T01_DataTypes? t;//here t will have null value
            string? s1 = null;//here i added null value explicitly
            T01_DataTypes? t2 = null;

            //Valued nullable variables
            byte? b = null;
            short? s2 = null;
            int? i = null;
            long? l = null;
            float? f = null;
            double? d = null;
            decimal? dm = null;
            char? c = null;
            bool? b1 = null;

            //condition1 : you have value
            int value = 10;
            //condition2 : you will surely get value afterwards 
            int value1;
            value1 = 20;
            //condition3 : you may get value afterwards
            int? value3 = null; //assigned null value (Recommended)
            int? value4;//nullable but unassigned

        }
        public void ArrayDataTypes()
        {
            ///Array is a collection of same data type
            ///we can have int array, float array, string array, 
            ///bool array, char array, etc
            ///
            int[] a = { 1, 2, 3, 4 };
            float[] f = { 1.1f, 2.2f };
            string[] str = { "hello", "world" };
            bool[] b = { true, false };
            char[] c = { 'a', 'b', 'c' };
        }
    }
}

