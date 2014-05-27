using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model
{
    public sealed class Location
    {
        /// <summary>
        /// Longitude coordinate
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Latitude coordinate
        /// </summary>
        public double? Latitude { get; set; }

        public Location()
        {

        }

        public Location(double? longitude, double? latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
    }
}
