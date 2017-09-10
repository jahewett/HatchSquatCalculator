using System;
using HatchSquatCalculator.Enums;

namespace HatchSquatCalculator.Models
{
    public class ProgramDetails : IProgramDetails
    {
        public string ProgramName { get; set; }

        public DateTime ProgramStartDate { get; private set; }

        public DateTime ProgramEndDate { get; private set; }

        public HatchProgramTemplate Program { get; private set; }

        public ProgramDetails CreateProgramDetails(HatchProgramTemplate template, ProgramBaseline baseline)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            if (baseline == null)
            {
                throw new ArgumentNullException(nameof(baseline));
            }

            var details = new ProgramDetails
            {
                ProgramName = $"{baseline.Name}", // todo set proper program name format
                ProgramStartDate = baseline.ProgramStartDate
            };

            details.SetProgramEndDate();
            details.CalculateProgramDetails(baseline, template);
            return details;
        }

        public void SetProgramEndDate()
        {
            // todo Figure out how to calculate possible end date
            ProgramEndDate = ProgramStartDate.AddMonths(3);
        }

        private void CalculateProgramDetails(ProgramBaseline baseline, HatchProgramTemplate template)
        {
            if (baseline == null)
            {
                throw new ArgumentNullException(nameof(baseline));
            }

            Program = template ?? throw new ArgumentNullException(nameof(template));

            foreach (var programWeek in Program.ProgramTemplate)
            {
                foreach (var day in programWeek.ProgramDays)
                {
                    foreach (var lift in day.Lifts)
                    {
                        var baselineWeight = lift.LiftName == Movement.BackSquat ? baseline.BackSquatMax : baseline.FrontSquatMax;
                        CalculateWeight(lift, baselineWeight);
                    }
                }
            }
        }

        private static void CalculateWeight(Lift lift, decimal baselineWeight)
        {
            if (lift == null)
            {
                throw new ArgumentNullException(nameof(lift));
            }

            foreach (var set in lift.SetDetails)
            {
                set.Weight = set.Percentage * baselineWeight;
            }
        }
    }
}
