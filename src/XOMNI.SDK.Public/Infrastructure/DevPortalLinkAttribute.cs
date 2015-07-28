using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Infrastructure
{
    public class DevPortalLinkAttribute : Attribute
    {
        public string Link { get; set; }
        public DevPortalLinkAttribute(string link)
        {
            this.Link = link;
        }
    }
}
