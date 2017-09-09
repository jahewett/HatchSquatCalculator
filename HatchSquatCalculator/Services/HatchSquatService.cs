using HatchSquatCalculator.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Services
{
    public class HatchSquatService : IProgramCalculator
    {
        public async Task<ProgramDetails> GetProgramDetails(ProgramBaseline baseline)
        {
            // Get program template
            var templates = await DocumentDBRepository<HatchProgramTemplate>.GetItemsAsync(programTemplate => programTemplate.TemplateName == "Hatch Squat Program");

            // Apply template to baseline
            var programDetails = CalculateProgramDetails(templates.FirstOrDefault(), baseline);
            
            return programDetails;
        }

        public async Task AddTemplate()
        {
            // Query for existing hatch template
            var templates = await DocumentDBRepository<HatchProgramTemplate>.GetItemsAsync(programTemplate
                => programTemplate.TemplateName == "Hatch Squat Program");

            if (!templates.Any())
            {
                var template = LoadTemplateFromJsonFile();
                await DocumentDBRepository<HatchProgramTemplate>.CreateItemAsync(template);
            }
        }

        private static HatchProgramTemplate LoadTemplateFromJsonFile()
        {
            using (var streamReader = new StreamReader("hatchsquattemplate.json"))
            {
                var json = streamReader.ReadToEnd();
                var template = JsonConvert.DeserializeObject<HatchProgramTemplate>(json);
                return template;
            }
        }

        private static ProgramDetails CalculateProgramDetails(HatchProgramTemplate template, ProgramBaseline baseline)
        {
            var details = new ProgramDetails();
            details.SetProgramStartDate(baseline.ProgramStartDate);
            details.SetProgramEndDate();
            details.CalculateProgramDetails(baseline, template);

            return details;
        }
    }
}
