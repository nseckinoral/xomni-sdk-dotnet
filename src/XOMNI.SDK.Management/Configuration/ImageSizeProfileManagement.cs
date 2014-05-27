using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;

namespace XOMNI.SDK.Management.Configuration
{
    public class ImageSizeProfileManagement : ManagementBase
    {
        private ApiAccess.Configuration.ImageSizeProfile imageSizeProfileApi;

        public ImageSizeProfileManagement()
        {
            imageSizeProfileApi = new ApiAccess.Configuration.ImageSizeProfile();
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile> AddAsync(XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile profile)
        {
            return imageSizeProfileApi.AddAsync(profile, this.ApiCredential);
        }

        public Task DeleteAsync(int profileId)
        {
            return imageSizeProfileApi.DeleteAsync(profileId, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile> GetAsync(int profileId)
        {
            return imageSizeProfileApi.GetAsync(profileId, this.ApiCredential);
        }

        public Task<XOMNI.SDK.Model.CountedCollectionContainer<XOMNI.SDK.Model.Management.Configuration.ImageSizeProfile>> GetAllAsync(int skip, int take)
        {
            return imageSizeProfileApi.GetAllAsync(skip, take, this.ApiCredential);
        }
    }
}
