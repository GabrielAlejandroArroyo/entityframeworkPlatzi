using entityframeworkPlatzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Base de datos en memoria
builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));


// builder.Services.AddCors(options =>
// {
// options.AddPolicy("MyAllowedOrigins",
//     policy =>
//     {
//         policy.WithOrigins("https://192.168.1.75:5190") // note the port is included 
//             .AllowAnyHeader()
//             .AllowAnyMethod();
//     });
// });


var app = builder.Build();
// app.UseCors("MyAllowedOrigins");

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

app.Run();
