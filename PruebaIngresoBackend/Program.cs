using Microsoft.EntityFrameworkCore;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository.Models;
using DataAccess.Repository.ModelRepositories;
using Business.Services.Interfaces;
using Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<NewshoreAirDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IGenericRepository<Fligth>, FlightRepository>();
builder.Services.AddScoped<IGenericRepository<Journey>, JourneyRepository>();
builder.Services.AddScoped<IGenericRepository<JourneyFlight>, JourneyFlightRepository>();
builder.Services.AddScoped<IGenericRepository<Transport>, TransportRepository>();
builder.Services.AddScoped<IJourneyService, JourneyService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
