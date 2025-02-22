using Microsoft.EntityFrameworkCore;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;
using TeslaACDC.Data;
using TeslaACDC.Data.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Database Connection
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseSession"))
);


// Inyeccion de dependencias
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IMatematikaService, MatematikaService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAlbumRepository<int, Album>, AlbumRepository<int, Album>>();
builder.Services.AddScoped<IArtistRepository<int, Artist>, ArtistRepository<int, Artist>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();
