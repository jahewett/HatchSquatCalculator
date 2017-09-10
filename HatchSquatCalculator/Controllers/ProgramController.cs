using HatchSquatCalculator.Models;
using HatchSquatCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramCalculator _programCalculator;

        public ProgramController(IProgramCalculator programCalculator)
        {
            _programCalculator = programCalculator;
        }
        public IActionResult Calculator()
        {
            return View();
        }

        public async Task<IActionResult> Calculate(ProgramBaseline baseline)
        {
            if (ModelState.IsValid)
            {
                var programDetails = await _programCalculator.GetProgramDetails(baseline);

                return View("Details", programDetails);
            }

            return View("Calculator");
        }
    }
}