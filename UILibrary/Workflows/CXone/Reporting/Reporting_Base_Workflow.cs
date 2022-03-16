using ApiLibrary.Authorization;
using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.Enums;
using UILibrary.PageObjects.CXone.Admin.Roles;
using UILibrary.PageObjects.CXone.Menus;
using UILibrary.PageObjects.CXone.TM;
using Utilities.Clusters;
using Utilities.Common;
using Utilities.Enums.API;
using Utilities.Factories;
using Utilities.Objects.API;
using Utilities.Objects.DTO.ACD;
using Utilities.Objects.DTO.CXone;
using Version = Utilities.Enums.API.Version;

namespace UILibrary.Workflows.CXone.Reporting.MSTR_Reports
{
    public class Reporting_Base_Workflow
    {
        protected readonly Task<IPage> Page;
        protected readonly Cluster Cluster;
        
        public Reporting_Base_Workflow(Task<IPage> page, Cluster cluster)
        {
            this.Page = page;
            this.Cluster = cluster;
        }

        /// <summary>
        /// Navigate to through any CXone application by Menu option
        /// </summary>
        /// <param name="app">CXone application name</param>
        /// <returns>Task</returns>
        public async Task NavigateToApp(AppPicker.App app)
        {
            var home = PageFactory.GetPage<Home>(Page);
            await home.AppPicker.OpenAppPanelAsync();
            await home.AppPicker.GoToAppAsync(app);
        }

        /// <summary>
        /// Navigate to specific MicroStrategy report
        /// </summary>
        /// <param name="reportName">Micro Strategy report name</param>
        /// <returns>Task</returns>
        public async Task GoToPrebuiltReports()
        {
            var reportSideBarPage = PageFactory.GetPage<ReportingSidebar>(Page);
            await reportSideBarPage.ClickOnPrebuiltReports();
        }

        /// <summary>
        /// Navigate to specific Role in Admin
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>Task</returns>
        public async Task NavigateToSpecificRole(AdminRole roleName)
        {
            await NavigateToApp(AppPicker.App.admin);
            var rolesPage = PageFactory.GetPage<RolesPage>(Page);
            await rolesPage.ClickOnRolesAndPermission();
            await rolesPage.ClickOnRole(roleName);
        }

        /// <summary>
        /// Navigate to specific MicroStrategy report
        /// </summary>
        /// <param name="tenant">Micro Strategy tenant</param>
        /// <returns>Task</returns>
        public async Task ImpersonateAndSupport(Tenant tenant)
        {
            var tenantsPage = PageFactory.GetPage<TM_TenantsPage>(Page);
            await tenantsPage.SetSearchField(tenant.tenantName);
            await tenantsPage.ClickTenant(tenant.tenantName);
            await tenantsPage.ClickImpersonateAndSupport();
        }

        /// <summary>
        /// Navigate to specific MicroStrategy report
        /// </summary>
        /// <param name="tenant">Micro Strategy tenant</param>
        /// <returns>Task</returns>
        public async Task ImpersonateAndConfigure(Tenant tenant)
        {
            var tenantsPage = PageFactory.GetPage<TM_TenantsPage>(Page);
            await tenantsPage.SetSearchField(tenant.tenantName);
            await tenantsPage.ClickTenant(tenant.tenantName);
            await tenantsPage.ClickImpersonateAndConfigure();
        }

        /// <summary>
        /// Get the auth context with its token for CXone - User Hub APIs
        /// </summary>
        /// <returns>MSTRApiAuthorization</returns>
        public CXoneApiAuthorization GetAuthContextCXone()
        {
            var AuthContextCXone = new CXoneApiAuthorization(Cluster);
            AuthContextCXone.GetToken();
            return AuthContextCXone;
        }

        /// <summary>
        /// Get the auth context with its token for ACD - inContact APIs
        /// </summary>
        /// <returns>MSTRApiAuthorization</returns>
        public InContactApiAuthorization GetAuthContextACD()
        {
            var AuthContextACD = new InContactApiAuthorization(Cluster);
            AuthContextACD.GetToken();            
            return AuthContextACD;
        }

        /// <summary>
        /// Enable or disable a permission for a specific Bi report
        /// </summary>
        public Tenant GetCurrentTenant()
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.UhUrl(Cluster, Uh_api.GetCurrentTenant);
            var response = AuthContextCXone.Get<Tenant>(url);
            return  response.Data.tenant;

        }

        /// <summary>
        /// Get Agent ID of an agent by username
        /// </summary>
        /// <param name="userName">User name of the agent</param>
        public int GetAgentID(string userName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetAgents);
            var agents = AuthContextCXone.Get<Agents>(url);
            var agent = agents.Data.agents.Find(agent => agent.userName == userName);
            return agent.agentId;
        }

        /// <summary>
        /// Get profile name of an agent by username
        /// </summary>
        /// <param name="userName">User name of the agent</param>
        public string GetProfileName(string userName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetAgents);
            var agents = AuthContextCXone.Get<Agents>(url);
            var agent = agents.Data.agents.Find(agent => agent.userName == userName);
            return agent.profileName;
        }

        /// <summary>
        /// Get profile name of an agent by username
        /// </summary>
        /// <param name="userName">User name of the agent</param>
        public string GetFullName()
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetAgents);
            var agents = AuthContextCXone.Get<Agents>(url);
            var agent = agents.Data.agents.Find(agent => agent.userName == AuthContextCXone.Username);
            return $"{agent.firstName} {agent.lastName}";
        }

        /// <summary>
        /// Get Team ID of a team by username
        /// </summary>
        /// <param name="userName">User name of the agent</param>
        public int GetTeamIDByAgent(string userName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetAgents);
            var agents = AuthContextCXone.Get<Agents>(url);
            var agent = agents.Data.agents.Find(agent => agent.userName == userName);
            return agent.teamId;
        }

        /// <summary>
        /// Get Campaign ID by Campaign name
        /// </summary>
        /// <param name="campaignName">Name of campaign</param>
        public int GetCampaignID(string campaignName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetCampaigns, Version.V1);
            var campaigns = AuthContextCXone.Get<Campaigns>(url);
            var campaign = campaigns.Data.campaigns.Find(campaign => campaign.campaignName == campaignName);
            return campaign.campaignId;
        }

        /// <summary>
        /// Get Skill ID by skill name
        /// </summary>
        /// <param name="skillName">Name of skill</param>
        public int GetSkillID(string skillName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetSkills, Version.V8);
            var skills = AuthContextCXone.Get<Skills>(url);
            var skill = skills.Data.skills.Find(skill => skill.skillName == skillName);
            return skill.skillId;
        }

        /// <summary>
        /// Get Unavailable Code ID by unavailable code name
        /// </summary>
        /// <param name="unavailableCodeName">Name of unavailable code</param>
        public int GetUnavailableCodeID(string unavailableCodeName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetUnavailableCodes, Version.V13);
            var unavailableCodes = AuthContextCXone.Get<UnavailableCodes>(url);
            var unavailableCode = unavailableCodes.Data.unavailableCodes.Find(unavailableCode => unavailableCode.outStateName == unavailableCodeName);
            return unavailableCode.outStateId;
        }

        /// <summary>
        /// Get Report ID by Report name
        /// </summary>
        /// <param name="reportName">Report name</param>
        public int GetReportID(string reportName)
        {
            var AuthContextCXone = GetAuthContextCXone();
            var url = ApiUtilities.AcdUrl(Cluster, Acd_api.GetReport, Version.V18);
            var reports = AuthContextCXone.Get<Reports>(url);
            var report = reports.Data.reports.Find(reportData => reportData.reportName == reportName);
            return report.reportId;
        }
    }
}