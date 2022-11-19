using entityframeworkPlatzi;
using entityframeworkPlatzi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

int dbType = builder.Configuration.GetValue<int>("DbType");
switch (dbType)
{
    case 1:
        // Base de datos en memoria
        builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
        break;
    case 2:
        // Base de datos en MSSQL Server
        //builder.Services.AddSqlServer<TareasContext>("Data Source=xxxxx\\xxxxx;Initial Catalog=xxxxxx;user id=xxxxx;password=xxxx");
        builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlConnection"));
        break;
    case 3:
        // Base de datos en Postgres
        //builder.Services.AddSqlServer<TareasContext>("Data Source=xxxxx\\xxxxx;Initial Catalog=xxxxxx;user id=xxxxx;password=xxxx");
        //builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlConnection"));
        break;
    case 4:
        // Base de datos en Mysql
        //builder.Services.AddSqlServer<TareasContext>("Data Source=xxxxx\\xxxxx;Initial Catalog=xxxxxx;user id=xxxxx;password=xxxx");
        //builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlConnection"));
        break;
    default:
        // Base de datos en memoria
        builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
        break;
}
// Base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
// Base de datos en MSSQL Server
//builder.Services.AddSqlServer<TareasContext>("Data Source=xxxxx\\xxxxx;Initial Catalog=xxxxxx;user id=xxxxx;password=xxxx");
//builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlConnection"));




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

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas);

});

app.MapGet("/api/tareas/prioridad1", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == entityframeworkPlatzi.Models.Prioridad.baja));

});

app.MapGet("/api/tareas/prioridad/categoria", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == entityframeworkPlatzi.Models.Prioridad.baja));

});

app.MapGet("/api/categorias", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);

});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    // Opcion al primer AddAsync
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});


app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();

});

app.Run();


