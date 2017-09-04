using HatchSquatCalculator.Models;
using System;

namespace HatchSquatCalculator.Services
{
    public class HatchSquatService : IProgramCalculator
    {
        public ProgramDetails GetProgramDetails(ProgramBaseline baseline)
        {
            // Call into db to retrieve program template
            // Apply template to baseline
            // Return Program Details

            return new ProgramDetails();
        }
    }
}
