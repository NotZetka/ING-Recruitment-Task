using ING_Recruitment_Task.Models;
using ING_Recruitment_Task.Services;
using ING_Recruitment_Task.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ING_Recruitment_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController(INbpSercive _nbpSercive) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ExchangeRateSummary>> GetExchangeRates()
        {
            var startDate = DateTime.Today.AddDays(-20);

            var response = await _nbpSercive.GetExchangeRatesAsync(Currency.EUR, startDate);



            var summary = response.Rates.Any() ? 
                new ExchangeRateSummary
                {
                    MinValue = response.Rates.Select(x => x.Mid).Min(),
                    MaxValue = response.Rates.Select(x => x.Mid).Max(),
                    Average = response.Rates.Select(x => x.Mid).Average()
                }:
                new ExchangeRateSummary();

            return Ok(summary);
        }
    }
}
