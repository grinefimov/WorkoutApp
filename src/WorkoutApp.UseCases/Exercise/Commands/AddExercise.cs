using MediatR;
using WorkoutApp.SharedKernel;

namespace WorkoutApp.UseCases.Exercise.Commands;

public record AddExerciseCommand(ExerciseDto Exercise) : IRequest;

public class AddExerciseHandler(IGenericRepository<Core.Exercise> repository) : IRequestHandler<AddExerciseCommand>
{
    public async Task Handle(AddExerciseCommand request, CancellationToken cancellationToken)
    {
        await repository.AddAsync(new Core.Exercise { Name = request.Exercise.Name });
    }
}