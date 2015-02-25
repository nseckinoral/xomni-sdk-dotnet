using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics;

namespace XOMNI.SDK.Private.Analytics
{
    public class ServerAnalyticsSummaryManagement : ManagementBase
    {
        public CounterTypes CounterType { get; private set; }
        private ApiAccess.Analytics.ServerAnalyticsSummary apiAccess = new ApiAccess.Analytics.ServerAnalyticsSummary();

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

        #region low level methods

        public XOMNIRequestMessage<List<DailyCountSummary>> CreateGetDailySummaryRequest(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<DailyCountSummary>>(counterType, PeriodTypes.Daily, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<WeeklyCountSummary>> CreateGetWeeklySummaryRequest(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<WeeklyCountSummary>>(counterType, PeriodTypes.Weekly, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<MonthlyCountSummary>> CreateGetMonthlySummaryRequest(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<MonthlyCountSummary>>(counterType, PeriodTypes.Monthly, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<YearlyCountSummary>> CreateGetYearlySummaryRequest(CounterTypes counterType, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<YearlyCountSummary>>(counterType, PeriodTypes.Yearly, startDate, endDate, this.ApiCredential);
        }
        #endregion
    }
}
