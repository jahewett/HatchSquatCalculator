using HatchSquatCalculator.Models;
using HatchSquatCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Controllers
{
    public class HomeController : Controller
    {
        private static bool startup = true;

        public async Task<IActionResult> Index()
        {
            if (startup)
            {
                await new HatchSquatService().AddTemplate();
                startup = false;
            }
          
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
