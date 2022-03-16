using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utilities.GBUs;
using Utilities.Objects.DTO;

namespace Utilities.Clusters
{
    public class ClusterInitialize
    {
        public readonly Cluster cluster;
        private string businessUnitName;


        public ClusterInitialize(Cluster cluster)
        {
            this.cluster = cluster;
            init();
        }

        private void init() 
        {
            var clusterInfo = LoadInfo();
            cluster.Name = clusterInfo.Name;
            businessUnitName = clusterInfo.BusinessUnitName;
            BaseClusterUrl.SetBaseUrl(cluster);
            BiServerUrl.SetBiServerUrl(cluster);
            cluster.BusinessUnit = GetBusinessUnitContext();
        }

        private BaseBusinessUnit GetBusinessUnitContext()
        {
            var t = Type.GetType($"Utilities.GBUs.{businessUnitName}");
            return (BaseBusinessUnit)Activator.CreateInstance(t, cluster.Name);
        }

        private TestInfo LoadInfo()
        {
            var path = Directory.GetCurrentDirectory() + "\\TestInfo.json";
            var cadena = File.ReadAllText(path);
            var info = JsonConvert.DeserializeObject<TestInfo>(cadena);
            return info;
        }
    }
}
