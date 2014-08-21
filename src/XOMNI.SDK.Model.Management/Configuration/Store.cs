using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Management.Configuration
{
    public class Store : XOMNI.SDK.Model.Company.Store
    {
        /// <summary>
        /// Licenses of the store
        /// </summary>
        public List<Model.Management.Security.License> Licenses { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Store()
        {
            Licenses = new List<Model.Management.Security.License>();
            Location = new Location();
        }
    }
}
