namespace bnahed.Api.Infrastructure.Repository.Settings;

public class MongoDbConfigurations : DbConfigurations
{
    public string? CollectionName { get; set; } = null!;
}