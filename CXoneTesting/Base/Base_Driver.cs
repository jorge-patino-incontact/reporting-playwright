using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Utilities.Clusters;

namespace CXoneTesting.Base
{
    public class Base_Driver : IDisposable
    {
        public readonly Cluster Cluster;
        public Task<IPage> Page;
        public string Username;

        public Base_Driver()
        {
            Cluster = new ClusterInitialize(new Cluster()).cluster;
            Username = string.Empty;
        }

        public void Dispose()
        {
            Console.WriteLine("Inside CleanUp or Dispose method");
        }
    }
}
