using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class ItemShareResponseMeteringEntity : BaseMeteringEntity
    {
        public int TargetPostId { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int SocialPlatformId { get; set; }
        public string PlatformDependentId { get; set; }

        public ItemShareResponseMeteringEntity()
        {

        }
        public ItemShareResponseMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
