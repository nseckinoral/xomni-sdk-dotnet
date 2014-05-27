using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Management.Configuration;

namespace XOMNI.SDK.Management.Configuration
{
    /// <summary>
    /// Manages stores
    /// </summary>
    public class StoreManagement : BaseCRUDSkipTakeManagement<Store>
    {
        protected override CRUDApiAccessBase<Store> ApiAccess
        {
            get { return new ApiAccess.Configuration.Store(); }
        }

        /// <summary>
        /// Adds a new store
        /// </summary>
        /// <param name="entity">Store to be added</param>
        /// <returns>Added store</returns>
        public override async Task<Store> AddAsync(Store entity)
        {
            return await base.AddAsync(entity);
        }

        /// <summary>
        /// Delete a licence by its id
        /// </summary>
        /// <param name="id">Licence id</param>
        /// <returns></returns>
        public override async Task DeleteAsync(int id)
        {
            await base.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a paged list of licenses
        /// </summary>
        /// <param name="skip">The number of licences in the collection to skip before executing a select.</param>
        /// <param name="take">The number of licences that should be fetched from the collection.</param>
        /// <returns>CountedCollectionContainer of entity</returns>
        public override async Task<Model.CountedCollectionContainer<Store>> GetAllAsync(int skip, int take)
        {
            return await base.GetAllAsync(skip, take);
        }

        /// <summary>
        /// Fetchs a store by its id
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Fetched store</returns>
        public override async Task<Store> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="entity">Store to be updated</param>
        /// <returns>Updated store</returns>
        public override async Task<Store> UpdateAsync(Store entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}
