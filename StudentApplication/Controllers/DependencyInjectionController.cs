using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;

namespace StudentApplication.Controllers;
/// <summary>
/// This controller contains the dependency injection methods and demo of service lifetime
/// </summary>
public class DependencyInjectionController : Controller
{
    private readonly TestService _testService;
    private readonly IServiceProvider _serviceProvider;
    public DependencyInjectionController(TestService testService, 
        IServiceProvider serviceProvider,
        [FromKeyedServices("single")]TestService testService1,
        [FromKeyedServices("transient")] TestService testService2,
        [FromKeyedServices("scoped")] TestService testService3)
    {
        this._testService = testService;//Optimum method of injecting service
        _serviceProvider = serviceProvider;//Not recommended, not standard
    }
    public IActionResult Index()
    {
        _testService.IsSystemReady();
        return View();
    }
    public IActionResult Counter1()
    {
        for (int i = 0; i < 100; i++)
        {
            _testService.IncrementCounter();

        }
        
        return View();
    }
    public IActionResult Counter2()
    {
        return View();
    }
    public IActionResult CustomInjectionUsingGetService()
    {
        var testService = _serviceProvider.GetService<TestService>();
        if (testService is not null)
        {
            testService.IsSystemReady(); 
        }
        return Ok();
    }
    public IActionResult CustomMethodUsingCreateScope()
    {
        using(IServiceScope scope = _serviceProvider.CreateScope())
        {
            var testService = scope.ServiceProvider.GetService<TestService>();
            if (testService != null)
            {
                testService.IsSystemReady(); 
            }
        }
        return Ok();
    }
}