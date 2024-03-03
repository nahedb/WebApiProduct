using bnahed.Api.Domain;
using bnahed.Api.Domain.Services.V1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole(options => options.IncludeScopes = true);

builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
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
