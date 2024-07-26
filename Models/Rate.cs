using Newtonsoft.Json;

namespace ING_Recruitment_Task.Models
{
    public class Rate
    {
        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonProperty("mid")]
        public decimal Mid { get; set; }
    }
}
