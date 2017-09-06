using System.Collections.Generic;

namespace HatchSquatCalculator.Models
{
    public class HatchProgramTemplate
    {
        public string TemplateName { get; set; }
        public List<ProgramWeek> ProgramTemplate { get; set; }
    }
}
