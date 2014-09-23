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
    public class DynamicAttribute : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattribute"; }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/catalog/dynamicattributes"; }
        }

        internal Task<List<SDK.Model.Catalog.DynamicAttribute>> GetByAttributeIdAsync(int attributeId, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("id", attributeId.ToString());

            return HttpProvider.GetAsync<List<SDK.Model.Catalog.DynamicAttribute>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }
    }
}