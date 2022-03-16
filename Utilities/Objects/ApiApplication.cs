using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Objects
{
    public class ApiApplication
    {
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public string VendorName { get; set; }
        public string ApiScope { get; set; }
        public string BasicAuthorization { get => $"{ApplicationName}@{VendorName}:{Id}"; }

        public ApiApplication()
        {
            Id = "ZWI1MGE4NmY3NGRlNGI1ODlmY2MxMGE3ZTRhNzM1ZDM=";
            ApplicationName = "inContact Studio";
            VendorName = "inContact Inc.";
            ApiScope = "RealTimeApi AdminApi AgentApi CustomApi AuthenticationApi PatronApi ReportingApi";
        }

        public ApiApplication(string id, string applicationName, string vendorName, string apiScope)
        {
            Id = id;
            ApplicationName = applicationName;
            VendorName = vendorName;
            ApiScope = apiScope;
        }
    }
}
