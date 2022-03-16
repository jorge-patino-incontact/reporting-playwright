using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UILibrary.PageObjects.CXone.Reporting.PrebuiltReports
{
    public class PrebuiltReportsPage : BasePage
    {
        #region Selectors
        private static string mstr_Iframe => "//*[@id='mstr-dossier']/descendant::Iframe";
        private static string searchInput => "//input[@placeholder='Start typing to find report']";
        private static string searchBtn => "//button[@class='search-btn search-on-keypress-btn']";
        private static string cleanSearchBtn => "//button[@class='search-icons clear-btn ng-star-inserted']";
        private static string dataGrid => "//div[@role='grid']";
        private static string firstRow => "//div[@col-id='displayName'][@role='gridcell']";
        private static string centralFirstRow => "//input[@placeholder='Start typing to find report']";
        private static string centralSearchInput => "//input[@placeholder='Start typing to find report']";
        private static string reportNameCell(string reportName) => $"//*[text()='{reportName}']";
        private static string centralReportNameCell(string reportName) => $"//*[@title='{reportName}']";
        private static string pageTitle => ".page-title";

        #endregion

        public PrebuiltReportsPage(Task<IPage> page) : base(page) { }

        public async Task<bool> ValidateReportIsPresent(string reportName, bool visible)
        {
            FrameWaitForSelectorOptions frameWaitForSelectorOptions;
            if (visible)
                frameWaitForSelectorOptions = new FrameWaitForSelectorOptions { State = WaitForSelectorState.Visible };
            else
                frameWaitForSelectorOptions = new FrameWaitForSelectorOptions { State = WaitForSelectorState.Hidden };
            await _interactions.WaitForSelectorAsync(reportNameCell(reportName), string.Format(NotFoundElementMessage, firstRow, "first row on Prebuilt Reports list"), frameWaitForSelectorOptions);
            return await _interactions.IsVisibleAsync(reportNameCell(reportName), visible, 
                string.Format(VisibilityErrorMessage, reportNameCell(reportName), "report row on Prebuilt Reports list", visible));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public async Task SetSearchField(string reportName, bool isCentral = false)
        {
            if(isCentral)
            {
                await _interactions.WaitForSelectorAsync(centralFirstRow, string.Format(NotFoundElementMessage, centralFirstRow, "First row on Prebuilt Reports list"));
                await _interactions.SendTextAsync(centralSearchInput, reportName, string.Format(SendKeysErrorMessage, centralSearchInput, "Prebuilt reports > Search input", reportName));
            }
            else
            {
                await _interactions.WaitForSelectorAsync(firstRow, string.Format(NotFoundElementMessage, firstRow, "first row on Prebuilt Reports list"));
                await _interactions.SendTextAsync(searchInput, reportName, string.Format(SendKeysErrorMessage, searchInput, "Prebuilt reports > Search input", reportName));
            }
                     
        }

        /// <summary>
        /// Validate Report visibility in Central
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public async Task<bool> ValidateReportVisibilityInCentral(string reportName)
        {
            await _interactions.WaitForTimeoutAsync(2000);
            return await _interactions.IsVisibleAsync(centralReportNameCell(reportName), false, string.Format(VisibilityErrorMessage, centralReportNameCell(reportName), $"Report in Prebuilt Reports: '{reportName}'", false));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClickFirstReport()
        {
            await _interactions.WaitForTimeoutAsync(2000);
            await _interactions.ClickAsync(firstRow, string.Format(ClickElementErrorMessage, firstRow, "first row on Prebuilt Reports list"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public async Task ClickReport(string reportName, bool biReport = true)
        {
            await _interactions.WaitForTimeoutAsync(2000);
            await _interactions.ClickAsync(reportNameCell(reportName), string.Format(ClickElementErrorMessage, reportNameCell(reportName), "report row on Prebuilt Reports list"));
            if (biReport)
            {
                var Frame = await (await _interactions.WaitForSelectorAsync(mstr_Iframe, string.Format(IframeErrorMessage, mstr_Iframe, "MicroStrategy report"))).ContentFrameAsync();
                await Frame.WaitForLoadStateAsync(LoadState.Load);
            }
        }

        public async Task<bool> ValidatePrebuiltReportSectionIsVisible()
        {
            await _interactions.WaitForTimeoutAsync(2000);
            return await _interactions.IsVisibleAsync(pageTitle, true, string.Format(VisibilityErrorMessage, pageTitle, $"Prebuilt Reports section", true));
        }

    }
}
