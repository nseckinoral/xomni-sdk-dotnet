using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XOMNI.SDK.Model.Private.Analytics.Log;

namespace XOMNI.SDK.Private.Analytics.Log
{
    public class ItemViewAnalyticsManagement : BaseAnalyticsManagement<ItemViewAnalyticsLog>
    {
        protected override Model.Private.Analytics.CounterTypes CounterType
        {
            get { return Model.Private.Analytics.CounterTypes.ItemView; }
        }
    }
}
