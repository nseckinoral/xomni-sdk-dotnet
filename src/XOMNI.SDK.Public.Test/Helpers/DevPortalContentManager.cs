using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using System.IO;
using XOMNI.SDK.Public.Infrastructure;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XOMNI.SDK.Public.Test.Helpers
{

    public class DevPortalContentManager : DevPortalContentProvider
    {
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

            var encodedUrl = System.Net.WebUtility.UrlEncode(devPortalLink);
            var folderDirectoryInfo = Directory.CreateDirectory(Path.Combine(dumpFilesPath, "DevPortalDumpFiles"));
            var filePath = Path.Combine(folderDirectoryInfo.FullName, encodedUrl);
            
            if (refreshDevPortalDumpFiles || (!File.Exists(filePath)))
            {
                var sample = string.Empty;
                try
                {
                    switch (contentType)
                    {
                        case ContentType.Request:
                            sample = await base.GetSampleRequestAsync(devPortalLinkAttribute);
                            break;
                        case ContentType.Response:
                            sample = await base.GetSampleResponseAsync(devPortalLinkAttribute);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured while fetching sample request/response from dev portal. (" + devPortalLink + ")", ex);
                }
                
                try
                {
                    dynamic deserializedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(sample);
                    retVal = deserializedJson.Content;
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid json on dev portal. (" + devPortalLink + ")", ex);
                }
                
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
