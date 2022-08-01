using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCountryJsonDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }
    }
}
