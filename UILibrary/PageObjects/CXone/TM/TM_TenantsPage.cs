using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UILibrary.PageObjects.CXone.TM
{
    public class TM_TenantsPage : BasePage
    {
        #region Selectors
        private static string searchInput => "//*[@placeholder='Start typing to find tenants']";
        private static string searchBtn => "";
        private static string cleanSearchBtn => "";
        private static string dataGrid => "//div[@role='grid']";
        private static string tenantNameCell(string tenantName) => $"//*[@col-id='tenantName']//*[text()='{tenantName}']";
        private static string menuSettingsBtn => "#more-settings-button-new";
        private static string impersonateAndSupport => "#launchSupportImpersonation-new";
        private static string impersonateAndConfigure => "#launchImpersonation-new";


        #endregion

        public TM_TenantsPage(Task<IPage> page) : base(page) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantName"></param>
        /// <returns></returns>
        public async Task SetSearchField(string tenantName)
        {
            //await _interactions.WaitForSelectorAsync(firstRow, string.Format(NotFoundElementMessage, firstRow, "first row on Prebuilt Reports list"));
            await _interactions.SendTextAsync(searchInput, tenantName, string.Format(SendKeysErrorMessage, searchInput, "Tenants > Search input", tenantName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClickImpersonateAndSupport()
        {
            await _interactions.ClickAsync(menuSettingsBtn, string.Format(ClickElementErrorMessage, menuSettingsBtn, "more settings menu"));
            await _interactions.ClickAsync(impersonateAndSupport, string.Format(ClickElementErrorMessage, impersonateAndSupport, "Impersonate & Support button"));
            await _interactions.WaitForTimeoutAsync(2000);
            await _page.Result.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClickImpersonateAndConfigure()
        {
            await _interactions.ClickAsync(menuSettingsBtn, string.Format(ClickElementErrorMessage, menuSettingsBtn, "more settings menu"));
            await _interactions.ClickAsync(impersonateAndConfigure, string.Format(ClickElementErrorMessage, impersonateAndConfigure, "Impersonate & Configure button"));
            await _page.Result.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantName"></param>
        /// <returns></returns>
        public async Task ClickTenant(string tenantName, bool biReport = true)
        {
            await _interactions.WaitForTimeoutAsync(2000);
            await _interactions.ClickAsync(tenantNameCell(tenantName), string.Format(ClickElementErrorMessage, tenantNameCell(tenantName), "tenant row on tenants list"));

        }
    }
}
