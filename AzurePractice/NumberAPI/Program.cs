using Microsoft.EntityFrameworkCore;
using NumberAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Numbers"));

var app = builder.Build();


app.UseHttpsRedirection();



app.Run();
