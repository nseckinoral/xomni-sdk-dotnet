using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.Company
{
    public class StoreStorageItem
    {
        public int StoreId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsPublic { get; set; }
        public Byte[] TimeStamp { get; set; }
    }
}
