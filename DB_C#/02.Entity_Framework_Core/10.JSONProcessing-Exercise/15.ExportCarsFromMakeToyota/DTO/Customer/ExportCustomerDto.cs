using Newtonsoft.Json;
using System;

namespace CarDealer.DTO.Customer
{
    [JsonObject]
    public class ExportCustomerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }

    }
}
