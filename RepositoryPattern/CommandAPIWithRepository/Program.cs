using CommandAPINoRepository.Data;
using CommandAPINoRepository.Models;
using CommandAPIWithRepository.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));  
builder.Services.AddScoped<ICommandRepo, SqlCommandRepo>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// get multiple
app.MapGet("api/v1/commands", async (ICommandRepo repo) => {   
    return Results.Ok(await repo.GetAllAsync());
});

// get single
app.MapGet("api/v1/commands/{id}", async (ICommandRepo repo, int id) => {
    var command = await repo.GetByIdAsync(id);
    if (command == null)
        return Results.NotFound($"No such command with {id}");
    return Results.Ok(command);
});

// create
app.MapPost("api/v1/commands", async (ICommandRepo repo, Command command) => {
    await repo.CreateAsync(command);
    await repo.SaveChanges();
    // rest conventions - rout to access new command and new command object
    return Results.Created($"api/v1/commands/{command.Id}", command);
});

// update
app.MapPut("api/v1/commands/{id}", async (AppDbContext context, int id, Command command) => {
    var commandFromDb = await context.Commands.FirstOrDefaultAsync(x => x.Id == id);
    if (commandFromDb == null)
        return Results.NotFound($"No such command with {id}");

    // update and save changes
    commandFromDb.HowTo = command.HowTo;
    commandFromDb.Platform = command.Platform;
    commandFromDb.CommandLine = command.CommandLine;
    await context.SaveChangesAsync();

    // rest recomendation for out
    return Results.NoContent();
});

// delete
app.MapDelete("api/v1/commands", async (ICommandRepo repo, int id) => {
    var commandToDelete = await repo.GetByIdAsync(id);
    if (commandToDelete == null)
        return Results.NotFound($"No such command with {id}");

    repo.Delete(commandToDelete);
    await repo.SaveChanges();

    // return resouce which was deleted
    return Results.Ok(commandToDelete);
});

app.UseHttpsRedirection();
app.Run();