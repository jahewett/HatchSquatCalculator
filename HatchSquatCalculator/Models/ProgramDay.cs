using System.Collections.Generic;

namespace HatchSquatCalculator.Models
{
    public class ProgramDay
    {
        public string DayId { get; set; }
        public List<Lift> Lifts { get; set; }
    }
}
