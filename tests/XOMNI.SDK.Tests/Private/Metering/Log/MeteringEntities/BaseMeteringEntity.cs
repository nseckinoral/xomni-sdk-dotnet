using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Tests.Extensions;


namespace XOMNI.SDK.Tests.Private.Metering.Log.MeteringEntities
{
    public abstract class BaseMeteringEntity : TableEntity
    {
        public DateTime CreatedDate { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public BaseMeteringEntity()
        {

        }

        public BaseMeteringEntity(DateTime meteringDate)
            : base(((int)meteringDate.ToOADate()).ToString(), Guid.NewGuid().ToString())
        {
            this.CreatedDate = meteringDate;
            this.Year = meteringDate.Year;
            this.Day = meteringDate.Day;
            this.Month = meteringDate.Month;
            this.Week = meteringDate.GetWeekOfYear();
        }
    }
}
