using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Management.Security
{
    public class License
    {
        /// <summary>
        /// Unique id of the license
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username of the license
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Name of the license
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Password of the license
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Assigned store's id of the license
        /// </summary>
        public int? StoreId { get; set; }
    }
}
