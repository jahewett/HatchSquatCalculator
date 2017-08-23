using System;
using System.ComponentModel.DataAnnotations;

namespace HatchSquatCalculator.Models
{
    public class ProgramBaseline
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime ProgramStartDate { get; set; }
        [Required]
        public decimal BackSquatMax { get; set; }
        [Required]
        public decimal FrontSquatMax { get; set; }
    }
}