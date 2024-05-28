using static CH02_OOPS.T19_Encapsulation;

namespace CH02_OOPS//Assembly
{
    /// <summary>
    /// Encapsulation is the concept of wrapping data into a single unit.
    /// We use access modifiers for this purpose
    /// we have following basic access modifier
    /// 1. public  - accessible everywhere (within and outside assembly/package) (namespace)
    /// 2. private - accessible within home class only
    /// 3. protected - accessible within home class and derived class
    /// 4. internal - accessible everywhere within assembly (namespace)
    /// and few hybrid
    /// 5. protected internal - everywhere in the assembly and to the derived class in other assembly
    /// 6. private protected
    /// </summary>
    public class T19_Encapsulation //Class within namespace is called TYPE and it can be only public or internal
    {
        public void Test()
        {
            PublicClass publicClass = new PublicClass();
            PrivateClass privateClass = new PrivateClass();
            InternalClass internalClass = new InternalClass();
            ProtectedClass protectedClass = new ProtectedClass();
            Add(1, 2);
            ProtectedInternalClass protectedInternalClass = new ProtectedInternalClass();
        }
        public class PublicClass
        {

        }
        private class PrivateClass
        {

        }
        internal class InternalClass
        {

        }
        protected class ProtectedClass
        {

        }
        protected int Add(int x, int y) => x + y;

        protected internal class ProtectedInternalClass
        {

        }
    }
    public class OuterClass
    {
        public void Test()
        {
            PublicClass publicClass = new PublicClass();
            //PrivateClass privateClass = new PrivateClass();//Inaccessible
            InternalClass internalClass = new InternalClass();
            //ProtectedClass protectedClass = new ProtectedClass();//Inaccessible
            //Add(1, 2);//Inaccessible - protected
            ProtectedInternalClass protectedInternalClass = new ProtectedInternalClass();
        }
    }
    public class OuterDerivedClass : T19_Encapsulation
    {
        public void Test()
        {
            ProtectedClass protectedClass = new ProtectedClass();
            Add(1, 2);
        }
    }
}


