using WorkoutApp.UseCases.Exercise;

namespace WorkoutApp.RestApi.Exercise;

public class ExerciseListResponse
{
    public List<ExerciseDto> Exercises { get; set; } = [];
}