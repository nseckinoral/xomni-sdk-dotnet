using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using System.IO;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Test.Helpers
{
    public class DevPortalContentManager : DevPortalContentProvider
    {
        static readonly HashAlgorithm algorithm = MD5.Create();
        static readonly bool refreshDevPortalDumpFiles = bool.Parse(ConfigurationManager.AppSettings["RefreshDevPortalDumpFiles"]);
        static readonly string dumpFilesPath = Path.GetTempPath();
        public Task<string> GetSampleRequestAsync<TClient>(Expression<Func<TClient, Task>> actExpressionAsync) where TClient : BaseClient
        {
            var devPortalLinkAttribute = GetDeveloperPortalLink(actExpressionAsync);
            return GetSampleAsync(devPortalLinkAttribute, ContentType.Request);
        }

        public Task<string> GetSampleResponseAsync<TClient, TResponse>(Expression<Func<TClient, Task<TResponse>>> actExpressionAsync) where TClient : BaseClient
        {
            var devPortalLinkAttribute = GetDeveloperPortalLink(actExpressionAsync);
            return GetSampleAsync(devPortalLinkAttribute, ContentType.Response);
        }

        private async Task<string> GetSampleAsync(DevPortalLinkAttribute devPortalLinkAttribute, ContentType contentType)
        {
            var retVal = string.Empty;
            var devPortalLink = devPortalLinkAttribute.Link;

            var hashedUrl = Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(devPortalLink)));
            var folderDirectoryInfo = Directory.CreateDirectory(Path.Combine(dumpFilesPath, "DevPortalDumpFiles"));
            var filePath = Path.Combine(folderDirectoryInfo.FullName, hashedUrl);
            
            if (refreshDevPortalDumpFiles || (!File.Exists(filePath)))
            {
                retVal = await base.GetSampleRequestAsync(devPortalLinkAttribute);
                File.WriteAllText(filePath, retVal);
            }
            else
            {
                retVal = File.ReadAllText(filePath);
            }

            return retVal;
        }

        enum ContentType
        {
            Request,
            Response
        }
    }
}
