using System.Threading.Tasks;
using HatchSquatCalculator.Models;

namespace HatchSquatCalculator.Services
{
    public interface IProgramCalculator
    {
        Task<ProgramDetails> GetProgramDetails(ProgramBaseline baseline); // Needs to take and receive interfaces to allow reuse
    }
}
