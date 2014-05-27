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

        public async Task<List<DailyCountSummary>> GetDailySummary(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return await apiAccess.GetAsync<List<DailyCountSummary>>(counterType, PeriodTypes.Daily, startDate, endDate, this.ApiCredential);
        }

        public async Task<List<WeeklyCountSummary>> GetWeeklySummary(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return await apiAccess.GetAsync<List<WeeklyCountSummary>>(counterType, PeriodTypes.Weekly, startDate, endDate, this.ApiCredential);
        }

        public async Task<List<MonthlyCountSummary>> GetMonthlySummary(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return await apiAccess.GetAsync<List<MonthlyCountSummary>>(counterType, PeriodTypes.Monthly, startDate, endDate, this.ApiCredential);
        }

        public async Task<List<YearlyCountSummary>> GetYearlySummary(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return await apiAccess.GetAsync<List<YearlyCountSummary>>(counterType, PeriodTypes.Yearly, startDate, endDate, this.ApiCredential);
        }
    }
}
