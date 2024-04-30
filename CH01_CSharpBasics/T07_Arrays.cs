namespace CH01_CSharpBasics;

public class T07_Arrays
{
    public void Test()
    {
        ThreeDimensionalJaggedArray();
    }
    public void OneDimentionalArray()
    {
        int[] rollNos = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] rollNOs1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] rollNOs2 = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        int[] rollNOs3 = new int[5] {1,2,3,4,5};
        int[] rollNOs4 = new int[5];
        rollNOs4 = [1, 2, 3, 4, 5];
        rollNOs4[0] = 1;
        rollNOs4[1] = 2;
        rollNOs4[2] = 3;
        rollNOs4[3] = 4;
        rollNOs4[4] = 5;
        //rollNOs4[5] = 6;//throws runtime error "index out of bound of array"
        //rollNOs4[6] = 7;
        int[] rollNos5;//Initialization/declaration
        var size = Convert.ToInt32(Console.ReadLine());
        rollNos5 = new int[size];//memory allocation
        for (int i = 0; i < size; i++)
        {
            rollNos5[i] = Convert.ToInt32(Console.ReadLine());//Assignment
        }
        //Reading array using index
        for (int i = 0; i < rollNos5.Length; i++)//i is called as loop variable, counter, iterator
        {
            Console.WriteLine($"Element :{rollNos5[i]}");
        }
    }

    /// <summary>
    /// We have two options for multidimensional arrays
    /// 1. Rectangular Array : Dimension is fixed, wastage of space, less complex
    /// 2. Jagged Array : Dimension is not fixed and no wastage of space, more complex
    /// Jagged arrays are also called as array of arrays
    /// </summary>
    
    ///Rectangular
    public void TwoDimensionalRectangularArray()
    {
        ///Initializaiton of array
        int[,] twoDimensionArray = new int[2, 3]
        {
            {1,2,3},
            {2,3,4}
        };
        //Reading value of second row first column
        Console.WriteLine(twoDimensionArray[1,0]);
        //Writing into the array using index
        twoDimensionArray[1, 0] = 5;
        //Reading from the array
        Console.WriteLine(twoDimensionArray[1,0]);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{twoDimensionArray[i, j]} ");
            }
            Console.WriteLine("");
        }
    }

    public void ThreeDimensionalArray()
    {
        int[,,] threeDArray = new int[2, 2, 2]
        {
            {
                {1, 2 },
                {3, 4 }
            },
            {
                {5, 6 },
                {7, 8 }
            }
        };
        //printing or reading last value i.e. 8
        //its index will be 1,1,1
        Console.WriteLine(threeDArray[1,1,1]);
        //writing into the array at 1,1,1
        threeDArray[1, 1, 1] = 10;
        //reading the value at 1,1,1
        Console.WriteLine(threeDArray[1,1,1]);

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.Write(threeDArray[i,j,k] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("----------");
        }

    }
    //Jagged Array
    public void TwoDimensionalJaggedArray()
    {
        int[][] twoDArray = new int[3][];//it is an array of the following arrays

        int[] firstArray = new int[2] { 1, 2 };
        int[] secondArray = new int[3] { 2, 3, 4 };
        int[] thirdArray = new int[4] { 3, 4, 5, 4 };

        twoDArray[0] = firstArray;
        twoDArray[1] = secondArray;
        twoDArray[2] = thirdArray;

        twoDArray[1][1] = 30;

        for (int i = 0; i < twoDArray.Length; i++)
        {
            for (int j = 0; j < twoDArray[i].Length; j++)
            {
                Console.Write(twoDArray[i][j] + " ");
            }
            Console.WriteLine("");
        }
    }
    
    public void ThreeDimensionalJaggedArray()//Array of two D Jagged Arrays
    {
        int[] firstArray = new int[2] { 1, 2 };
        int[] secondArray = new int[3] { 2, 3, 4 };
        int[] thirdArray = new int[4] { 3, 4, 5, 4 };
        //-------------------------------------------

        int[][][] threeDArray = new int[3][][];

        int[][] firstTwoDArray = new int[3][];
        firstTwoDArray[0] = firstArray;
        firstTwoDArray[1] = secondArray;
        firstTwoDArray[2] = thirdArray;


        int[][] secondTwoDArray = new int[3][];
        secondTwoDArray[0] = firstArray;
        secondTwoDArray[1] = secondArray;
        secondTwoDArray[2] = thirdArray;


        int[][] thirdTwoDArray = new int[3][];
        thirdTwoDArray[0] = firstArray;
        thirdTwoDArray[1] = secondArray;
        thirdTwoDArray[2] = thirdArray;

        threeDArray[0] = firstTwoDArray;
        threeDArray[1] = secondTwoDArray;
        threeDArray[2] = thirdTwoDArray;

        for (int i = 0; i < threeDArray.Length; i++)
        {
            for (int j = 0; j < threeDArray[i].Length; j++)
            {
                for (int k = 0; k < threeDArray[i][j].Length; k++)
                {
                    Console.Write(threeDArray[i][j][k] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("----------------------");
        }
    }
}
