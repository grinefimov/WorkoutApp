using WorkoutApp.SharedKernel;

namespace WorkoutApp.Core.Entities;

public class Exercise : EntityBase<int>
{
    public string Name { get; set; }
}