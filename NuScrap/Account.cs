using System;
using Newtonsoft.Json;

namespace NuScrap
{
    public class Account
    {
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("due_day")]
        public long DueDay { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("available_balance")]
        public long AvailableBalance { get; set; }

        [JsonProperty("temporary_limit_amount")]
        public long TemporaryLimitAmount { get; set; }

        [JsonProperty("limit_range_min")]
        public long LimitRangeMin { get; set; }

        [JsonProperty("future_balance")]
        public long FutureBalance { get; set; }

        [JsonProperty("current_interest_rate")]
        public string CurrentInterestRate { get; set; }

        [JsonProperty("precise_credit_limit")]
        public string PreciseCreditLimit { get; set; }

        [JsonProperty("next_due_date")]
        public DateTime NextDueDate { get; set; }

        [JsonProperty("interest_rate")]
        public double InterestRate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("balances")]
        public Balances Balances { get; set; }

        [JsonProperty("cards")]
        public Card[] Cards { get; set; }

        [JsonProperty("net_available")]
        public long NetAvailable { get; set; }

        [JsonProperty("barcode_id")]
        public string BarcodeId { get; set; }

        //[JsonProperty("_links")]
        //public Dictionary<string, Link> Links { get; set; }

        [JsonProperty("limit_range_max")]
        public long LimitRangeMax { get; set; }

        [JsonProperty("next_close_date")]
        public DateTime NextCloseDate { get; set; }

        [JsonProperty("current_balance")]
        public long CurrentBalance { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("credit_limit")]
        public long CreditLimit { get; set; }
    }
}
