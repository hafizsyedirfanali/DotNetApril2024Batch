using Microsoft.AspNetCore.Mvc;
using StudentApplication.ViewModels;

namespace StudentApplication.Controllers
{
    public class OneToManyController : Controller
    {
        public IActionResult Branches()
        {
            //call service and get all branches List<BranchesViewModel>
            return View();
        }

        [HttpGet]
        public IActionResult AddBranch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBranch(AddBranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                //call service
                //redirect to lists on success and to error page on failure
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditBranch(int id)
        {
            //call service and get branch
            //if success then pass branch to view and redirect to error page on failure
            return View();//pass the branch to the view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBranch(EditBranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                //pass to service
                //redirect to lists on success and to error page on failure
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            //pass id to service
            //if success the redirect to list or on failure redirect to error
            return RedirectToAction(nameof(Branches));
        }
    }
}