using System.Collections.Generic;
using HatchSquatCalculator.Enums;

namespace HatchSquatCalculator.Models
{
    public class Lift
    {
        public Movement LiftName { get; set; } // todo display name
        public List<SetDetail> SetDetails { get; set; }
    }
}
