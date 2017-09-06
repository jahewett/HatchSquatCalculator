using HatchSquatCalculator.Models;
using System;

namespace HatchSquatCalculator.Services
{
    public class HatchSquatService : IProgramCalculator
    {
        public ProgramDetails GetProgramDetails(ProgramBaseline baseline)
        {
            // Call into db to retrieve program template
            var template = new HatchProgramTemplate();

            // Apply template to baseline
            // Return Program Details

            return new ProgramDetails();
        }
    }
}
