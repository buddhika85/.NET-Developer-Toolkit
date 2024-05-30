var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/getData", () =>
{
    return Results.Ok("Ok");
   
});

app.Run();