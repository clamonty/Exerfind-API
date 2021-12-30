using System.ComponentModel.DataAnnotations;

namespace Exerfind.Dtos
{
    public class ExerciseUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Muscles { get; set; }
        [Required]
        public string InstructionUrl { get; set; }
    }
}