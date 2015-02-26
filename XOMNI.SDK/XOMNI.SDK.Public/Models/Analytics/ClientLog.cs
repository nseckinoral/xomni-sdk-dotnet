using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Analytics
{
    public class ClientLog
    {
        public string CounterName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Value { get; set; }
        public string DataBag { get; set; }
    }
}
