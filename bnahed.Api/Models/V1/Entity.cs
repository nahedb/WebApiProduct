using bnahed.Api.Models.V1.Interfaces;
using Newtonsoft.Json;

namespace bnahed.Api.Models.V1
{
    public abstract record Entity : IEntity
    {

        [JsonProperty("id")]
        public Guid? Id { get; set; } = Guid.NewGuid();
    }
}
