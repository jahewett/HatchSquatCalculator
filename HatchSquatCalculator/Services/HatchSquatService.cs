using HatchSquatCalculator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddTemplate()
        {
            // Load template from csv file
            // Import to azure document db
            await DocumentDBRepository<HatchProgramTemplate>.CreateItemAsync(new HatchProgramTemplate
            {
                TemplateName = "Hatch Squat Program",
                ProgramTemplate = new List<ProgramWeek>
                {
                    new ProgramWeek
                    {
                        ProgramDays = new List<ProgramDay>
                        {
                            new ProgramDay
                            {
                                Lifts = new List<Lift>
                                {
                                    new Lift
                                    {
                                        Name = "Back Squat",
                                        SetDetails = new List<SetDetail>
                                        {
                                            new SetDetail
                                            {
                                                Percentage = 60,
                                                Reps = 10
                                            },
                                            new SetDetail
                                            {
                                                Percentage = 65,
                                                Reps = 8
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}
