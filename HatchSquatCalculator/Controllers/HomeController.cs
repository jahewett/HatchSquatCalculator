using HatchSquatCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HatchSquatCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // test connextion to gitlab
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
