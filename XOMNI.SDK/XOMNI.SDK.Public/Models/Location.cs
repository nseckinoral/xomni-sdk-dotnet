using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Models
{
    public class Location
    {
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public override string ToString()
        {
            Validator.For(Longitude, "Longitude").IsNotNull();
            Validator.For(Latitude, "Latitude").IsNotNull();

            string longitude = string.Format(new CultureInfo("en-US"),"{0:00.000000}", Longitude);
            string latitude = string.Format(new CultureInfo("en-US"),"{0:00.000000}", Latitude);

            return string.Format("{0};{1}", longitude, latitude);
        }
    }
}
