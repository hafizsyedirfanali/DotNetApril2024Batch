using Microsoft.AspNetCore.Mvc;
using StudentApplication.ViewModels;

namespace StudentApplication.Controllers;

public class ModelBindingController : Controller
{
    private List<StudentViewModel> students;
    public ModelBindingController()
    {
        students = new List<StudentViewModel>();
        for (int i = 1; i <= 10; i++) // Loop 50 times (from 5 to 54)
        {
            students.Add(new StudentViewModel { Id = i, Name = "Student " + i, Age = 11 + (i - 5), Gender = (i % 2 == 0) ? "M" : "F" });
        }
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Student()
    {
        StudentViewModel model = students[0];
        return View(model);
    }
    public IActionResult Student1()//Scaffolded
    {
        StudentViewModel model = students[0];
        return View(model);
    }
    public IActionResult Students()
    {
        return View(students);
    }
    public IActionResult Students1()//Scaffolded
    {
        return View(students);
    }
    [HttpGet]
    public IActionResult AddStudent()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddStudent(StudentViewModel model)
    {
        if (ModelState.IsValid)
        {
            return View();
        }
        return View();
    }
}
