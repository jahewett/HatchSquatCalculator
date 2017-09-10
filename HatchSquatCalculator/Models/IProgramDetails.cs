namespace HatchSquatCalculator.Models
{
    public interface IProgramDetails
    {
        ProgramDetails CreateProgramDetails(HatchProgramTemplate template, ProgramBaseline baseline);
        void SetProgramEndDate();
    }
}
