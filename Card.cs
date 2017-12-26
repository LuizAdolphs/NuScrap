using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuScrap
{
    public class Card
    {
        public Card()
        {
        }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("member_since")]
        public string MemberSince { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("good_through")]
        public string GoodThrough { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status_detail")]
        public string StatusDetail { get; set; }

        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, Link> Links { get; set; }
    }
}
