using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Exception;
using XOMNI.SDK.Model.Private.Metering;
using XOMNI.SDK.Model.Private.Metering.Log;

namespace XOMNI.SDK.Tests.Private.Metering.Log
{
    public abstract class BaseMeteringManagementFixture : SDKFixtureBase
    {
        protected abstract Type SampleMeteringLogType { get; }
        protected abstract CounterTypes CounterType { get; }

        public async Task InternalGetAllAsyncTest()
        {
            dynamic management = GetManagementClass(CounterType);
            int totalItemCount = 0;
            try
            {
                dynamic result = await management.GetAllAsync(DateTime.Now, null);
                totalItemCount = result.Logs.Count;
            }
            catch (NotFoundException)
            {

            }

            var sampleEntities = await InsertDummyLogsAsync();
            sampleEntities.ForEach(x => { dynamic d = x; d.CreatedDate = d.CreatedDate.ToUniversalTime(); });
            dynamic getResponse = await management.GetAllAsync(DateTime.Now);

            Assert.AreEqual(totalItemCount + sampleEntities.Count, getResponse.Logs.Count, String.Format("Total Counts did not match - Counter Type {0}", CounterType));

            foreach (dynamic log in getResponse.Logs)
            {
                dynamic found = sampleEntities.Where(x => (DateTime)x.GetType().GetProperty("CreatedDate").GetValue(x) == log.CreatedDate).SingleOrDefault();
                if (found != null)
                {
                    CompareFields(found, log);
                }
            }

            await DeleteSampleEntitiesAsync(sampleEntities);
            int logCount = 0;
            try
            {
                getResponse = await management.GetAllAsync(DateTime.Now);
                logCount = getResponse.Logs.Count;
            }
            catch (NotFoundException)
            {

            }
            Assert.AreEqual(totalItemCount, logCount, String.Format("Total counts did not match - Counter Type {0}", CounterType));
        }

        private async Task DeleteSampleEntitiesAsync(List<TableEntity> sampleEntities)
        {
            var tableClient = this.CloudStorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("Counter" + CounterType.ToString());
            TableBatchOperation batchOperation = new TableBatchOperation();

            for (int i = 0; i < 100; i++)
            {
                batchOperation.Delete(sampleEntities[i]);
            }

            await table.ExecuteBatchAsync(batchOperation);
        }

        private void CompareFields(object found, object log)
        {
            foreach (var prop in log.GetType().GetProperties())
            {
                dynamic controlValue = prop.GetValue(log);
                dynamic controlValue2 = found.GetType().GetProperty(prop.Name).GetValue(found);

                Assert.AreEqual(controlValue, controlValue2, String.Format
                ("Values did not match - Counter Type {0}, Property Name {1}", CounterType.ToString(), prop.Name));
            }
        }

        private async Task<List<TableEntity>> InsertDummyLogsAsync()
        {
            List<TableEntity> entities = new List<TableEntity>();
            var tableClient = this.CloudStorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("Counter" + CounterType.ToString());
            TableBatchOperation batchOperation = new TableBatchOperation();

            for (int i = 0; i < 100; i++)
            {
                var entity = CreateSampleObject(i);
                batchOperation.Insert(entity);
                entities.Add(entity);
            }

            await table.ExecuteBatchAsync(batchOperation);

            return entities;
        }

        private TableEntity CreateSampleObject(int index)
        {
            object instance = Activator.CreateInstance(SampleMeteringLogType, DateTime.Today.AddHours(3).AddMinutes(10 * index));
            List<string> tableEntityFields = new List<string>()
            {
                "PartitionKey","RowKey","ETag","Timestamp","CreatedDate","Year","Week","Day","Month"
            };
            foreach (var property in SampleMeteringLogType.GetProperties().Where(t => !tableEntityFields.Contains(t.Name)))
            {
                var propSetter = property.GetSetMethod();

                if (property.PropertyType.IsAssignableFrom(typeof(string)))
                {
                    object valueToSet = Guid.NewGuid().ToString();
                    propSetter.Invoke(instance, new[] { valueToSet });
                }
                else if (property.PropertyType.IsAssignableFrom(typeof(bool)))
                {
                    object valueToSetBool = true;
                    propSetter.Invoke(instance, new[] { valueToSetBool });
                }
                else if (property.PropertyType.IsAssignableFrom(typeof(DateTime)))
                {
                    object valueToSetDateTime = DateTime.Now.AddDays(new Random().Next(1500));
                    propSetter.Invoke(instance, new[] { valueToSetDateTime });
                }
                else if (property.PropertyType.IsAssignableFrom(typeof(int)))
                {
                    object valueToSetInt = new Random().Next(1, 100);
                    propSetter.Invoke(instance, new[] { valueToSetInt });
                }
                else if (property.PropertyType.IsAssignableFrom(typeof(Guid)))
                {
                    object valueToSetInt = Guid.NewGuid();
                    propSetter.Invoke(instance, new[] { valueToSetInt });
                }
            }

            return (TableEntity)instance;
        }

        private dynamic GetManagementClass(CounterTypes counterType)
        {
            return Activator.CreateInstance("XOMNI.SDK.Private", String.Format("XOMNI.SDK.Private.Metering.Log.{0}MeteringManagement", counterType.ToString())).Unwrap();
        }
    }
}
