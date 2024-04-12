using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using REST_API_ANIMALS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IAnimalDb, AnimalDb>();
builder.Services.AddSingleton<IVisitDb, VisitDb>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/manimals", (IAnimalDb animalDb) =>
{
    return Results.Ok(animalDb.GetAnimals());
});

app.MapGet("/manimals/{id}", (IAnimalDb animalDb, int id) =>
{
    var animal = animalDb.GetById(id);
    if (animal is null) return Results.NotFound();

    return Results.Ok(animal);
});

app.MapPost("/manimals", (IAnimalDb animalDb, Animal animal) =>
{
    animalDb.AddAnimal(animal);
    return Results.Created();
});

app.MapPut("/manimals{id}", (IAnimalDb animalDb, int id, Animal animal) =>
{
    var existingAnimal = animalDb.GetById(id);
    if (existingAnimal == null) return Results.NotFound();

    animalDb.UpdateAnimal(id, animal);
    return Results.Ok();
});

app.MapDelete("/manimals/{id}", (IAnimalDb animalDb, int id) =>
{
    animalDb.DeleteAnimal(id);
    return Results.NoContent();
});


app.MapGet("/visits", (IVisitDb visitDb) =>
{
    return Results.Ok(visitDb.GetVisits());
});

app.MapGet("/visits/{id}", (IVisitDb visitDb, int id) =>
{
    var visit = visitDb.GetVisitById(id);
    if (visit == null)
        return Results.NotFound();

    return Results.Ok(visit);
});

app.MapPost("/visits", (IVisitDb visitDb, Visit visit) =>
{
    visitDb.AddVisit(visit);
    return Results.Created();
});

app.MapControllers();
app.Run();
