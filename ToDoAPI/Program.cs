using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDB"));

var app = builder.Build();

// get all
app.MapGet("api/todo", async(AppDbContext context) => {
    return Results.Ok(await context.ToDos.ToListAsync());
});

// get by Id
app.MapGet("api/todo/{id}", async(AppDbContext context, int id) => {
    ToDo? todo = await  context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    if (todo == null) 
        return Results.NotFound($"No ToDo with ID {id}");
    return Results.Ok(todo);
});

// create
app.MapPost("api/todo", async(AppDbContext context, ToDo todo) => {
    await context.ToDos.AddAsync(todo);
    await context.SaveChangesAsync();
    // passing read DTO from created response
    return Results.Created($"api/todo/{todo.Id}", todo);
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.Run();
