using HatchSquatCalculator.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HatchSquatCalculator.Models
{
    public class ProgramBaseline
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProgramStartDate { get; set; }
        [Required]
        public decimal BackSquatMax { get; set; }
        [Required]
        public decimal FrontSquatMax { get; set; }
        [Required]
        public Unit Units { get; set; }
    }
}