using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Model.Management.Security;

namespace XOMNI.SDK.Management.Security
{
    public class PrivateApiUserManagement : BaseCRUDSkipTakeManagement<ApiUser>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<ApiUser> ApiAccess
        {
            get { return new Management.ApiAccess.Security.PrivateApiUser(); }
        }

        /// <summary>
        /// Adds a new api user
        /// </summary>
        /// <param name="entity">ApiUser to be added</param>
        /// <returns>Added api user</returns>
        public override async Task<ApiUser> AddAsync(ApiUser entity)
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
        /// <returns>CountedCollectionContainer of private api user</returns>
        public override async Task<Model.CountedCollectionContainer<ApiUser>> GetAllAsync(int skip, int take)
        {
            return await base.GetAllAsync(skip, take);
        }

        /// <summary>
        /// Fetchs a api user by its id
        /// </summary>
        /// <param name="id">ApiUser id</param>
        /// <returns>Fetched api user</returns>
        public override async Task<ApiUser> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates a api user
        /// </summary>
        /// <param name="entity">ApiUser to be updated</param>
        /// <returns>Updated api user</returns>
        public override async Task<ApiUser> UpdateAsync(ApiUser entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}
