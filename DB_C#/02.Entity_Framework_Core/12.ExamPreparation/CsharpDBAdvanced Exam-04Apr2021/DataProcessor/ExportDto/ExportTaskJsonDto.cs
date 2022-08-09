using Newtonsoft.Json;

namespace TeisterMask.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTaskJsonDto
    {
        [JsonProperty(nameof(TaskName))]
        public string TaskName { get; set; }

        [JsonProperty(nameof(OpenDate))]
        public string OpenDate { get; set; }

        [JsonProperty(nameof(DueDate))]
        public string DueDate { get; set; }

        [JsonProperty(nameof(LabelType))]
        public string LabelType { get; set; }

        [JsonProperty(nameof(ExecutionType))]
        public string ExecutionType { get; set; }
    }
}
