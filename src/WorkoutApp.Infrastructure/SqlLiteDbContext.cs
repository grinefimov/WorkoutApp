using Microsoft.EntityFrameworkCore;
using WorkoutApp.Core;

namespace WorkoutApp.Infrastructure;

public class SqlLiteDbContext : DbContext
{
    public string DbPath { get; }

    public SqlLiteDbContext()
    {
    }

    public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
    {
        var path = Environment.CurrentDirectory;
        //var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "WorkoutApp.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<Exercise> Exercises { get; set; }
}