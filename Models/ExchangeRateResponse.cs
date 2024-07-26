using Newtonsoft.Json;

namespace ING_Recruitment_Task.Models
{
    public class ExchangeRateResponse
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("rates")]
        public List<Rate> Rates { get; set; }
    }
}
