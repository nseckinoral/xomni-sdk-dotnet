﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Models.OmniPlay
{
    public class WishlistImportRequest
    {
        public Guid OmniTicket { get; set; }
        public Location GpsLocation { get; set; }
    }
}
