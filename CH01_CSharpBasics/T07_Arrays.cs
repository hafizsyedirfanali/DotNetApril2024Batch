namespace CH01_CSharpBasics;

public class T07_Arrays
{
    public void Test()
    {
        OneDimentionalArray();
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
    }
}
