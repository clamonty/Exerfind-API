using Exerfind.Models;
using System.Linq;
namespace Exerfind.Data
{
    public class SqlExerfindRepo : IExerfindRepo
    {

        // private readonly ExerfindContext variable for dependency injection
        private readonly ExerfindContext _context;
        // Dependency injection of ExerfindContext 
        public SqlExerfindRepo(ExerfindContext context)
        {
            _context = context;
        }

        public void CreateExercise(Exercise exercise)
        {
            // Check that exercise argument is valid and not null
            if (exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise));
            }

            _context.Exercises.Add(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            // Check if supplied exercise is null
            if (exercise == null)
                throw new ArgumentNullException(nameof(exercise));

            // Remove exercise from context
            _context.Exercises.Remove(exercise);
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _context.Exercises.ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(p => p.Id == id);
            System.Console.WriteLine(exercise);
            return exercise;
        }

        // method to save changes to the database
        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateExercise(Exercise exercise)
        {
            // Nothing
        }
    }
}