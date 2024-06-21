using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Services;
using StudentApplication.ViewModels;

namespace StudentApplication.Controllers;

/// <summary>
/// CRUD
/// Create- single/multiple - Done
/// Read - single/multiple - Done
/// Update - Done
/// Delete -
/// </summary>
public class ModelBindingController : Controller
{
    private readonly IStudentServices studentServices;

    public ModelBindingController(IStudentServices studentServices)
    {
        this.studentServices = studentServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Student(int id)
    {
        var model = studentServices.GetStudent(id);
        if (model == null)
        {
            return View("Error", new ErrorViewModel("1001", $"No record found for Id{id}"));
        }
        return View(model);
    }

    public IActionResult Student1(int id)//Scaffolded
    {
        var model = studentServices.GetStudent(id);
        if (model != null) return View(model);
        return View("Error", new ErrorViewModel("1001", $"No record found for Id{id}"));
    }

    public IActionResult Students()
    {
        var students = studentServices.GetStudents();
        return View(students);
    }

    public IActionResult Students1()//Scaffolded
    {
        var students = studentServices.GetStudents();
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
            studentServices.AddStudent(model);
            return RedirectToAction(nameof(Students));
            //return RedirectToAction("Students");
        }
        //ModelState.AddModelError("", "Data submitted is not valid");
        return View(model);
    }

    [HttpGet]
    public IActionResult UpdateStudent(int id)
    {
        var model = studentServices.GetStudent(id);
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
            studentServices.UpdateStudent(model);
            return RedirectToAction(nameof(Students));
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult UpdateStudents()
    {
        var students = studentServices.GetStudents();
        return View(students);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateStudents(List<StudentViewModel> model)
    {
        if (ModelState.IsValid)
        {
            studentServices.UpdateStudents(model);
            return RedirectToAction(nameof(Students));
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStudent(int id)
    {
        studentServices.DeleteStudent(id);
        return RedirectToAction(nameof(Students));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStudents(List<int> ids)
    {
        studentServices.DeleteStudents(ids);
        return RedirectToAction(nameof(Students));
    }
}