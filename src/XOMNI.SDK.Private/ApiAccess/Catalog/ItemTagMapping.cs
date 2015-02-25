using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    public class ItemTagMapping : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/itemtagmapping/{0}"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/itemtagmappings"; }
        }

        public Task<XOMNI.SDK.Model.Catalog.ItemTagMapping> AddAsync(XOMNI.SDK.Model.Catalog.ItemTagMapping itemTagMapping, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<XOMNI.SDK.Model.Catalog.ItemTagMapping>(GenerateUrl(SingleOperationBaseUrl), itemTagMapping, credential);
        }

        public Task DeleteAsync(int itemId, int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("tagId", tagId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetByItemIdAsync(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            return HttpProvider.GetAsync<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>>(GenerateUrl(ListOperationBaseUrl), credential);
        }

        public Task<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetByTagIdAsync(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            return HttpProvider.GetAsync<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>>(GenerateUrl(ListOperationBaseUrl), credential);
        }

        public Task<CountedCollectionContainer<XOMNI.SDK.Model.Catalog.ItemTagMapping>> GetAllAsync(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return HttpProvider.GetAsync<CountedCollectionContainer<XOMNI.SDK.Model.Catalog.ItemTagMapping>>(GenerateUrl(ListOperationBaseUrl), credential);
        }

        #region low level methods
        public XOMNIRequestMessage<XOMNI.SDK.Model.Catalog.ItemTagMapping> CreateAddRequest(XOMNI.SDK.Model.Catalog.ItemTagMapping itemTagMapping, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<Model.Catalog.ItemTagMapping>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, itemTagMapping));
        }

        public XOMNIRequestMessage CreateDeleteRequest(int itemId, int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            additionalParameters.Add("tagId", tagId.ToString());

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> CreateGetByItemIdRequest(int itemId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());
            return new XOMNIRequestMessage<List<Model.Catalog.ItemTagMapping>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl), credential));
        }

        public XOMNIRequestMessage<List<XOMNI.SDK.Model.Catalog.ItemTagMapping>> CreateGetByTagIdRequest(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            return new XOMNIRequestMessage<List<Model.Catalog.ItemTagMapping>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl), credential));
        }

        public XOMNIRequestMessage<CountedCollectionContainer<XOMNI.SDK.Model.Catalog.ItemTagMapping>> CreateGetAllRequest(int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());
            return new XOMNIRequestMessage<CountedCollectionContainer<Model.Catalog.ItemTagMapping>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl), credential));
        }

        #endregion
    }
}
