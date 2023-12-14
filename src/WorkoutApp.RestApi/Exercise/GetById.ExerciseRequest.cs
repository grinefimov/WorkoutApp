namespace WorkoutApp.RestApi.Exercise
{
    public class GetByIdExerciseRequest
    {
        public const string Route = "/Exercises/{id:int}";
        public static string BuildRoute(int exerciseId) => Route.Replace("{id:int}", exerciseId.ToString());

        public int Id { get; set; }
    }
}
