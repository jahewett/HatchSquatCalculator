using System.Threading.Tasks;
using HatchSquatCalculator.Models;
using HatchSquatCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace HatchSquatCalculator.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Calculator()
        {
            return View();
        }

        public async Task<IActionResult> Calculate(ProgramBaseline baseline)
        {
            if (ModelState.IsValid)
            {
                // Use hatch calculator service to calculate program details and return view with model 
                var calc = new HatchSquatService();
                var details = await calc.GetProgramDetails(baseline);

                return View("Details", details);
            }

            return View("Calculator");
        }
    }
}