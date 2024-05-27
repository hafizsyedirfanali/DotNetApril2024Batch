namespace CH02_OOPS;
/// <summary>
/// Inheritance is a feature in C# or any OOPS language, which allows us to reuse the members of 
/// a class into another class.
/// Inheritance is used to avoid code repeatition.
/// </summary>
public class T17_Inheritance_SingleInheritance
{
    /// <summary>
    /// Single inheritance has a parent/base class and a child/derived class only.
    /// </summary>
    public void Test()
    {
        B b = new B();
        b.count = 1;
        b.MyProperty = 1;
        b.TestMethod();
    }
    public class A
    {
        public int MyProperty { get; set; }
        public int count;
        public void TestMethod()
        {

        }
    }
    public class B : A
    {

    }
}
public class T17_Inheritance_MultilevelInheritance
{
    /// <summary>
    /// Multilevel inheritance has multiple levels of a single class.
    /// </summary>
    public void Test()
    {
        D d = new D();
        d.Count = 1;
        d.MyProperty = 1;
    }
    public class A
    {
        public int MyProperty { get; set; }
        public int Count;
    }
    public class B : A
    {

    }
    public class C : B
    {

    }
    public class D : C
    {

    }
}
public class T17_Inheritance_HierarchicalInheritance
{
    /// <summary>
    /// Hierarchical inheritance has multiple child classes of a parent class.
    /// </summary>
    public void Test()
    {
        B2 b2 = new B2();
        b2.MyProperty = 1;
        b2.Count = 1;
    }
    public class A //Root class
    {
        public int MyProperty { get; set; }
        public int Count;
    }
    public class B1 : A
    {

    }
    public class B2 : A
    {

    }
}
public class T17_Inheritance_MultipleInheritance
{
    /// <summary>
    /// Multiple inheritance is not allowed in C# using classes, except using interface.
    /// In this a child has multiple parents.
    /// To achive multiple inheritance, parents must be interfaces and not classes.
    /// </summary>
    public void Test()
    {

    }

    public interface Parent1Class
    {
        public int MyProperty1 { get; set; }
        public void Test1();
    }
    public interface Parent2Class
    {
        public int MyProperty2 { get; set; }
        public void Test2();
    }
    /// <summary>
    /// Following child class is not inheriting but implementing
    /// </summary>
    public class ChildClass : Parent1Class, Parent2Class
    {
        private int myProperty;
        public int MyProperty1 
        {
            get => myProperty;
            set => myProperty = value; 
        }
        public int MyProperty2
        {
            get => myProperty;
            set => myProperty = value;
        }

        public void Test1()
        {
            
        }

        public void Test2()
        {
            
        }
    }
}

public class T17_Inheritance_HybridInheritance
{
    /// <summary>
    /// Hybrid inheritance is a combination of two or more types of inheritance.
    /// In this example we combined multilevel and hierarchical. so it has three levels
    /// </summary>
    public void Test()
    {
        C2 c2 = new C2();
        c2.MyProperty = 1;
        c2.Count = 1;
    }
    public class A //Root class
    {
        public int MyProperty { get; set; }
        public int Count;
    }
    public class B1 : A
    {

    }
    public class B2 : A
    {

    }
    public class C1 : B1 //Leaf class
    {

    }
    public class C2 : B1 //Leaf class
    {

    }
}