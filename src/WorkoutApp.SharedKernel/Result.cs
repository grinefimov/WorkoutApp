namespace WorkoutApp.SharedKernel
{
    public class Result<T>(T value)
    {
        public Result(IEnumerable<string> errors,
                      ResultStatus status)
        {
            Errors = errors;
            Status = status;
        }

        public ResultStatus Status { get; set; } = ResultStatus.Ok;
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public T Value { get; set; }
    }

    public enum ResultStatus
    {
        Ok,
        Error,
        Forbidden,
        Unauthorized,
        Invalid,
        NotFound,
        Conflict,
        CriticalError,
        Unavailable
    }
}
