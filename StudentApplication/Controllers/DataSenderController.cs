using Microsoft.AspNetCore.Mvc;

namespace StudentApplication.Controllers
{
    public class DataSenderController : Controller
    {
        public IActionResult ViewBagAction()//Functions in a controller are called actions
        {
            ViewBag.Name = "Nass";//Add key value to page dictionary
            var data = ViewBag.Name;
            return View();
        }
        public IActionResult ViewDataAction()
        {
            ViewData["Address"] = "Nagpur";
            var data = ViewData["Address"];
            return View();
        }
        public IActionResult ViewBagViewData()
        {
            ViewBag.Name = "Nass";
            var data = ViewData["Name"];
            return View();
        }
        public IActionResult TempDataAction()
        {
            TempData["Location"] = "Nagpur";
            //when a value of key is red from tempdata, the key is marked for deletion. Then GC will delete it.
            var data = TempData["Location"];//After reading, "Location" Key will be marked for deletion
            //after above line "Location" key will be deleted
            var data1 = TempData["Location"];//No key will be available with name "Location"


            //If we want to keep the key for next read operation
            TempData["Age"] = 11;
            var age = TempData["Age"];//this will mark the Key "Age" for deletion            
            TempData.Keep("Age");//this will delete the mark of deletion
            //In Keep if we pass the name of key "Age" then it will delete the mark from the specified key only.
            //or if we do not pass any parameter then it will delete marks of deletion of all keys.


            //To avoid two instructions for reading and keeping we can use peek
            TempData["Count"] = 100;
            var count = TempData.Peek("Count");//it will read the value of the key, without marking for deletion.

            return View();
        }
        public IActionResult TempDataDemo1()
        {
            TempData["Record"] = "Test record";
            TempData["Record1"] = "Test record 1";
            TempData["Record2"] = "Test record 2";

            return View();
        }
        public IActionResult TempDataDemo2()
        {
            return View();
        }
        public IActionResult TempDataDemo3()
        {
            return View();
        }
        public IActionResult TempDataClear()
        {
            TempData.Clear();
            return Ok();
        }
        public IActionResult TempDataCheck()
        {
            if (TempData.ContainsKey("Record2"))
            {
                return Ok(TempData.Peek("Record2"));
            }
            return NotFound("No record found for Record2");
        }
    }
}
