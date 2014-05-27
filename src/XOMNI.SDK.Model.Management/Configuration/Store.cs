using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Management.Configuration
{
    public class Store
    {
        /// <summary>
        /// Unique ID of the store.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the store.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the store.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Detailed address of the store.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Location of the store.
        /// </summary>
        public Location Location { get; set; }
        
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
