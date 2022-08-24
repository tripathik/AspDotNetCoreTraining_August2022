using FirstMVCProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProj.Controllers
{
    public class EmployeeController : Controller
    {
        public static Emp e1 = new Emp();
        public static Emp e2 = new Emp();
        public static List<Emp> empList = new List<Emp>();
        public IActionResult EmpDetail()
        {
            e1.EmpId = 100;
            e1.EmpName = "Krishna";
            e1.Salary = 90000;
            e2.EmpId = 101;
            e2.EmpName = "Tripti";
            e2.Salary = 80000;
            empList.Add(e1);
            empList.Add(e2);
            return View(empList);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Emp e)
        {
            Emp.AddEmployee(e);
            return RedirectToAction("EmpDetail");
        }
        public IActionResult Details(int id)
        {
            Emp e = empList.Where(x => x.EmpId == id).FirstOrDefault();
            return View(e);
        }
    }
}
