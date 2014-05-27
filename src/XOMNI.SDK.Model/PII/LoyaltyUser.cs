using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOMNI.SDK.Model.PII
{
    public class LoyaltyUser
    {
        public virtual string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PIIUserType { get; set; }
        public double? AvailablePoints { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
