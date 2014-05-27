using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Private.Metering.Log;

namespace XOMNI.SDK.Private.Metering.Log
{
    public class ItemShareResponseMeteringManagement : BaseMeteringManagement<ItemShareResponseMeteringLog>
    {
        protected override Model.Private.Metering.CounterTypes CounterType
        {
            get { return Model.Private.Metering.CounterTypes.ItemShareResponse; }
        }
    }
}
