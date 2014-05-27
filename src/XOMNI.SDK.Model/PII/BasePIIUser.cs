using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.PII
{
    public abstract class BasePIIUser
    {
        public virtual string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PIIUserType { get; set; }
    }
}
