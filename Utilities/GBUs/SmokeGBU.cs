using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Utilities.Objects.POCO;

namespace Utilities.GBUs
{
    public class SmokeGBU : BaseBusinessUnit
    {
        public SmokeGBU(string clusterName) : base(clusterName)
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
                { "SC10", 5 },
                { "SC11", 3 },
                { "DO28", 5 },
                { "DO32", 3 },
                { "DO72", 3 },
                { "SO30", 5 },
                { "SO31", 2 },
                { "DO81", 3 },
                { "DO90", 26 },
                { "TC2", 2 },
                { "L32", 2 },
                { "C15", 2 },
                { "C40", 2 },
            };
            if (version.ContainsKey(ClusterName))
                return version[ClusterName];
            return 1;
        }
    }
}
