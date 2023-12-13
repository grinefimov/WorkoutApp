using FastEndpoints;
using MediatR;
using WorkoutApp.UseCases.Exercise.Queries;

namespace WorkoutApp.RestApi.Exercise;

/// <summary>
/// List all Exercises
/// </summary>
public class List(IMediator mediator) : EndpointWithoutRequest<ExerciseListResponse>
{
    public override void Configure()
    {
        Get("/Exercises");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var exerciseDtos = await mediator.Send(new GetAllExercisesQuery(), cancellationToken);

        Response = new ExerciseListResponse
        {
            Exercises = exerciseDtos.ToList()
        };
    }
}