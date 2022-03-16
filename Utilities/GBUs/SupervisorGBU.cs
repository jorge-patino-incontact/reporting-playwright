using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Utilities.Objects.POCO;

namespace Utilities.GBUs
{
    class SupervisorGBU : BaseBusinessUnit
    {

        public SupervisorGBU(string clusterName) : base(clusterName)
        {
        }


        public override void GetSpecificTestRunInfo()
        {
            GetSpecificGuaranteedObjectNames();
        }

        private void GetSpecificGuaranteedObjectNames()
        {
            var digits = Regex.Matches(ClusterName, "\\d").Count;
            string domainRaw = ClusterName.Insert(ClusterName.Length - digits, digits < 2 ? "000" : "00");
            string businessUnitName = this.GetType().Name;
            int version = GetGBUVersion();
            string emailDomain = "niceincontact.com";


            // Users
            Agent = new Dictionary<Enum, Agent>
            {
                { Agents.Administrator01,   new Agent { Username = $"{Agents.Administrator01}.{businessUnitName}.{domainRaw}.{version}@{emailDomain}".ToLower() } },
                { Agents.Manager01,         new Agent { Username = $"{Agents.Manager01}.{businessUnitName}.{domainRaw}.{version}@{emailDomain}".ToLower() } },
                { Agents.Agent01,           new Agent { Username = $"{Agents.Agent01}.{businessUnitName}.{domainRaw}.{version}@{emailDomain}".ToLower() } },
                { Agents.Agent02,           new Agent { Username = $"{Agents.Agent02}.{businessUnitName}.{domainRaw}.{version}@{emailDomain}".ToLower() } },
            };
            //Phone
            Phone = "4006880004";
            Phone2 = "4006880000";
            Phone3 = "4006880008";

        }

        /// <summary>
        /// Get the GBU version depending on the cluster where the test is executed
        /// </summary>
        private int GetGBUVersion()
        {
            var version = new Dictionary<string, int>
            {
            };
            if (version.ContainsKey(ClusterName))
                return version[ClusterName];
            return 1;
        }
    }
}
