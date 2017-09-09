using System;

namespace HatchSquatCalculator.Models
{
    public class ProgramDetails
    {
        public DateTime ProgramStartDate { get; private set; }

        public DateTime ProgramEndDate { get; private set; }

        public HatchProgramTemplate HatchProgramTemplate { get; private set; }

        public void SetProgramStartDate(DateTime startDate)
        {
            ProgramStartDate = startDate;
        }

        public void SetProgramEndDate()
        {
            // Figure out how to calculate possible end date
            ProgramEndDate = ProgramStartDate.AddMonths(3);
        }

        public void CalculateProgramDetails(ProgramBaseline baseline, HatchProgramTemplate template)
        {
            HatchProgramTemplate = template;

            foreach (var programWeek in HatchProgramTemplate.ProgramTemplate)
            {
                foreach (var day in programWeek.ProgramDays)
                {
                    foreach (var lift in day.Lifts)
                    {
                        var baselineWeight = lift.Name == "Back Squat" ? baseline.BackSquatMax : baseline.FrontSquatMax;
                        CalculateWeight(lift, baselineWeight);
                    }
                }
            }
        }

        private void CalculateWeight(Lift lift, decimal baselineWeight)
        {
            
            foreach (var set in lift.SetDetails)
            {
                set.Weight = set.Percentage * baselineWeight;
            }
        }
    }
}
