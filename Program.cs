using Microsoft.EntityFrameworkCore;
using Barbearia.Models;
using Barbearia.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Agendamento.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/agendamento" , async (AppDbContext db) => await db.Agendamentos.ToListAsync());

app.MapGet("/agendamentos/{id}", async (int id, AppDbContext db) =>
{
    var agendamento = await db.Agendamentos.FindAsync(id);

    if (agendamento != null)
    {
        return Results.Ok(agendamento);
    }
    else
        return Results.NotFound($"Agendamento com ID {id} não encontrado.");

});

app.MapPost("/agendamento", async(Agendamento agendamento, AppDbContext db) => {

    db.Agendamentos.Add(agendamento);
    await db.SaveChangesAsync();

    return Results.Created($"/agendamento/{agendamento.Id}", agendamento);
    
});


app.MapPut("/agendamento/{id}", async (int id, Agendamento inputAgendamento, AppDbContext db) =>
{
var agendamento = await db.Agendamentos.FindAsync(id);

if(agendamento is null) return Results.NotFound($"Agendamento com ID {id} não encontrado.");

else 
agendamento.Nome = inputAgendamento.Nome;
agendamento.TipoDeCorte = inputAgendamento.TipoDeCorte;
agendamento.Data = inputAgendamento.Data;

await db.SaveChangesAsync();
return Results.NoContent();
});


app.MapDelete("/agendamento/{id}" , async (int id, AppDbContext db) => {

    if(await db.Agendamentos.FindAsync(id) is Agendamento agendamento) {

        db.Agendamentos.Remove(agendamento);
        await db.SaveChangesAsync();
        return Results.Ok(agendamento);
    }
    else return Results.NotFound($"Agendamento com ID {id} não encontrado.");
    });


app.Run();