using DtoAndAutmMapperDemoAPI.Data;
using DtoAndAutmMapperDemoAPI.Data.Repositories;
using DtoAndAutmMapperDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString")));

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/v1/people", async (IPeopleRepository repo) => {
    return Results.Ok(await repo.GetAllAsync());
});

app.MapGet("api/v1/people/{id}", async (IPeopleRepository repo, int id) => {
    var person = await repo.GetByIdAsync(id);
    if (person == null) 
        return Results.NotFound($"No person with ID {id}");
    return Results.Ok(person);
});



app.MapPost("api/v1/people", async (IPeopleRepository repo, Person person) => {
    await repo.Create(person);
    return Results.Created($"api/v1/people/{person.Id}", person);
});

app.MapPut("api/v1/people/{id}", async (IPeopleRepository repo, int id, Person person) => {
    var personToUpdate = await repo.GetByIdAsync(id);
    if (personToUpdate == null) 
        return Results.NotFound($"No person with ID {id}");

    // manual object mapping
    personToUpdate.FullName = person.FullName;
    personToUpdate.Telephone = person.Telephone;
    personToUpdate.DOB = person.DOB;

    await repo.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/v1/people/{id}", async (IPeopleRepository repo, int id) => {
    var personToDelete = await repo.GetByIdAsync(id);
    if (personToDelete == null) 
        return Results.NotFound($"No person with ID {id}");

    repo.Delete(personToDelete);
    await repo.SaveChangesAsync();
    return Results.Ok(personToDelete);
});

app.UseHttpsRedirection();

app.Run();