using CommandAPINoRepository.Data;
using CommandAPINoRepository.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));  // 

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// get multiple
app.MapGet("api/v1/commands", async (AppDbContext context) => {
    var commands = await context.Commands.ToListAsync();
    return Results.Ok(commands);
});

// get single
app.MapGet("api/v1/commands/{id}", async (AppDbContext context, string id) => {
    var command = await context.Commands.FirstOrDefaultAsync(x => x.CommandId == id);
    if (command == null)
        return Results.NotFound($"No such command with {id}");
    return Results.Ok(command);
});

// create
app.MapPost("api/v1/commands", async (AppDbContext context, Command command) => {
    await context.Commands.AddAsync(command);
    await context.SaveChangesAsync();
    // rest conventions - rout to access new command and new command object
    return Results.Created($"api/v1/commands/{command.Id}", command);
});

// // update
// app.MapGet("api/v1/commands", async (AppDbContext context) => {
    
// });

// // delete
// app.MapGet("api/v1/commands", async (AppDbContext context) => {
    
// });

app.UseHttpsRedirection();
app.Run();