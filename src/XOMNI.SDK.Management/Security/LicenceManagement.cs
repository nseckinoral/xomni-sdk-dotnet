using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model;
using XOMNI.SDK.Model.Management.Security;

namespace XOMNI.SDK.Management.Security
{
    /// <summary>
    /// Manages licences.
    /// </summary>
    public class LicenseManagement : BaseCRUDSkipTakeManagement<License>
    {
        protected override Core.ApiAccess.CRUDApiAccessBase<License> ApiAccess
        {
            get { return new ApiAccess.Security.License(); }
        }

        protected SDK.Management.ApiAccess.Security.LicenceAudit AuditApiAccess
        {
            get { return new ApiAccess.Security.LicenceAudit(); }
        }

        /// <summary>
        /// Adds a new license
        /// </summary>
        /// <param name="entity">License to be added</param>
        /// <returns>Added license</returns>
        public override Task<License> AddAsync(License entity)
        {
            return base.AddAsync(entity);
        }

        /// <summary>
        /// Delete a licence by its id
        /// </summary>
        /// <param name="id">Licence id</param>
        /// <returns></returns>
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        /// <summary>
        /// Returns a paged list of licenses
        /// </summary>
        /// <param name="skip">The number of licences in the collection to skip before executing a select.</param>
        /// <param name="take">The number of licences that should be fetched from the collection.</param>
        /// <returns>CountedCollectionContainer of license</returns>
        public override Task<Model.CountedCollectionContainer<License>> GetAllAsync(int skip, int take)
        {
            return base.GetAllAsync(skip, take);
        }

        /// <summary>
        /// Fetchs a license by its id
        /// </summary>
        /// <param name="id">License id</param>
        /// <returns>Fetched license</returns>
        public override Task<License> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates a license
        /// </summary>
        /// <param name="entity">License to be updated</param>
        /// <returns>Updated license</returns>
        public override Task<License> UpdateAsync(License entity)
        {
            return base.UpdateAsync(entity);
        }

        /// <summary>
        /// To fetch unassigned licenses
        /// </summary>
        /// <returns>Unassigned licenses</returns>
        public Task<List<License>> GetUnassignedLicencesAsync()
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("onlyUnassignedUsers", true.ToString());
            return ApiAccess.GetByCustomListOperationUrlAsync(additionalParameters, this.ApiCredential);
        }

        /// <summary>
        /// To fetch licenses audit logs
        /// </summary>
        /// <returns>Audit logs.</returns>
        public Task<CountedCollectionContainer<LicenseAuditLog>> GetAuditLogsAsync(int skip, int take)
        {
            return AuditApiAccess.GetAsync(skip, take, this.ApiCredential);
        }
    }
}
