using System.Reflection;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using WorkoutApp.Infrastructure;
using WorkoutApp.SharedKernel;
using WorkoutApp.UseCases.Exercise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(ExerciseDto).Assembly);
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<SqlLiteDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseDefaultExceptionHandler();
    app.UseHsts();
}
app.UseFastEndpoints();
app.UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();
