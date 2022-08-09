using Newtonsoft.Json;

namespace TeisterMask.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportEmployeeJsonDto
    {
        [JsonProperty(nameof(Username))]
        public string Username { get; set; }

        [JsonProperty(nameof(Tasks))]
        public ExportTaskJsonDto[] Tasks { get; set; }

    }
}
