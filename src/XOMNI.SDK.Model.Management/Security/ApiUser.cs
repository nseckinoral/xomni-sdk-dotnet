using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Model.User;

namespace XOMNI.SDK.Model.Management.Security
{
    public class ApiUser
    {
        /// <summary>
        /// Unique id of the api user
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Username of the api user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Name of the api user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Password of the api user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Unique id of the assigned store
        /// </summary>
        public int? StoreId { get; set; }

        /// <summary>
        /// Rights collection
        /// </summary>
        public List<ApiUserRight> Rights { get; set; }

        public ApiUser()
        {
            Rights = new List<ApiUserRight>();
        }

        /// <summary>
        /// Indicates has public user right or not.
        /// </summary>
        /// <returns>Has public user right or not</returns>
        public bool IsPublic() { return this.Rights.Where(t => t.Id == (int)ApiUserRightEnum.PublicAPI).Any(); }


        /// <summary>
        /// Indicates has private user right or not.
        /// </summary>
        /// <returns>Has private user right or not</returns>
        public bool IsPrivate() { return this.Rights.Where(t => t.Id == (int)ApiUserRightEnum.PrivateAPI).Any(); }


        /// <summary>
        /// Indicates has management user right or not.
        /// </summary>
        /// <returns>Has management user right or not</returns>
        public bool IsManagement() { return this.Rights.Where(t => t.Id == (int)ApiUserRightEnum.ManagementAPI).Any(); }

    }
}
