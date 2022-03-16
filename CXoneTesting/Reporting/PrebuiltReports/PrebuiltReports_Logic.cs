using CXoneTesting.Base;
using System.Threading.Tasks;
using UILibrary.Workflows.CXone.Reporting.PrebuiltReports;

namespace CXoneTesting.Reporting.PrebuiltReports
{
    public class PrebuiltReports_Logic : Base_Logic
    {
        private PrebuiltReports_Workflow PrebuiltReports_Workflow;

        public PrebuiltReports_Logic(Base_Driver driver)
            : base(driver) { }

        public override void Start()
        {
            PrebuiltReports_Workflow = new PrebuiltReports_Workflow(Page, Cluster);
        }

        public async Task<bool> ValidatePrebuiltReportSectionIsDisplayed()
        {
            await LoginToCXone();
            var result = await PrebuiltReports_Workflow.ValidatePrebuiltReportSectionIsDisplayed();
            return result;

        }
    }
}
