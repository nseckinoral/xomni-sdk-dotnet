using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess
{
    internal abstract class AssetBase : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl { get { return string.Empty; } }

        protected override string ListOperationBaseUrl { get { return string.Empty; } }

        public virtual Task<CountedCollectionContainer<T>> GetAsync<T>(int skip, int take, ApiBasicCredential credential, string fileName = null)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            if (!string.IsNullOrEmpty(fileName))
            {
                additionalParameters.Add("fileName", fileName);
            }

            return HttpProvider.GetAsync<CountedCollectionContainer<T>>(GenerateUrl(ListOperationBaseUrl, additionalParameters), credential);
        }

    }
}
