using FastEndpoints;
using MediatR;
using WorkoutApp.UseCases.Exercise;
using WorkoutApp.UseCases.Exercise.Queries;

namespace WorkoutApp.RestApi.Exercise
{
    public class GetById(IMediator mediator) : Endpoint<GetByIdExerciseRequest, ExerciseDto?>
    {
        public override void Configure()
        {
            Get(GetByIdExerciseRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetByIdExerciseRequest req, CancellationToken cancellationToken)
        {
            var exerciseDto = await mediator.Send(new GetByIdExerciseQuery(req.Id), cancellationToken);

            if (exerciseDto is null)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            Response = exerciseDto;
        }
    }
}
