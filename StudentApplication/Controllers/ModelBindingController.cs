using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.ViewModels;

namespace StudentApplication.Controllers;
/// <summary>
/// CRUD
/// Create- single/multiple
/// Read - single/multiple
/// Update - 
/// </summary>
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
    public IActionResult Student(int id)
    {
        var model = students.Where(s => s.Id == id).FirstOrDefault();
        if(model == null)
        {
            return View("Error", new ErrorViewModel("1001", $"No record found for Id{id}"));
        }
        return View(model);
    }
    public IActionResult Student1(int id)//Scaffolded
    {
        var model = students.Where(s => s.Id == id).FirstOrDefault();
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
            students.Add(model);
            return RedirectToAction(nameof(students));
        }
        //ModelState.AddModelError("", "Data submitted is not valid");
        return View(model);
    }
    [HttpGet]
    public IActionResult UpdateStudent(int id)
    {
        var model = students.Where(s => s.Id == id).FirstOrDefault();
        if (model == null)
        {
            return View("Error", new ErrorViewModel("1002", $"No record found for Id{id}"));
        }
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateStudent(StudentViewModel model)
    {
        if (ModelState.IsValid)
        {
            var student = students.Where(s => s.Id == model.Id).FirstOrDefault();
            if (student == null)
            {
                return View("Error", new ErrorViewModel("1003", $"No record found for Id{model.Id}"));
            }
            student.Id = model.Id;
            student.Name = model.Name;
            student.Age = model.Age;
            student.Gender = model.Gender;
            return RedirectToAction(nameof(Students));
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult UpdateStudents()
    {
        return View(students);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateStudents(List<StudentViewModel> model)
    {
        if (ModelState.IsValid)
        {
            students.AddRange(model);
            return RedirectToAction(nameof(students));
        }
        return View(model);        
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStudent(int id)
    {
        var student = students.Where(s => s.Id == id).FirstOrDefault();
        if (student == null)
        {
            return View("Error", new ErrorViewModel("1004", $"No record found for Id{id}"));
        }
        students.Remove(student);
        return RedirectToAction(nameof(Students));
    }
}
