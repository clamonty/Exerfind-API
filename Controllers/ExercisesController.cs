using AutoMapper;
using Exerfind.Data;
using Exerfind.Dtos;
using Exerfind.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Exerfind.Controllers
{
    // Define controller level route /api/exercises
    [Route("/api/exercises")]
    // Decorate with ApiController for default behaviors
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        // Define a private readonly variable representing our repository
        private readonly IExerfindRepo _repository;
        // Define a private readonly variable for AutoMapper dependency injection
        private readonly IMapper _mapper;

        // Constructor dependency injection 
        public ExercisesController(IExerfindRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET /api/exercises
        [HttpGet]
        public ActionResult<IEnumerable<ExerciseReadDto>> GetAllExercises()
        {
            var exercises = _repository.GetAllExercises();
            // Return exercises mapped to ExercideReadDto
            return Ok(_mapper.Map<IEnumerable<ExerciseReadDto>>(exercises));
        }

        // GET /api/exercises/{id}
        [HttpGet("{id}", Name = "GetExerciseById")]
        public ActionResult<ExerciseReadDto> GetExerciseById(int id)
        {
            var exercise = _repository.GetExerciseById(id);
            // If exercise is a valid object, return status 200 with exercise payload
            if (exercise != null)
            {
                return Ok(_mapper.Map<ExerciseReadDto>(exercise));
            }
            // If exercise is not a valid object, return status 204 not found
            return NotFound();
        }

        // POST /api/exercises/
        // Return an instance of the object created (in this case ExerciseReadDto)
        [HttpPost]
        public ActionResult<ExerciseReadDto> CreateExercise(ExerciseCreateDto exerciseCreateDto)
        {
            // Map the createDto Source --> Exercise target
            var exerciseModel = _mapper.Map<Exercise>(exerciseCreateDto);

            // Use the repository createExercise method
            _repository.CreateExercise(exerciseModel);

            // Save changes to database
            _repository.SaveChanges();

            // Map the exerciseModel created above to an exerciseReadDto
            var exerciseReadDto = _mapper.Map<ExerciseReadDto>(exerciseModel);


            // Use CreatedAtRoute method to return a proper location label in the header
            return CreatedAtRoute(nameof(GetExerciseById), new { Id = exerciseModel.Id }, exerciseReadDto);

            // Return the mapped exerciseModel --> ExercideReadDto
            // return CreatedAtRoute(exerciseReadDto);
        }

        // PUT api/exercises/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateExercise(int id, ExerciseUpdateDto exerciseUpdateDto)
        {

            // Try and fetch exercise with matching ID from repo
            var exerciseModelRepo = _repository.GetExerciseById(id);

            // If fetched exercise is null, return not found error
            if (exerciseModelRepo == null)
                return NotFound();

            // Map the updated DTO to our fetched exercise from DB
            _mapper.Map(exerciseUpdateDto, exerciseModelRepo);

            // Pass in the updated data to UpdateExercise
            _repository.UpdateExercise(exerciseModelRepo);

            // Save the update changes
            _repository.SaveChanges();

            // Return 204 status code
            return NoContent();
        }

        // PATCH api/commands/{id}
        // patch document supplied by request
        [HttpPatch("{id}")]
        public ActionResult PartialExerciseUpdate(int id, JsonPatchDocument<ExerciseUpdateDto> patchDocument)
        {
            var exerciseModelRepo = _repository.GetExerciseById(id);

            // If no exercise matching id, return 404 not found
            if (exerciseModelRepo == null)
                return NotFound();

            // Map the exercise fetched from database to an exercise update DTO
            var exerciseToPatch = _mapper.Map<ExerciseUpdateDto>(exerciseModelRepo);

            // Apply the patch document to the exercise update DTO
            patchDocument.ApplyTo(exerciseToPatch, ModelState);

            // If model validation fails, return validation problem
            if (!TryValidateModel(exerciseToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // Map the patched exercise to the exercise in our repo
            _mapper.Map(exerciseToPatch, exerciseModelRepo);

            // Redundant call to update command
            _repository.UpdateExercise(exerciseModelRepo);

            // Save changes and return no content response
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteExercise(int id)
        {
            var exerciseModelRepo = _repository.GetExerciseById(id);

            // Return 404 if exercise is not found
            if (exerciseModelRepo == null)
                return NotFound();

            // Delete the matching exercise from the repository;
            _repository.DeleteExercise(exerciseModelRepo);

            // Save the changes and return 204 no content

            _repository.SaveChanges();

            return NoContent();
        }

    }
}

