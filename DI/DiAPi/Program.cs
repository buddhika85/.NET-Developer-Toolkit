using DiAPi.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/getData", () =>
{
    var repo = new NoSqDataRepo();

    return Results.Ok(repo.ReturnData());
   
});

app.Run();