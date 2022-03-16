using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.Enums;

namespace UILibrary.PageObjects.CXone.Admin.Roles
{
    public class RolesPage : BasePage
    {
        #region Selectors
        private static string RolesSection => "//a[@id='roleManagement']";
        private static string RoleRow => "//div[@role='rowgroup']/div[@row-id='{0}']";
        private static string PermissionTab => "//div[@class='title-container']/span[text() ='{0}']";
        private static string ReportingPermissions => "//a[@name='Reporting']";
        private static string PermissionToggle => "//div[@class='privilege-text' and text()='{0}']";
        #endregion


        public RolesPage(Task<IPage> page) : base(page) { }

        public async Task ClickOnRolesAndPermission()
        {
            await _interactions.ClickAsync(RolesSection, string.Format(ClickElementErrorMessage, RolesSection, "Roles and Permissions section"));
        }

        public async Task ClickOnRole(AdminRole role)
        {
            var selector = string.Format(RoleRow, (int)role);
            await _interactions.ClickAsync(selector, string.Format(ClickElementErrorMessage, selector, $"Role: {role}"));
        }

        public async Task ClickOnTab(AdminRoleTab tabName)
        {
            var selector = string.Format(PermissionTab, tabName);
            await _interactions.ClickAsync(selector, string.Format(ClickElementErrorMessage, selector, $"Role tab: {tabName}"));
        }

        public async Task ClickOnReportingPermissionSection()
        {
            await _interactions.ClickAsync(ReportingPermissions, string.Format(ClickElementErrorMessage, ReportingPermissions, "Reporting permissions"));
        }

        public async Task<bool> ValidateThatPermissionIsVisible(string permissionName)
        {
            var selector = string.Format(PermissionToggle, permissionName);
            return await _interactions.IsVisibleAsync(selector, true, string.Format(VisibilityErrorMessage, selector, $"Permission: {permissionName}", true));
        }
    }
}
