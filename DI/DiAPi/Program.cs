using DiAPi.Data;

var builder = WebApplication.CreateBuilder(args);       // create builder for the app

// DI
// when IDataRepo is asked, instantiate a NoSQLDataRepo
builder.Services.AddScoped<IDataRepo, SqlDataRepo>();      


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/getData", (IDataRepo repo) =>              // injecting repo
{
    //var repo = new SqlDataRepo();
    //var repo = new NoSqDataRepo();

    return Results.Ok(repo.ReturnData());
   
});

app.Run();