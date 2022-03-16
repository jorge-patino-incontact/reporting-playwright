using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers.Interactions;

namespace UILibrary.PageObjects.CXone.Menus
{
    public class AppPicker : BasePage
    {

        #region Selectors

        private static string openMenu => ".app-picker-panel";
        private static string closeMenu => ".app-picker-header";
        private static string admin => "#select-admin";
        private static string acd => "#select-acd";
        private static string max => "#select-max";
        private static string supervisor => "#select-supervisor";
        private static string cxoneStudio => "#select-webStudio";
        private static string studioAuthentication => "#select-studio";
        private static string wfm => "#select-scheduler";
        private static string qm => "#select-formManager";
        private static string coaching => "#select-coaching";
        private static string interactions => "#select-search";
        private static string myZone => "#select-my-space";
        private static string dashboard => "#select-dashboard";
        private static string analytics => "#select-analytics";
        private static string reporting => "#select-reporting";
        private static string reportingCentral => "#select-reportingClassic";
        private static string wfi => "#select-wfi";
        private static string performanceManagement => "#select-inview";
        private static string digital => "#select-digital";

        #endregion

        public enum App
        {
            admin,
            acd,
            max,
            supervisor,
            cxoneStudio,
            studioAuthentication,
            wfm,
            qm,
            coaching,
            interactions,
            myZone,
            analytics,
            dashboard,
            reporting,
            reportingCentral,
            wfi,
            performanceManagement,
            digital
        }

        public AppPicker(Task<IPage> page) : base(page) { }

        #region Interactions

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task OpenAppPanelAsync()
        {
            await _interactions.ClickAsync(openMenu, string.Format(ClickElementErrorMessage, openMenu, "App Panel nine square Menu"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CloseAppPanelAsync()
        {
            await _interactions.ClickAsync(closeMenu, string.Format(ClickElementErrorMessage, closeMenu, "Close App panel Menu"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public async Task GoToAppAsync(App application)
        {
            //string popups = "";
            (string, bool) app = application switch
            {
                App.admin => (admin, false),
                App.acd => (acd, false),
                App.max => (max, true),
                App.supervisor => (supervisor, true),
                App.cxoneStudio => (cxoneStudio, true),
                App.studioAuthentication => (studioAuthentication, true),
                App.wfm => (wfm, false),
                App.qm => (qm, false),
                App.coaching => (coaching, false),
                App.interactions => (interactions, false),
                App.myZone => (myZone, false),
                App.analytics => (analytics, false),
                App.dashboard => (dashboard, false),
                App.reporting => (reporting, false),
                App.reportingCentral => (reportingCentral, false),
                App.wfi => (wfi, false),
                App.performanceManagement => (performanceManagement, true),
                App.digital => (digital, true),
                _ => (acd, false),
            };
            if (app.Item2)
                await _interactions.ClickAndWaitForPageAsync(app.Item1, string.Format(ClickElementErrorMessage, app.Item1, application.ToString()));                
            else
                await _interactions.ClickAsync(app.Item1, string.Format(ClickElementErrorMessage, app.Item1, application.ToString()));
        }

        #endregion
    }
}
