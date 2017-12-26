using Newtonsoft.Json;

namespace NuScrap
{
    class AccountResponse
    {
        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}
