using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Metering;

namespace XOMNI.SDK.Private.Metering
{
    public class SummaryMeteringManagement : ManagementBase
    {
        public CounterTypes CounterType { get; private set; }
        private ApiAccess.Metering.SummaryMeterings apiAccess = new ApiAccess.Metering.SummaryMeterings();

        public Task<List<DailyCountSummary>> GetDailySummaryAsync(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<DailyCountSummary>>(counterType, PeriodTypes.Daily, startDate, endDate, this.ApiCredential);
        }

        public Task<List<WeeklyCountSummary>> GetWeeklySummaryAsync(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<WeeklyCountSummary>>(counterType, PeriodTypes.Weekly, startDate, endDate, this.ApiCredential);
        }

        public Task<List<MonthlyCountSummary>> GetMonthlySummaryAsync(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<MonthlyCountSummary>>(counterType, PeriodTypes.Monthly, startDate, endDate, this.ApiCredential);
        }

        public Task<List<YearlyCountSummary>> GetYearlySummaryAsync(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<YearlyCountSummary>>(counterType, PeriodTypes.Yearly, startDate, endDate, this.ApiCredential);
        }
    }
}
