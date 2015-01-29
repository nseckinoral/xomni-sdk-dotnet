using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Analytics;

namespace XOMNI.SDK.Private.Analytics
{
    public class ClientAnalyticsSummaryManagement : ManagementBase
    {
        private ApiAccess.Analytics.ClientAnalyticsSummary apiAccess = new ApiAccess.Analytics.ClientAnalyticsSummary();

        public Task<List<DailyCountSummary>> GetDailySummaryAsync(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<DailyCountSummary>>(counterName, PeriodTypes.Daily, startDate, endDate, this.ApiCredential);
        }

        public Task<List<WeeklyCountSummary>> GetWeeklySummaryAsync(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<WeeklyCountSummary>>(counterName, PeriodTypes.Weekly, startDate, endDate, this.ApiCredential);
        }

        public Task<List<MonthlyCountSummary>> GetMonthlySummaryAsync(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<MonthlyCountSummary>>(counterName, PeriodTypes.Monthly, startDate, endDate, this.ApiCredential);
        }

        public Task<List<YearlyCountSummary>> GetYearlySummaryAsync(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.GetAsync<List<YearlyCountSummary>>(counterName, PeriodTypes.Yearly, startDate, endDate, this.ApiCredential);
        }

        #region low level methods

        public XOMNIRequestMessage<List<DailyCountSummary>> CreateGetDailySummaryRequest(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<DailyCountSummary>>(counterName, PeriodTypes.Daily, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<WeeklyCountSummary>> CreateGetWeeklySummaryRequest(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<WeeklyCountSummary>>(counterName, PeriodTypes.Weekly, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<MonthlyCountSummary>> CreateGetMonthlySummaryRequest(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<MonthlyCountSummary>>(counterName, PeriodTypes.Monthly, startDate, endDate, this.ApiCredential);
        }

        public XOMNIRequestMessage<List<YearlyCountSummary>> CreateGetYearlySummaryRequest(string counterName, DateTime startDate, DateTime endDate)
        {
            return apiAccess.CreateGetRequest<List<YearlyCountSummary>>(counterName, PeriodTypes.Yearly, startDate, endDate, this.ApiCredential);
        }
        #endregion
    }
}
