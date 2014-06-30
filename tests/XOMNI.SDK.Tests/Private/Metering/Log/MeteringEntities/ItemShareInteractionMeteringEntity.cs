﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class ItemShareInteractionMeteringEntity : BaseMeteringEntity
    {
        public int TargetPostId { get; set; }
        public int RelatedItemId { get; set; }
        public string Content { get; set; }
        public int TargetCommentId { get; set; }

        public ItemShareInteractionMeteringEntity()
        {

        }

        public ItemShareInteractionMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
