using System;

namespace XOMNI.SDK.Model.Management.Integration
{
    public class EndpointDetail
    {
        public string ServiceName { get; set; }
        public string ManagementPortalUrl { get; set; }
        public EndpointCreationStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
