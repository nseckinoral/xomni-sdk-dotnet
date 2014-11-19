using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;

namespace XOMNI.SDK.Core.Management
{
    public abstract class BaseCRUDSkipTakeManagement<T> : BaseCRUDManagement<T>
    {
        /// <summary>
        /// Returns a paged list of entity
        /// </summary>
        /// <param name="skip">The number of items in the collection to skip before executing a select.</param>
        /// <param name="take">The number of items that should be fetched from the collection.</param>
        /// <returns>CountedCollectionContainer of entity</returns>
        public virtual Task<Model.CountedCollectionContainer<T>> GetAllAsync(int skip, int take)
        {
            return ApiAccess.GetAllAsync(skip, take, base.ApiCredential);
        }

        #region Low level methods

        public virtual XOMNIRequestMessage<CountedCollectionContainer<T>> CreateGetAllRequest(int skip, int take)
        {
            return ApiAccess.CreateGetAllRequest(skip, take, base.ApiCredential);
        }

        #endregion
    }
}
