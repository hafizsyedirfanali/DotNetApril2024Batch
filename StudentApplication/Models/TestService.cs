namespace StudentApplication.Models
{
    public class TestService
    {
        public int Counter { get; set; }
        public bool IsSystemReady()
        {
            return true;
        }
        public int GetCounter()
        {
            return Counter;
        }
        public int IncrementCounter()
        {
           // Counter++;
            return ++Counter;
        }
    }

    
}
