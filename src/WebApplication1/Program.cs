using DataAccess.Data;
using DataAccess.DbAccess;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MySqlConnector;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IsqlDataAccess, sqlDataAccess>();
builder.Services.AddSingleton<IUnidadeData,UnidadeData>();

builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("con01")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureApi();



app.Run();

