using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers.Interactions;

namespace UILibrary.PageObjects.CXone.Menus
{
    public class NavMenu : BasePage
    {
        #region Selectors
        private static string userPanel => ".user-panel";
        private static string logoutBtn => "#logout";
        private static string confirmBtn => "//button[text()='Yes']";

        #endregion

        public NavMenu(Task<IPage> page) : base(page) { }

        public async Task ClickUserPanelAsync()
        {
            await _interactions.ClickAsync(userPanel, string.Format(ClickElementErrorMessage, userPanel, "Open user panel menu"));
        }

        public async Task ClickLogoutLinkAsync()
        {
            await _interactions.ClickAsync(logoutBtn, string.Format(ClickElementErrorMessage, logoutBtn, "Logout button"));
        }

        public async Task ClickYesButtonAsync()
        {
            await _interactions.ClickAsync(confirmBtn, string.Format(ClickElementErrorMessage, confirmBtn, "Confirm YES button"));
        }
    }
}
