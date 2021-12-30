using Exerfind.Models;

namespace Exerfind.Data
{
    // Mock implementation of ExerfindRepo interface
    // Done to see whether or not the methods are working
    public class MockExerfindRepo : IExerfindRepo
    {
        public void CreateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void DeleteExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            var exercises = new List<Exercise>{
                new Exercise
                {
                    Id = 0,
                    Name = "Barbell Curl",
                    Muscles = "Biceps",
                    InstructionUrl = "https://www.muscleandstrength.com/exercises/standing-barbell-curl.html"
                },
                new Exercise
                {
                    Id = 1,
                    Name = "Squat",
                    Muscles = "Legs, Glutes",
                    InstructionUrl = "https://www.muscleandstrength.com/exercises/squat.html"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Deadlift",
                    Muscles = "Legs, Glutes, Back",
                    InstructionUrl = "https://www.muscleandstrength.com/exercises/deadlifts.html"
                }
            };

            return exercises;
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = new Exercise
            {
                Id = 0,
                Name = "Barbell Curl",
                Muscles = "Biceps",
                InstructionUrl = "https://www.muscleandstrength.com/exercises/standing-barbell-curl.html"
            };

            return exercise;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}