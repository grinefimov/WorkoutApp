using MediatR;
using WorkoutApp.SharedKernel;

namespace WorkoutApp.UseCases.Exercise.Queries;

public record GetByIdExerciseQuery(int id) : IRequest<ExerciseDto?>;

public class GetByIdExerciseHandler
    (IGenericRepository<Core.Exercise> repository) : IRequestHandler<GetByIdExerciseQuery, ExerciseDto?>
{
    public async Task<ExerciseDto?> Handle(GetByIdExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercise = await repository.GetByIdAsync(request.id);

        if (exercise == null)
        {
            return null;
        }

        return new ExerciseDto { Name = exercise.Name };
    }
}