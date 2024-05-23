using System.Diagnostics;

namespace CH02_OOPS;
/// <summary>
/// A thread is a software, a part of OS, it allows us to use CPU
/// This topic is to demonstrate the advantage of using multithreading.
/// </summary>
public class T15_Multithreading
{
    public void Test()
    {
        TestTasksAsynchronously();
    }
    public void TestTasksAsynchronously()//this function will run on main thread (UI Thread)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Task t1 = Task.Run(Task1);//This will capture a seperate side thread.
        Task t2 = Task.Run(Task2);//This will capture a seperate side thread.
        Task t3 = Task.Run(Task3);//This will capture a seperate side thread.
        Task t4 = Task.Run(Task4);//This will capture a seperate side thread.
        Task.WaitAll(t1, t2, t3, t4);//we are saying to main thread to wait for the side threads
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
    public void TestTasksSynchronously()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();        
        Task1();
        Task2();
        Task3();
        Task4();
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
    public void Task1()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Task1 Completed");
    }
    public void Task2()
    {
        Thread.Sleep(8000);
        Console.WriteLine("Task2 Completed");
    }
    public void Task3()
    {
        Thread.Sleep(6000);
        Console.WriteLine("Task3 Completed");
    }
    public void Task4()
    {
        Thread.Sleep(4000);
        Console.WriteLine("Task4 Completed");
    }
}
