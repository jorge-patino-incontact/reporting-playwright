using CXoneTesting.Base;
using Xunit;

namespace CXoneTesting.Reporting.PrebuiltReports
{
    public class PrebuiltReports_Driver : Base_Category, IClassFixture<Base_Driver>
    {
        private readonly PrebuiltReports_Logic PrebuiltReports_Logic;
        public PrebuiltReports_Driver(Base_Driver setup)
        {
            PrebuiltReports_Logic = new PrebuiltReports_Logic(setup);
        }

        [Fact]
        public void PrebuiltReports_VerifyIsNotDisplayedWhenPermissionIsNotEnabled()
        {
            var result = PrebuiltReports_Logic.ValidatePrebuiltReportSectionIsDisplayed();
            Assert.True(result.Result);
        }
    }
}
