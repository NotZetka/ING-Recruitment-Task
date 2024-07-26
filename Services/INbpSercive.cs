using ING_Recruitment_Task.Models;
using ING_Recruitment_Task.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ING_Recruitment_Task.Services
{
    public interface INbpSercive
    {
        Task<ExchangeRateResponse> GetExchangeRatesAsync(Currency currency, DateTime? startDate = null, DateTime? endDate = null);
    }
}