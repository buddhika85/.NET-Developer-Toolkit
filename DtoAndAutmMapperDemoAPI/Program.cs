using AutoMapper;
using DtoAndAutmMapperDemoAPI.Data;
using DtoAndAutmMapperDemoAPI.Data.Repositories;
using DtoAndAutmMapperDemoAPI.Dtos;
using DtoAndAutmMapperDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI for EF
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString")));

// DI for auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// DI for repositories
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/v1/people", async (IPeopleRepository repo, IMapper mapper) => {
    var people = await repo.GetAllAsync();
    var peopleDtos = mapper.Map<IEnumerable<PersonDto>>(people);
    return Results.Ok(peopleDtos);
});

app.MapGet("api/v1/people/{id}", async (IPeopleRepository repo, int id, IMapper mapper) => {
    Person? person = await repo.GetByIdAsync(id);
    if (person == null) 
        return Results.NotFound($"No person with ID {id}");

    // mapping - source to destination
    PersonDto personDto = mapper.Map<Person, PersonDto>(person);
    return Results.Ok(personDto);
});



app.MapPost("api/v1/people", async (IPeopleRepository repo, PersonCreateDto personCreateDto, IMapper mapper) => {
    Person person = mapper.Map<PersonCreateDto, Person>(personCreateDto);
    await repo.Create(person);

    // passing read DTO from created response
    return Results.Created($"api/v1/people/{person.Id}", mapper.Map<Person, PersonDto>(person));
});

app.MapPut("api/v1/people/{id}", async (IPeopleRepository repo, int id, PersonUpdateDto personUpdateDto, IMapper mapper) => {
    var personModel = await repo.GetByIdAsync(id);
    if (personModel == null) 
        return Results.NotFound($"No person with ID {id}");

    mapper.Map<PersonUpdateDto, Person>(personUpdateDto, personModel);

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