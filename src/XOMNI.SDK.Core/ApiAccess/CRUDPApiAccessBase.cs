using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Core.ApiAccess
{
    public class CRUDPApiAccessBase<T> : CRUDApiAccessBase<T>
    {
        internal Task<T> PatchAsync(dynamic content, ApiBasicCredential credential)
        {
            return HttpProvider.PatchAsync<T>(GenerateUrl(SingleOperationBaseUrl), content, credential);
        }
    }
}
