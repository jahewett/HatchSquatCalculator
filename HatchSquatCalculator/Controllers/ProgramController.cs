using HatchSquatCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace HatchSquatCalculator.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Calculator()
        {
            return View();
        }

        public IActionResult Calculate(ProgramBaseline baseline)
        {
            return Ok();
        }
    }
}