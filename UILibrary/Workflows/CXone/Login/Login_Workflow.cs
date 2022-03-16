using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using UILibrary.PageObjects.CXone.Login;
using UILibrary.PageObjects.CXone.Menus;
using UILibrary.WebDrivers;
using Utilities.Clusters;
using Utilities.Factories;

namespace UILibrary.Workflows.CXone.Login
{
    public class Login_Workflow
    {
        protected Task<IPage> Page;
        protected readonly Cluster Cluster;

        public Login_Workflow(Task<IPage> page, Cluster cluster)
        {
            this.Page = page;
            this.Cluster = cluster;
        }

        /// <summary>
        /// Basic Login to CXone User Hub
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="CXoneDomain">CXone domain</param>
        /// <returns>Task<IPage></returns>
        public async Task<Task<IPage>> LoginToCXone(string userName, string password, string CXoneDomain)
        {
            var LoginPage = Config.Init();
            Page = LoginPage._page;
            LoginPage.MainPageUrl = CXoneDomain + LoginPage.MainPageUrl;
            await LoginPage.GoLoginPageAsync();
            await FillLoginForm(userName, password);
            return LoginPage._page;
        }

        /// <summary>
        /// Basic Login to Central
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="CentralDomain">Central domain</param>
        /// <returns>Task<IPage></returns>
        public async Task<Task<IPage>> LoginToCentral(string userName, string password, string CentralDomain)
        {
            var LoginPage = Config.Init();
            Page = LoginPage._page;
            LoginPage.MainPageUrl = CentralDomain + LoginPage.CentralMainPageUrl;
            await LoginPage.GoLoginPageAsync();
            await FillLoginForm(userName, password, isCentral: true);
            return LoginPage._page;
        }

        public async Task<Task<IPage>> LogoutAndLoginToCXone(string userName, string password, bool isCentral = false)
        {
            await LogoutCXone();
            var loginPage = await FillLoginForm(userName, password, isCentral);
            return loginPage._page;
        }

        private async Task<LoginPage> FillLoginForm(string userName, string password, bool isCentral = false) 
        {
            var loginPage = PageFactory.GetPage<LoginPage>(Page);
            await loginPage.SetEmailFieldAsync(userName, isCentral);
            await loginPage.ClickNextButtonAsync(isCentral);
            await loginPage.SetPasswordFieldAsync(password, isCentral);
            await loginPage.ClickSingInButtonAsync(isCentral);
            await loginPage.AwaitHomePage(isCentral);
            return loginPage;
        }

        private async Task LogoutCXone()
        {
            var home = PageFactory.GetPage<Home>(Page);
            await home.NavMenu.ClickUserPanelAsync();
            await home.NavMenu.ClickLogoutLinkAsync();
            await home.NavMenu.ClickYesButtonAsync();
        }
    }

}
