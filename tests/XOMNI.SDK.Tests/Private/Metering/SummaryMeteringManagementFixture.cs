using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.Private.Metering;
using XOMNI.SDK.Private.Metering;
using XOMNI.SDK.Core.Extensions;
using XOMNI.SDK.Core.Exception;

namespace XOMNI.SDK.Tests.Private.Metering
{
    [TestClass]
    public class SummaryMeteringManagementFixture : SDKFixtureBase
    {
        DateTime summaryStartDate = DateTime.Now.AddMonths(-2);
        DateTime summaryEndDate = DateTime.Now.AddMonths(13);
        
        [TestInitialize]
        public void Initialize()
        {
            // populate DB

            //Random rnd = new Random();
            //using (var tenantDbContext = TestTenantDbContext.Value)
            //{
            //    tenantDbContext.Configuration.AutoDetectChangesEnabled = false;
            //    tenantDbContext.Configuration.ValidateOnSaveEnabled = false;
            //    var summaryDate = summaryStartDate;
            //    for (int i = 0; i < (summaryEndDate - summaryStartDate).TotalDays; i++)
            //    {
            //        summaryDate = summaryDate.AddDays(1);
            //        foreach (var counterType in Enum.GetValues(typeof(CounterTypes)).Cast<CounterTypes>().ToList())
            //        {
            //            tenantDbContext.DailyCountSummaries.Add(new Data.Model.Tenant.MeteringSummary.DailyCountSummary()
            //            {
            //                CounterTypeId = (int)counterType,
            //                Day = summaryDate.Day,
            //                Week = summaryDate.GetWeekOfYear(),
            //                Month = summaryDate.Month,
            //                SummaryDate = summaryDate,
            //                SummaryStatusId = 2,
            //                TotalCount = rnd.Next(10, 150),
            //                Year = summaryDate.Year
            //            });
            //        }
            //    }

            //    tenantDbContext.SaveChanges();

            //    var weeklySummaries = tenantDbContext.DailyCountSummaries
            //        .Where(t => t.SummaryDate > summaryStartDate)
            //        .GroupBy(t => new { t.CounterTypeId, t.SummaryStatusId, t.Year, t.Month, t.Week })
            //        .Select(p => new
            //        {
            //            Month = p.Key.Month,
            //            TotalCount = p.Sum(z => z.TotalCount),
            //            SummaryStatusId = p.Key.SummaryStatusId,
            //            CounterTypeId = p.Key.CounterTypeId,
            //            Week = p.Key.Week,
            //            SummaryDate = p.Max(z => z.SummaryDate),
            //            Year = p.Key.Year
            //        }
            //        )
            //        .Distinct()
            //        .ToList();

            //    foreach (var item in weeklySummaries)
            //    {
            //        tenantDbContext.WeeklyCountSummaries.Add(new Data.Model.Tenant.MeteringSummary.WeeklyCountSummary()
            //        {
            //            Month = item.Month,
            //            TotalCount = item.TotalCount,
            //            SummaryStatusId = item.SummaryStatusId,
            //            CounterTypeId = item.CounterTypeId,
            //            Week = item.Week,
            //            SummaryDate = item.SummaryDate,
            //            Year = item.Year
            //        });
            //    }
            //    tenantDbContext.SaveChanges();

            //    var monthlySummaries = tenantDbContext.WeeklyCountSummaries
            //        .Where(t => t.SummaryDate > summaryStartDate)
            //        .GroupBy(t => new { t.CounterTypeId, t.SummaryStatusId, t.Year, t.Month })
            //        .Select(p => new
            //        {
            //            Month = p.Key.Month,
            //            TotalCount = p.Sum(z => z.TotalCount),
            //            SummaryStatusId = p.Key.SummaryStatusId,
            //            CounterTypeId = p.Key.CounterTypeId,
            //            SummaryDate = p.Max(z => z.SummaryDate),
            //            Year = p.Key.Year
            //        }
            //        )
            //        .Distinct()
            //        .ToList();

            //    foreach (var item in monthlySummaries)
            //    {
            //        tenantDbContext.MonthlyCountSummaries.Add(new Data.Model.Tenant.MeteringSummary.MonthlyCountSummary()
            //        {
            //            Month = item.Month,
            //            TotalCount = item.TotalCount,
            //            SummaryStatusId = item.SummaryStatusId,
            //            CounterTypeId = item.CounterTypeId,
            //            SummaryDate = item.SummaryDate,
            //            Year = item.Year
            //        });
            //    }
            //    tenantDbContext.SaveChanges();

            //    var yearlySummaries = tenantDbContext.MonthlyCountSummaries
            //        .Where(t => t.SummaryDate > summaryStartDate)
            //        .GroupBy(t => new { t.CounterTypeId, t.SummaryStatusId, t.Year })
            //        .Select(p => new
            //        {
            //            TotalCount = p.Sum(z => z.TotalCount),
            //            SummaryStatusId = p.Key.SummaryStatusId,
            //            CounterTypeId = p.Key.CounterTypeId,
            //            SummaryDate = p.Max(z => z.SummaryDate),
            //            Year = p.Key.Year
            //        }
            //        )
            //        .Distinct()
            //        .ToList();

            //    foreach (var item in yearlySummaries)
            //    {
            //        tenantDbContext.YearlyCountSummaries.Add(new Data.Model.Tenant.MeteringSummary.YearlyCountSummary()
            //        {
            //            TotalCount = item.TotalCount,
            //            SummaryStatusId = item.SummaryStatusId,
            //            CounterTypeId = item.CounterTypeId,
            //            SummaryDate = item.SummaryDate,
            //            Year = item.Year
            //        });
            //    }
            //    tenantDbContext.SaveChanges();
            //}
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Random rnd = new Random();
            //using (var tenantDbContext = TestTenantDbContext.Value)
            //{
            //    tenantDbContext.DailyCountSummaries.Where(t => t.SummaryDate > summaryStartDate)
            //        .ToList()
            //        .ForEach
            //        (
            //            z => tenantDbContext.DailyCountSummaries.Remove(z)
            //        );

            //    tenantDbContext.SaveChanges();

            //    tenantDbContext.WeeklyCountSummaries.Where(t => t.SummaryDate > summaryStartDate)
            //        .ToList()
            //        .ForEach
            //        (
            //            z => tenantDbContext.WeeklyCountSummaries.Remove(z)
            //        );
            //    tenantDbContext.SaveChanges();

            //    tenantDbContext.MonthlyCountSummaries.Where(t => t.SummaryDate > summaryStartDate)
            //        .ToList()
            //        .ForEach
            //        (
            //            z => tenantDbContext.MonthlyCountSummaries.Remove(z)
            //        );
            //    tenantDbContext.SaveChanges();

            //    tenantDbContext.YearlyCountSummaries.Where(t => t.SummaryDate > summaryStartDate)
            //        .ToList()
            //        .ForEach
            //        (
            //            z => tenantDbContext.YearlyCountSummaries.Remove(z)
            //        );
            //    tenantDbContext.SaveChanges();
            //}
        }

        [TestMethod]
        [TestCategory("SDK.Private.Metering"), TestCategory("Integration"), TestCategory("SDK.Private.Metering.SummaryMeteringManagement")]
        public async Task GetSummaryAsyncTest()
        {
            SummaryMeteringManagement summaryMeterings = new SummaryMeteringManagement();
            List<CounterTypes> counterTypes = new List<CounterTypes>() { CounterTypes.ItemLike, CounterTypes.ItemView };

            //For counter table's
            //foreach (var counterType in Enum.GetValues(typeof(CounterTypes)).Cast<CounterTypes>().ToList())
            foreach (var counterType in counterTypes)
            {
                try
                {
                    await summaryMeterings.GetDailySummary(counterType, DateTime.Now.AddDays(-365), DateTime.Now.AddDays(-1));
                    Assert.Fail("Daily time range did not work.");
                }
                catch (BadRequestException ex)
                {
                    //OK expected.
                }

                var retValDaily = await summaryMeterings.GetDailySummary(counterType, summaryEndDate.AddDays(-5), summaryEndDate);

                try
                {
                    await summaryMeterings.GetWeeklySummary(counterType, DateTime.Now.AddDays(-368), DateTime.Now.AddDays(-1));
                    Assert.Fail("Daily time range did not work.");
                }
                catch (BadRequestException ex)
                {
                    //OK expected.
                }

                var retValWeekly = await summaryMeterings.GetWeeklySummary(counterType, summaryEndDate.AddDays(-30), summaryEndDate);

                try
                {
                    await summaryMeterings.GetMonthlySummary(counterType, DateTime.Now.AddDays(-368), DateTime.Now.AddDays(-1));
                    Assert.Fail("Daily time range did not work.");
                }
                catch (BadRequestException ex)
                {
                    //OK expected.
                }

                var retValMonthly = await summaryMeterings.GetMonthlySummary(counterType, summaryEndDate.AddDays(-365), summaryEndDate);

                var retValYearly = await summaryMeterings.GetYearlySummary(counterType, summaryEndDate.AddDays(-366), summaryEndDate.AddDays(1));

            }
        }
    }
}
