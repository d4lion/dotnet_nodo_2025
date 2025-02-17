using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Inyeccion de dependencias
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IMatematikaService, MatematikaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();
