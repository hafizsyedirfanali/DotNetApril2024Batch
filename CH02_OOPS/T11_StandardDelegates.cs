namespace CH02_OOPS;
/// <summary>
/// There are three standard delegates, all of them are generic and have multiple overloads, except predicate
/// 1. Action - It is used with those functions that do not return any value (return type = void)
/// 2. Func
/// 3. Predicate
/// </summary>
public class T11_StandardDelegates
{
    public void Test()
    {

    }
    public void TestActionDelegate()
    {
        //in specifies the type of input parameter and out specifies the return type
        Action<int> action = MethodForActionDelegate; action.Invoke(10);
        Action<int,int> action1 = MethodForActionDelegate; action1.Invoke(10,20);
    }
    public void MethodForActionDelegate(int a) { }
    public void MethodForActionDelegate(int a, int b) { }
}
