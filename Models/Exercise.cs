using System.ComponentModel.DataAnnotations;

namespace Exerfind.Models
{
    // Model for Exercise data
    // Will contain id, exercise name, muscle group worked, and link to video demonstration
    public class Exercise
    {
        // Decorate as primary key
        [Key]
        public int Id { get; set; }
        // Decorate rest as required
        [Required]
        public string Name { get; set; }
        [Required]
        public string Muscles { get; set; }
        [Required]
        public string InstructionUrl { get; set; }
    }
}