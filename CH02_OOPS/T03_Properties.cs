namespace CH02_OOPS;

public class T03_Properties
{
    public void Test()
    {
        PropertyClass p = new PropertyClass();//on LHS we have type, on RHS we have constructor 
        PropertyClass p1 = new ();
        var p2 = new PropertyClass();

        p.Age = 10;//Set Operation
        Console.WriteLine(p.Age);//Get Operation

        //p.Name = "World";//Private Set Property
        p.Address = "Nagpur";
        Console.WriteLine(p.Address);
    }

}
public class PropertyClass
{
    private string address;//_Address
    public int Age { get; set; }//Read Write Property
    public int Count { get; }//Read Only Property
    public string Name { get; private set; }//Read externally and Write from within the class only
    public string Address 
    {
        get
        {
            return address.ToUpper();
        }
        set
        {
            if(value.Length < 20)
            {
                address = value;
            }            
        }   
    }
   
    public void Test()
    {
        Name = "Hello";
    }
}
