using CH02_OOPS;
using static CH02_OOPS.T19_Encapsulation;

namespace CH01_CSharpBasics
{
    public class T09_AccessModifierDemo
    {
        public void Test()
        {
            PublicClass publicClass = new PublicClass();
            //PrivateClass privateClass = new PrivateClass();//Inaccessible
            //InternalClass internalClass = new InternalClass();//Inaccessible
            //ProtectedInternalClass protectedInternalClass = new ProtectedInternalClass();//inaccessible
        }
    }

    public class ProtectedInternalChildClass : T19_Encapsulation
    {
        public void Test()
        {
            ProtectedClass protectedClass = new ProtectedClass();
            ProtectedInternalClass protectedInternalClass = new ProtectedInternalClass();
        }
    }
}