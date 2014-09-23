using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Management.ApiAccess.Storage;
using XOMNI.SDK.Model.Management.Storage;

namespace XOMNI.SDK.Management.Storage
{
    public class AssetManagement : BaseCRUDSkipTakeManagement<Asset>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<Asset> ApiAccess
        {
            get { return new Assets(); }
        }

        /// <summary>
        /// Adds a new asset
        /// </summary>
        /// <param name="entity">Asset to be added</param>
        /// <returns>Added asset</returns>
        public override Task<Asset> AddAsync(Asset entity)
        {
            return base.AddAsync(entity);
        }

        /// <summary>
        /// Delete a licence by its id
        /// </summary>
        /// <param name="id">Licence id</param>
        /// <returns></returns>
        public override  Task DeleteAsync(int id)
        {
             return base.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a paged list of licenses
        /// </summary>
        /// <param name="skip">The number of licences in the collection to skip before executing a select.</param>
        /// <param name="take">The number of licences that should be fetched from the collection.</param>
        /// <returns>CountedCollectionContainer of licences</returns>
        public override Task<Model.CountedCollectionContainer<Asset>> GetAllAsync(int skip, int take)
        {
            return base.GetAllAsync(skip, take);
        }

        /// <summary>
        /// Fetchs a asset by its id
        /// </summary>
        /// <param name="id">Asset id</param>
        /// <returns>Fetched asset</returns>
        public override Task<Asset> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates a asset
        /// </summary>
        /// <param name="entity">Asset to be updated</param>
        /// <returns>Updated asset</returns>
        public override Task<Asset> UpdateAsync(Asset entity)
        {
            return base.UpdateAsync(entity);
        }
    }
}
