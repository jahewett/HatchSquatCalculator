using System;
using HatchSquatCalculator.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Services
{
    public class HatchSquatService : IProgramCalculator
    {
        private readonly IProgramDetails _programDetails;
        private const string TemplateName = "Hatch Squat Program";
        private const string TemplateFileName = "hatchsquattemplate.json";

        public HatchSquatService(IProgramDetails programDetails)
        {
            _programDetails = programDetails;
        }

        public async Task<ProgramDetails> GetProgramDetails(ProgramBaseline baseline)
        {
            if (baseline == null)
            {
                throw new ArgumentNullException(nameof(baseline));
            }

            var templates = await DocumentDBRepository<HatchProgramTemplate>.GetItemsAsync(
                programTemplate => programTemplate.TemplateName == TemplateName);

            var programDetails = CalculateProgramDetails(templates.FirstOrDefault(), baseline);
            
            return programDetails;
        }

        public async Task AddProgramTemplate()
        {
            // If program template does not exist in document database, add it from file
            var templates = await DocumentDBRepository<HatchProgramTemplate>.GetItemsAsync(
                programTemplate => programTemplate.TemplateName == TemplateName);

            if (!templates.Any())
            {
                var template = LoadTemplateFromJsonFile();
                await DocumentDBRepository<HatchProgramTemplate>.CreateItemAsync(template);
            }
        }

        private static HatchProgramTemplate LoadTemplateFromJsonFile()
        {
            // todo catch file does not exist exception
            using (var streamReader = new StreamReader(TemplateFileName))
            {
                var json = streamReader.ReadToEnd();
                var template = JsonConvert.DeserializeObject<HatchProgramTemplate>(json);
                return template;
            }
        }

        private ProgramDetails CalculateProgramDetails(HatchProgramTemplate template, ProgramBaseline baseline)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            if (baseline == null)
            {
                throw new ArgumentNullException(nameof(baseline));
            }

            return _programDetails.CreateProgramDetails(template, baseline);
        }
    }
}
