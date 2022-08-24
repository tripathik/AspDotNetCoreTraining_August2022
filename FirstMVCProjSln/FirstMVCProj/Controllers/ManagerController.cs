using FirstMVCProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProj.Controllers
{
    public class ManagerController : Controller
    {
        public static List<Manager> managers = Manager.GetManagers();
        public IActionResult ManagerDetail()
        {
            return View(managers);
        }

        [HttpGet]
        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager manager)
        {
            Manager.AddManagers(manager);
            return RedirectToAction("ManagerDetail");
        }

        public IActionResult Details(int id)
        {
            Manager manager = managers.Where(x => x.Manager_Id == id).FirstOrDefault();
            return View(manager);
        }

        public IActionResult Edit(int id)
        {
            Manager manager = managers.Where(x =>x.Manager_Id == id).FirstOrDefault();
            return View(manager);
        }
        [HttpPost]
        public IActionResult Edit(Manager manager)
        {
            Manager.EditManager(manager);
            return RedirectToAction("ManagerDetail");
        }

        public IActionResult Delete(int id)
        {
            Manager.DeleteManager(id);
            return RedirectToAction("ManagerDetail");
        }
    }
}
