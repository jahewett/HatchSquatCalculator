using HatchSquatCalculator.Models;
using System.Threading.Tasks;

namespace HatchSquatCalculator.Services
{
    public interface IProgramCalculator
    {
        Task<ProgramDetails> GetProgramDetails(ProgramBaseline baseline); // Needs to take and receive interfaces to allow reuse
        Task AddProgramTemplate();
    }
}
