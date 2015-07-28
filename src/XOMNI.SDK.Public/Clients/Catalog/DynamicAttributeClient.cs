using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Infrastructure;

namespace XOMNI.SDK.Public.Clients.Catalog
{
    public class DynamicAttributeClient : BaseClient
    {
        public DynamicAttributeClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/dynamic-attribute/fetching-a-list-of-dynamic-attribute-types")]
        public async Task<ApiResponse<PaginatedContainer<DynamicAttributeType>>> GetDynamicAttributeTypesAsync(int skip, int take)
        {
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

            string path = string.Format("/catalog/dynamicattributetypes?skip={0}&take={1}", skip, take);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<DynamicAttributeType>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/dynamic-attribute/fetching-a-list-of-dynamic-attributes")]
        public async Task<ApiResponse<PaginatedContainer<DynamicAttribute>>> GetDynamicAttributesAsync(int skip, int take)
        {
            Validator.For(skip, "skip").IsGreaterThanOrEqual(0);
            Validator.For(take, "take").InRange(1, 1000);

            string path = string.Format("/catalog/dynamicattributes?skip={0}&take={1}", skip, take);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<PaginatedContainer<DynamicAttribute>>>().ConfigureAwait(false);
            }
        }

        [DevPortalLink("http://dev.xomni.com/v3-1/http-api/public-apis/catalog/dynamic-attribute/fetching-a-list-of-dynamic-attributes-related-with-a-spesific-dynamic-attribute-type")]
        public async Task<ApiResponse<List<DynamicAttribute>>> GetAsync(int dynamicAttributeTypeId)
        {
            Validator.For(dynamicAttributeTypeId, "dynamicAttributeTypeId").IsGreaterThanOrEqual(1);
            string path = string.Format("/catalog/dynamicattributes/{0}", dynamicAttributeTypeId);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<DynamicAttribute>>>().ConfigureAwait(false);
            }
        }
    }
}