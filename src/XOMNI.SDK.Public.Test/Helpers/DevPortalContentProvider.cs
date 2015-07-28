using System;
using System.Linq;
using XOMNI.SDK.Public.Clients;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Test.Helpers
{
    public class DevPortalContentProvider
    {
        const string developerPortalSampleRequestUrlFormat = "{0}/requestsample?mimeType=application/json";
        const string developerPortalSampleResponseUrlFormat = "{0}/responsesample?mimeType=application/json";
        readonly static HttpClient httpClientForDevPortal = new HttpClient();

        public DevPortalLinkAttribute GetDeveloperPortalLink<TClient>(Expression<Func<TClient, Task>> actExpressionAsync) where TClient : BaseClient
        {
            return GetDeveloperPortalLink(actExpressionAsync.Body);
        }

        public DevPortalLinkAttribute GetDeveloperPortalLink<TClient, TResponse>(Expression<Func<TClient, Task<TResponse>>> actExpressionAsync) where TClient : BaseClient
        {
            return GetDeveloperPortalLink(actExpressionAsync.Body);
        }

        protected DevPortalLinkAttribute GetDeveloperPortalLink(Expression body) 
        {
            var developerPortalLinkAttribute = ((MethodCallExpression)body).Method.GetCustomAttributes(true).OfType<DevPortalLinkAttribute>().SingleOrDefault();

            Assert.IsNotNull(developerPortalLinkAttribute);
            Assert.IsNotNull(developerPortalLinkAttribute.Link);

            return developerPortalLinkAttribute;
        }

        protected async Task<string> GetSampleRequestAsync(DevPortalLinkAttribute devPortalLinkAttribute)
        {
            return await httpClientForDevPortal.GetStringAsync(string.Format(developerPortalSampleRequestUrlFormat, devPortalLinkAttribute.Link));
        }

        protected async Task<string> GetSampleResponseAsync(DevPortalLinkAttribute devPortalLinkAttribute)
        {
            return await httpClientForDevPortal.GetStringAsync(string.Format(developerPortalSampleResponseUrlFormat, devPortalLinkAttribute.Link));
        }
    }
}