using bnahed.Api.Domain;
using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Infrastructure.Repository.Services;
using bnahed.Api.Infrastructure.Repository.Services.Interfaces;
using bnahed.Api.Infrastructure.Repository.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();

builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddSingleton<IMongoDbService, MongoDbService>();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/HC");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
//app.UseAuthentication();
app.UseEndpoints(e =>
{
    _ = e.MapControllers();
});

app.Run();
