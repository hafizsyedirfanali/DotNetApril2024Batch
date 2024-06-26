using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using StudentApplication.Services;
using StudentApplication.ViewModels;

namespace StudentApplication.Controllers
{
    public class OneToManyController : Controller
    {
        private readonly IStudentServices studentServices;

        public OneToManyController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        public IActionResult Students()
        {
            var students = studentServices.GetStudentsOneToOne();
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
        public IActionResult AddDetails(int id)
        {
            StudentExtentionViewModel model = new StudentExtentionViewModel()
            {
                StudentId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetails(StudentExtentionViewModel model)
        {
            if (ModelState.IsValid)
            {
                studentServices.AddDetails(model);
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
    }
}