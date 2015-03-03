using System;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Extensions;
using System.Collections.Generic;

namespace XOMNI.SDK.Public.Clients.Catalog
{
	public class TagMetadataClient : BaseClient
	{
		public TagMetadataClient(HttpClient httpClient)
			: base(httpClient)
		{

		}

		public async Task<ApiResponse<List<Metadata>>> GetAsync(int tagId)
		{
            Validator.For(tagId, "tagId").IsGreaterThanOrEqual(1);

			string path = string.Format("/catalog/tagmetadata?tagId={0}", tagId);

			using (var response = await Client.GetAsync(path).ConfigureAwait(false))
			{
				return await response.Content.ReadAsAsync<ApiResponse<List<Metadata>>>().ConfigureAwait(false);
			}
		}
	}
}