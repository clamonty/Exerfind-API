using AutoMapper;
using Exerfind.Dtos;
using Exerfind.Models;

namespace Exerfind.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            // Map Source --> Target

            CreateMap<Exercise, ExerciseReadDto>();
            CreateMap<ExerciseCreateDto, Exercise>();
            CreateMap<ExerciseUpdateDto, Exercise>();
            CreateMap<Exercise, ExerciseUpdateDto>();
        }
    }
}