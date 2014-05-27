using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.Private.Catalog
{
    public class MailTemplate 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BodyTemplate { get; set; }
        public string ItemTemplate { get; set; }
        public string From { get; set; }
        public string FromDisplayName { get; set; }
        public string Subject { get; set; }
    }
}
