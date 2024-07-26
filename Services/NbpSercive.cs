using ING_Recruitment_Task.Models;
using ING_Recruitment_Task.Utilities.Enums;
using ING_Recruitment_Task.Utilities.Exceptions;
using Newtonsoft.Json;
using System.Text;

namespace ING_Recruitment_Task.Services
{
    public class NbpSercive(IHttpClientFactory _httpClientFactory) : INbpSercive
    {
        private readonly string _baseUrl = "http://api.nbp.pl/api/exchangerates/rates/A/";

        public async Task<ExchangeRateResponse> GetExchangeRatesAsync(Currency currency, DateTime? startDate = null, DateTime? endDate = null)
        {
            if(startDate == null) startDate = DateTime.Today;
            if(endDate == null || endDate<startDate) endDate = DateTime.Today;
            var sb = new StringBuilder(_baseUrl);
            sb.Append(currency.ToString()).Append("/");
            sb.Append(startDate.Value.ToString("yyyy-MM-dd")).Append("/");
            sb.Append(endDate.Value.ToString("yyyy-MM-dd")).Append("/");
            sb.Append("?format=json");
            var url = sb.ToString();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new NbpServiceException(response.StatusCode, response.ReasonPhrase);
            }

            var content = await response.Content.ReadAsStringAsync();
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateResponse>(content);

            return exchangeRate;
        }
    }
}
