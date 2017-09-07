using System.Collections.Generic;

namespace HatchSquatCalculator.Models
{
    public class ProgramWeek
    {
        public string WeekId { get; set; }
        public List<ProgramDay> ProgramDays { get; set; }
    }
}
