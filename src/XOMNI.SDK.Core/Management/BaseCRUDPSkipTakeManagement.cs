using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;

namespace XOMNI.SDK.Core.Management
{
    public abstract class BaseCRUDPSkipTakeManagement<T> : BaseCRUDSkipTakeManagement<T>
    {
        protected override CRUDApiAccessBase<T> ApiAccess
        {
            get { return CRUDPApiAccess; }
        }

        protected abstract CRUDPApiAccessBase<T> CRUDPApiAccess { get; }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Dynamic entity to be updated</param>
        /// <returns>Updated entity</returns>
        public virtual Task<T> UpdateAsync(dynamic entity)
        {
            return CRUDPApiAccess.PatchAsync(entity, base.ApiCredential);
        }

        #region Low level methods

        public virtual XOMNIRequestMessage<T> CreatePatchRequest(dynamic entity)
        {
            return CRUDPApiAccess.CreatePatchRequest(entity, base.ApiCredential);
        }

        #endregion
    }
}
