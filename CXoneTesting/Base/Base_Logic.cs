using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.Workflows.CXone.Login;
using Utilities.Clusters;
using Utilities.GBUs;

namespace CXoneTesting.Base
{
    public abstract class Base_Logic
    {
        protected Cluster Cluster;
        protected Task<IPage> Page;
        private Base_Driver driver;

        public Base_Logic(Base_Driver driver)
        {
            this.driver = driver;   
            this.Cluster = driver.Cluster;
            this.Page = driver.Page;
        }

        public async Task LoginToCXone(string userName = null, string password = null, bool relogin = false)
        {
            userName ??= Cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Username;
            password ??= Cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Password;
            var loginWorkflow = new Login_Workflow(Page, Cluster);
            if (Page == null)
                Page = await loginWorkflow.LoginToCXone(userName, password, Cluster.CXoneDomain);
            else
                if(relogin || driver.Username != userName)
                    Page = await loginWorkflow.LogoutAndLoginToCXone(userName, password);
            driver.Page = Page;
            driver.Username = userName;
            Start();
        }

        public async Task LoginToCentral(string userName = null, string password = null, bool relogin = false)
        {
            userName ??= Cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Username;
            password ??= Cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Password;
            var loginWorkflow = new Login_Workflow(Page, Cluster);
            if (Page == null)
                Page = await loginWorkflow.LoginToCentral(userName, password, Cluster.ACD_Domain);
            else
                if (relogin || driver.Username != userName)
                    Page = await loginWorkflow.LogoutAndLoginToCXone(userName, password, isCentral: true);
            driver.Page = Page;
            driver.Username = userName;
            Start();
        }

        public abstract void Start();
        
    }
}
