using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class ItemLikeMeteringEntity : BaseMeteringEntity
    {
        public string TargetPlatform { get; set; }
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public List<int> KnownPIIUserIds { get; set; }
        public List<SocialPlatformProfileMeteringLogEntity> UnknownUserProfiles { get; set; }
        public int LikeCount { get; set; }

        public ItemLikeMeteringEntity()
        {

        }

        public ItemLikeMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
