using Newtonsoft.Json;

namespace bnahed.Api.Models.V1.Interfaces
{
    public interface IEntity
    {

        [JsonProperty("id")]
        public Guid? Id { get; }
    }
}
