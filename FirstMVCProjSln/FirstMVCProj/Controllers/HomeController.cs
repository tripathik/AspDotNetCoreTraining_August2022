using FirstMVCProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVCProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public EmptyResult initialize()
        {
            int i = 10;
            return new EmptyResult();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Sample()
        {
            ViewData["CompanyName"] = "Softura";
            ViewBag.j = 100;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}