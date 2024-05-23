using System.Diagnostics;

namespace CH02_OOPS;
/// <summary>
/// Async Await are keywords that help in optimizing the code execution using non blocking method
/// This is a more clear way of writing the asynchronous code
/// async method executes on a separate thread, other than main (UI) thread.
/// async keyword is used to declare the method as asynchronous
/// and await keywork is used before asynchronous method call for getting the result from it.
/// await keyword can be used only in async methods or 
/// async methods may have one or more awaiting type of method calls
/// async methods usually returns a task, which has an overload of generic type
/// async method returns the result as TResult of Generic Task
/// 
/// async method facilitates the cancellation of its execution, i.e. its termination.
/// </summary>

public class T16_AsyncAwait
{
    public void Test()
    {
        TestLongRunningMethodCall();
    }
    public void TestAsyncMethod()
    {
        //DelayAsync(1000);//the warning is specifying that it will run on separate thread.

        //await DelayAsync(1000);//This call is awaited and requires that the calling method must be asynchronous

        DelayAsync(1000).Wait();//This method blocks the main thread for waiting the async method

        var task = DelayAsync(1000);
        Task.WaitAll(task);//This method blocks the main thread for waiting the async method.
    }
    public async Task TestAsyncMethodWithCancellationToken()
    {
        CancellationTokenSource cts = new CancellationTokenSource();        

        await DelayAsync(1000,cts.Token);
        await DelayAsync(1000,cts.Token);
        await DelayAsync(1000,cts.Token);
        await DelayAsync(1000,cts.Token);
        await DelayAsync(1000,cts.Token);

        try
        {
            
        }
        catch (Exception ex)
        {
            cts.Cancel();//this method will initiate the termination of side threads,
            //where the cts.token is passed
        }
    }
    public void TestLongRunningMethodCall()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        var cts = new CancellationTokenSource();
        var task = ALongRunningMethod(cts.Token);
        
        Task.WaitAll(task);
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
    public async Task<bool> DelayAsync(int miliseconds)//Asynchronous mehtod.
    {
        await Task.Delay(miliseconds);
        return true;
    }
    public async Task<bool> DelayAsync(int miliseconds, CancellationToken cancellationToken)//Asynchronous mehtod.
    {
        await Task.Delay(miliseconds, cancellationToken);
        return true;
    }

    public async Task ALongRunningMethod(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            Thread.Sleep(1000);
        }
    }
}
