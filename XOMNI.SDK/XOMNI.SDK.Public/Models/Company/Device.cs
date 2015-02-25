using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Company
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string Description { get; set; }
        public string DeviceTypeId { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}
