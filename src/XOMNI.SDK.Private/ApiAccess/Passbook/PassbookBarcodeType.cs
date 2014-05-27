using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Private.ApiAccess.Passbook
{
    public class PassbookBarcodeType : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { return "/private/passbook/barcodetypes"; }
        }

        public Task<IDictionary<int, string>> GetAllAsync(ApiBasicCredential credential)
        {
            return HttpProvider.GetAsync<IDictionary<int, string>>(GenerateUrl(ListOperationBaseUrl), credential);
        }
    }
}
