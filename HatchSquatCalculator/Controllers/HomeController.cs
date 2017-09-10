using HatchSquatCalculator.Models;
using HatchSquatCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Controllers
{
    public class HomeController : Controller
    {
        private static bool _startup = true;
        private readonly IProgramCalculator _programCalculator;

        public HomeController(IProgramCalculator programCalculator)
        {
            _programCalculator = programCalculator;
        }

        public async Task<IActionResult> Index()
        {
            if (!_startup)
            {
                return View();
            }

            await _programCalculator.AddProgramTemplate();
            _startup = false;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
