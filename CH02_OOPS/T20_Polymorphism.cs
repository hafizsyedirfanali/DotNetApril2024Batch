namespace CH02_OOPS;

/// <summary>
/// Polymorphism is defined as multiple faces of same entity.
/// It can be observed through
/// inheritance,
/// contructor,
/// constructor overloading
///
/// It can be observed in method overloading
///
/// It can be observed in method overriding
/// </summary>
public class T20_Polymorphism
{
    public void Test()
    {
        //A a = new A();
        D d = new D(10);
        Add(1, 2, 3);

        ChildClass c = new ChildClass();
        c.Message("Greetings");
    }

    #region Method Overloading

    //Following is a compile time (static) polymorphism
    //because the called method is clear during compile time before running.
    public int Add(int a, int b) => a + b;

    public int Add(int a, int b, int c) => a + b + c;

    #endregion Method Overloading

    #region Constructor overloading

    public class A // root
    {
        public A()
        {
        }

        public A(int count)
        {
            this.Count = count;
        }

        public int MyProperty { get; set; }
        public int Count;
    }

    public class B : A
    {
        public B()
        {
        }

        public B(int count) : base(count)
        {
        }
    }

    public class C : B
    {
        public C()
        {
        }

        public C(int count) : base(count)
        {
        }
    }

    public class D : C //leaf
    {
        public D() : base()
        {
        }

        //Following method is used in database context creation.
        public D(int count) : base(count)
        {
        }
    }

    #endregion Constructor overloading

    //Method overriding - runtime polymorphism
    //For achieving method overriding, the parent class method must be virtual
    public class ParentClass
    {
        public virtual int Add(int a, int b)
        {
            return a + b;
        }

        public virtual void Message(string message)
        {
            Console.WriteLine("Sent Email");
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    public class ChildClass : ParentClass
    {
        //if we want to create same name method
        //then use new keyword to hide parent class method
        public new int Multiply(int a, int b)
        {
            return a * b;
        }

        public override int Add(int a, int b)
        {
            return a + b;
        }

        public override void Message(string message)
        {
            //base.Message(message);
            Console.WriteLine("Sent SMS");
        }
    }
}