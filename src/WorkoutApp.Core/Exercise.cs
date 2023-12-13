using WorkoutApp.SharedKernel;

namespace WorkoutApp.Core;

public class Exercise : EntityBase<int>
{
    public string Name { get; set; }
}