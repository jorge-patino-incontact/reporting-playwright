using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.PageObjects.CXone.Menus;
using UILibrary.PageObjects.CXone.Reporting.PrebuiltReports;
using UILibrary.Workflows.CXone.Reporting.MSTR_Reports;
using Utilities.Clusters;
using Utilities.Factories;

namespace UILibrary.Workflows.CXone.Reporting.PrebuiltReports
{
    public class PrebuiltReports_Workflow: Reporting_Base_Workflow
    {
        public PrebuiltReports_Workflow(Task<IPage> page, Cluster cluster)
            : base(page, cluster) { }

        public async Task<bool> ValidatePrebuiltReportSectionIsDisplayed()
        {
            var prebuiltReportsPage = PageFactory.GetPage<PrebuiltReportsPage>(Page);
            await NavigateToApp(AppPicker.App.reporting);
            await GoToPrebuiltReports();
            return await prebuiltReportsPage.ValidatePrebuiltReportSectionIsVisible();
        }
    }
}
