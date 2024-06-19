using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
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
    private readonly StudentDataSource studentDataSource;

    public ModelBindingController(StudentDataSource studentDataSource)
    {
        this.studentDataSource = studentDataSource;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Student(int id)
    {
        var students = studentDataSource.GetStudents();
        var model = students.Where(s => s.Id == id).FirstOrDefault();
        if (model == null)
        {
            return View("Error", new ErrorViewModel("1001", $"No record found for Id{id}"));
        }
        return View(model);
    }

    public IActionResult Student1(int id)//Scaffolded
    {
        var students = studentDataSource.GetStudents();
        var model = students.Where(s => s.Id == id).FirstOrDefault();
        return View(model);
    }

    public IActionResult Students()
    {
        var students = studentDataSource.GetStudents().OrderBy(s=>s.Id).ToList();
        return View(students);
    }

    public IActionResult Students1()//Scaffolded
    {
        var students = studentDataSource.GetStudents();
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
            var students = studentDataSource.GetStudents();
            students.Add(model);
            return RedirectToAction(nameof(Students));
            //return RedirectToAction("Students");
        }
        //ModelState.AddModelError("", "Data submitted is not valid");
        return View(model);
    }

    [HttpGet]
    public IActionResult UpdateStudent(int id)
    {
        var students = studentDataSource.GetStudents();
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
            var students = studentDataSource.GetStudents();
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
        var students = studentDataSource.GetStudents();
        return View(students);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateStudents(List<StudentViewModel> model)
    {
        if (ModelState.IsValid)
        {
            var students = studentDataSource.GetStudents();
            students.AddRange(model);
            return RedirectToAction(nameof(students));
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStudent(int id)
    {
        var students = studentDataSource.GetStudents();
        var student = students.Where(s => s.Id == id).FirstOrDefault();
        if (student == null)
        {
            return View("Error", new ErrorViewModel("1004", $"No record found for Id{id}"));
        }
        students.Remove(student);
        return RedirectToAction(nameof(Students));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStudents(List<int> ids)
    {
        var students = studentDataSource.GetStudents();
        var studentList = students.Where(s => ids.Contains(s.Id)).ToList();
        if (!studentList.Any())
        {
            return View("Error", new ErrorViewModel("1004", $"No record found for Ids:{string.Join(',', ids)}"));
        }
        studentList.RemoveRange(0, studentList.Count);
        return RedirectToAction(nameof(Students));
    }
}