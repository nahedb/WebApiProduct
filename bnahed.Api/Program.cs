using bnahed.Api.Domain.Services.V1.Interfaces;
using bnahed.Api.Domain;
using bnahed.Api.Infrastructure.Repository.Settings;
using bnahed.Api.Infrastructure.Repository.Context.Interface;
using bnahed.Api.Infrastructure.Repository.Context;
using bnahed.Api.Models.V1;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.Configure<MongoDbConfigurations>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<CosmoDbConfigurations>(builder.Configuration.GetSection("CosmoDB"));

var options = builder.Configuration.GetSection("CosmoDB").Get<CosmoDbConfigurations>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
builder.Services.AddControllers();
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Logging.ClearProviders();

/*builder.Services.AddDbContext<WeatherDbContext>(b =>
    b.UseCosmos(options!.ConnectionUri!, options.AccountKey!, options.DatabaseName!),
    ServiceLifetime.Transient,
    ServiceLifetime.Transient);*/

builder.Services.AddDbContext<ICosmoDbContext<Entity>, CosmoDbContext>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

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
