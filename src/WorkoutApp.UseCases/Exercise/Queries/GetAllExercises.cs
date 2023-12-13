using MediatR;
using WorkoutApp.SharedKernel;

namespace WorkoutApp.UseCases.Exercise.Queries;

public record GetAllExercisesQuery() : IRequest<IEnumerable<ExerciseDto>>;

public class GetAllExercisesHandler
    (IGenericRepository<Core.Exercise> repository) : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
{
    public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery request,
        CancellationToken cancellationToken)
    {
        var exercises = await repository.GetAllAsync();
        return exercises.Select(e => new ExerciseDto { Name = e.Name });
    }
}