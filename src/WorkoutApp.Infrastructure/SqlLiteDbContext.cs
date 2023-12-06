using Microsoft.EntityFrameworkCore;
using WorkoutApp.Core.Entities;

namespace WorkoutApp.Infrastructure;

public class SqlLiteDbContext : DbContext
{
    public string DbPath { get; }

    public SqlLiteDbContext()
    {
        var path = Environment.CurrentDirectory;
        //var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "WorkoutApp.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<Sample> Samples { get; set; }
}