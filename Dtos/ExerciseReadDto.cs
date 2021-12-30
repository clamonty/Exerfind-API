namespace Exerfind.Dtos
{
    // Create a 'Read Exercise" data transfer object model
    // Missing the Id attribute from Exercise model as its irrelevant 

    public class ExerciseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Muscles { get; set; }
        public string InstructionUrl { get; set; }
    }
}