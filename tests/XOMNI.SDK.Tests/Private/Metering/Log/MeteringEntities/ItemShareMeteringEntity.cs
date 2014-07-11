﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public class ItemShareMeteringEntity : BaseMeteringEntity
    {
        public int SocialPostId { get; set; }
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public string SocialPostContent { get; set; }
        public string PIIUsername { get; set; }
        public int PIIUserId { get; set; }

        public ItemShareMeteringEntity()
        {

        }

        public ItemShareMeteringEntity(DateTime meteringDate)
            : base(meteringDate)
        {

        }
    }
}
