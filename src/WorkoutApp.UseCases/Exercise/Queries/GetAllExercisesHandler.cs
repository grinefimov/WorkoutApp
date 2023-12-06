using MediatR;

namespace WorkoutApp.UseCases.Exercise.Queries;

public record GetAllExercisesQuery() : IRequest<ExerciseDto>;

public class GetAllExercisesHandler : IRequestHandler<GetAllExercisesQuery, ExerciseDto>
{


    Task<ExerciseDto> IRequestHandler<GetAllExercisesQuery, ExerciseDto>.Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

