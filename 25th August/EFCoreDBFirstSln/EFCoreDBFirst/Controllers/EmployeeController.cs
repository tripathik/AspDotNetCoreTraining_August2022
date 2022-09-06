using EFCoreDBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirst.Controllers
{
    public class EmployeeController : Controller
    {
        public static wfmContext db = new wfmContext();
        public IActionResult Index()
        {
            return View(db.Employees.ToList());
        }
    }
}
