using System.ComponentModel.DataAnnotations;

namespace Exerfind.Dtos
{
    // Create a 'Read Exercise" data transfer object model
    // Missing the Id attribute from Exercise model as its irrelevant 

    public class ExerciseCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Muscles { get; set; }
        [Required]
        public string InstructionUrl { get; set; }
    }
}