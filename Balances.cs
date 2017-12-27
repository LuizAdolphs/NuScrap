using Newtonsoft.Json;

namespace NuScrap
{
    public class Balances
    {
        public Balances()
        {
        }

        [JsonProperty("future")]
        public long Future { get; set; }

        [JsonProperty("open")]
        public long Open { get; set; }

        [JsonProperty("due")]
        public long Due { get; set; }

        [JsonProperty("prepaid")]
        public long Prepaid { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }
    }
}
