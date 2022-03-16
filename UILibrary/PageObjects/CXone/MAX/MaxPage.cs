using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers.Interactions;

namespace UILibrary.PageObjects.CXone.MAX
{
    public class MaxPage : BasePage
    {

        #region Selectors

        private static string phoneNumber => "#radioPhone";
        private static string stationId => "#radioStation";
        private static string softPhone => "#radioSoftPhone";
        private static string phoneNumberField => "#phoneNumberText";
        private static string stationIdField => "#stationIdText";
        private static string connectBtn => ".button .connect";
        private static string closeBtn => ".button .close";
        private static string newBtn => "//div[contains(text(),'New')]";
        private static string moreBtn => "//div[contains(text(),'More')]";
        private static string agentStateSection => "#agentStateSection";
        private static string logout => "//span[contains(text(),'Log out')]";
        private static string confirmLogout => "//button[@class='confirm-button'][text()='Log out']";

        #endregion

        public MaxPage(Task<IPage> page) : base(page) { }
        

        public async Task SetPhoneNumberField(string phoneNumber)
        {
            await _interactions.SendTextAsync(phoneNumberField, string.Empty, phoneNumber, nroPage:1);
        }

        public async Task ClickConnectBtn()
        {
            await _interactions.ClickAsync(connectBtn, string.Empty, nroPage: 1);
        }

        public async Task<bool> ValidateMaxIsLoadedAsync()
        {
            await _interactions.WaitForSelectorAsync(newBtn, string.Empty, nroPage: 1);
            return await _interactions.IsVisibleAsync(newBtn, true, string.Empty, nroPage: 1);
            ;
        }

        public async Task ClickLogoutBtn()
        {
            await _interactions.ClickAsync(agentStateSection, string.Empty, nroPage: 1);
            await _interactions.ClickAsync(logout, string.Empty, nroPage: 1);
            await _interactions.ClickAsync(confirmLogout, string.Empty, nroPage: 1);
        }
    }
}
