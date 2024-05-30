namespace CH02_OOPS;
/// <summary>
/// Abstraction is a process of hiding the implementation
/// and showing the defination
/// We achieve abstraction by 
/// 1. Abstract Class
/// 2. Interface
/// </summary>

public class T21_Abstraction
{
    public class UsingAbstractClass
    {
        public void Test()
        {
        }
        public abstract class Services
        {
            /// <summary>
            /// a class does not allow to write only defination until it is 
            /// made abstract class using abstract keyword and 
            /// the method defination must be marked as abstract
            /// it is not mandatory to write abstract definations in an abstract class
            /// but if we do not write any abstract method then the class is useless
            /// because an abstract class cannot be instantiated.
            ///
            /// </summary>
            /// <param name="message"></param>
           
            public abstract void PrintService(string message);

            public abstract void MessageService(string message);
        }
        public class Implementation : Services //this is a contract, that the implementation class will implement the services (print, message)
        {
            public override void PrintService(string message)
            {
                Console.WriteLine("Message is printed");
            }
            public override void MessageService(string message)
            {
                Console.WriteLine("Message is Sent");
            }
        }


    }
}
