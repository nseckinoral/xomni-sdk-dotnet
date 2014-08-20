﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Private.Catalog;

namespace XOMNI.SDK.Private.ApiAccess.Catalog.ItemStoreMetadata
{
    internal class ItemStoreMetadata : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/storemetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/items/{0}/storemetadata"; }
        }

        public Task<InStoreMetadata> AddInStoreMetadataAsync(int itemId, InStoreMetadata inStoreMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PostAsync<InStoreMetadata>(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), inStoreMetadata, credential);
        }

        public Task<InStoreMetadata> UpdateInStoreMetadataAsync(int itemId, InStoreMetadata InStoreMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<InStoreMetadata>(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId)), InStoreMetadata, credential);
        }

        public Task DeleteInStoreMetadataAsync(int itemId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(SingleOperationBaseUrl, itemId), additionalParameters), credential);
        }

        public Task ClearInStoreMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            return HttpProvider.DeleteAsync(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), credential);
        }

        public Task<List<InStoreMetadata>> GetAllInStoreMetadataAsync(int itemId, ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<List<InStoreMetadata>>(GenerateUrl(string.Format(ListOperationBaseUrl, itemId)), credential);
        }
    }
}