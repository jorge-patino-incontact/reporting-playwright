using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers.Interactions;

namespace UILibrary.PageObjects.CXone.Menus
{
    public class ReportingSidebar : BasePage
    {
        #region Selectors

        private static string CentralPrebuiltReports => "#PrebuiltReports";

        #endregion

        public ReportingSidebar(Task<IPage> page) : base(page) { }

        public async Task ClickOnPrebuiltReports()
        {
            await _interactions.ClickAsync(CentralPrebuiltReports, string.Format(ClickElementErrorMessage, CentralPrebuiltReports, "Prebuilt Reports section"));
        }
    }
}
