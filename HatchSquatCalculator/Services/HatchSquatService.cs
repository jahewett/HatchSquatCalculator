using HatchSquatCalculator.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
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
            // Query for existing hatch template
            var exists = await DocumentDBRepository<HatchProgramTemplate>.GetItemsAsync(programTemplate
                => programTemplate.TemplateName == "Hatch Squat Program");

            if (!exists.Any())
            {
                var template = LoadTemplateFromJsonFile();
                await DocumentDBRepository<HatchProgramTemplate>.CreateItemAsync(template);
            }
        }

        public HatchProgramTemplate LoadTemplateFromJsonFile()
        {
            using (StreamReader r = new StreamReader("hatchsquattemplate.json"))
            {
                string json = r.ReadToEnd();
                var template = JsonConvert.DeserializeObject<HatchProgramTemplate>(json);
                return template;
            }
        }
    }
}
