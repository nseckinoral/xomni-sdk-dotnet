﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Catalog;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Catalog
{
    internal class TagMetadata : ApiAccessBase
    {
        public async Task<TagMetaData> AddMetadataAsync(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            TagMetaData createdMetadata = await HttpProvider.PostAsync<TagMetaData>(GenerateUrl(SingleOperationBaseUrl), tagMetadata, credential);
            return createdMetadata;
        }

        public Task<List<Metadata>> GetAllMetadataAsync(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            return HttpProvider.GetAsync<List<Metadata>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        public Task DeleteMetadataAsync(int tagId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return HttpProvider.DeleteAsync(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential);
        }

        public Task<TagMetaData> UpdateMetadataAsync(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            return HttpProvider.PutAsync<TagMetaData>(GenerateUrl(SingleOperationBaseUrl), tagMetadata, credential);
        }

        public Task ClearMetadataAsync(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());

            return HttpProvider.DeleteAsync(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/tagmetadata"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/tagmetadata"; }
        }

        #region low level methods
        public XOMNIRequestMessage<TagMetaData> CreateAddMetadataRequest(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<TagMetaData>(HttpProvider.CreatePostRequest(GenerateUrl(SingleOperationBaseUrl), credential, tagMetadata));
        }

        public XOMNIRequestMessage<List<Metadata>> CreateGetAllMetadataRequest(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            return new XOMNIRequestMessage<List<Metadata>>(HttpProvider.CreateGetRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage CreateDeleteMetadataRequest(int tagId, string metadataKey, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());
            additionalParameters.Add("metadataKey", metadataKey);

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(SingleOperationBaseUrl, additionalParameters), credential));
        }

        public XOMNIRequestMessage<TagMetaData> CreateUpdateMetadataRequest(TagMetaData tagMetadata, ApiBasicCredential credential)
        {
            return new XOMNIRequestMessage<TagMetaData>(HttpProvider.CreatePutRequest(GenerateUrl(SingleOperationBaseUrl), credential, tagMetadata));
        }

        public XOMNIRequestMessage CreateClearMetadataRequest(int tagId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("tagId", tagId.ToString());

            return new XOMNIRequestMessage(HttpProvider.CreateDeleteRequest(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential));
        }
        #endregion
    }
}
