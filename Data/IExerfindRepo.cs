using Exerfind.Models;

namespace Exerfind.Data
{
    // Interface for our exercise repository
    // Will contain method signatures all our repositories must implement
    public interface IExerfindRepo
    {
        bool SaveChanges();

        // Get all exercises
        IEnumerable<Exercise> GetAllExercises();

        // Get exercise by ID
        Exercise GetExerciseById(int id);

        // Create exercise
        void CreateExercise(Exercise exercise);

        // Update (PUT) exercise
        void UpdateExercise(Exercise exercise);

        // Delete exercise
        void DeleteExercise(Exercise exercise);

    }
}