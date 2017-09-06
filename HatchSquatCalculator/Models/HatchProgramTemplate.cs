using System.Collections.Generic;

namespace HatchSquatCalculator.Models
{
    public class HatchProgramTemplate
    {
        // 12 weeks
        // 2 days a week
        // each day back squat & front squat
        // Each day, each exercise sets reps percentage
        public List<ProgramWeek> ProgramTemplate { get; set; }
    }
}
