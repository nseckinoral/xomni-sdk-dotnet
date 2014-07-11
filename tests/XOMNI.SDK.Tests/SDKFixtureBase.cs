using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace XOMNI.SDK.Tests
{
    [TestClass]
    public class SDKFixtureBase
    {
        public Lazy<XOMNI.Data.Model.Tenant.TenantDbContext> TestTenantDbContext = new Lazy<Data.Model.Tenant.TenantDbContext>
            (
                () => new XOMNI.Data.Model.Tenant.TenantDbContext(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["RunningPlatform"] + ".TestTenantDbConnectionString"])
            );

        public CloudStorageAccount CloudStorageAccount
        {
            get
            {
                return CloudStorageAccount.Parse(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["RunningPlatform"] + ".CloudStorageAccount"]);
            }
        }

        private string RunningPlatform
        {
            get
            {
                return ConfigurationManager.AppSettings["RunningPlatform"].ToString();
            }
        }

        public SDKFixtureBase()
        {
            Init();
        }

        public virtual void Init()
        {
            SDK.Core.Configuration.Configuration.SetConfigurationPublisher((configKey) =>
            {
                return ConfigurationManager.AppSettings[this.RunningPlatform + "." + configKey];
            });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
        }
    }
}
