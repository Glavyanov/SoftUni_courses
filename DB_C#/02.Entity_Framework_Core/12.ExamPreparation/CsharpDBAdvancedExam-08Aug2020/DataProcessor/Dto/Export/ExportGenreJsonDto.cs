using Newtonsoft.Json;

namespace VaporStore.DataProcessor.Dto.Export
{
    [JsonObject]
    public class ExportGenreJsonDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Genre))]
        public string Genre { get; set; }

        [JsonProperty(nameof(Games))]
        public ExportGameJsonDto[] Games { get; set; }

        [JsonProperty(nameof(TotalPlayers))]
        public int TotalPlayers { get; set; }
    }
}
