using Newtonsoft.Json;

namespace NuScrap
{
    public class PaymentMethod
    {
		public PaymentMethod()
		{
		}

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        
        [JsonProperty("kind")]
        public string Kind { get; set; }
    }
}
