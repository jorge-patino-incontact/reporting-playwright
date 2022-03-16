using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers;

namespace UILibrary.PageObjects.CXone.Login
{
    public class LoginPage : BasePage
    {
        #region Selectors

        private static string EmailField => "#emailFieldNext";
        private static string SsoBtn => "#ssoBtn";
        private static string NextBtn => "#nextBtn";
        private static string PasswordField => "#mfaPassField";
        private static string BackBtn => "#backBtn";
        private static string SingInBtn => "#mfaLoginBtn";
        private static string ForgotLink => "#mfa-forgot-password-link";
        private static string MainHomePage => "//body[@class='bg-grey new-nav']";
        private static string CentralMainHomePage => "//body[@id='ctl00_evolveBody']";
        private static string CentralEmailField => "#ctl00_BaseContent_msl_txtUsername";
        private static string CentralNextBtn => "#ctl00_BaseContent_btnNext";
        private static string CentralPasswordField => "#ctl00_BaseContent_mslp_tbxPassword";
        private static string CentralSingInBtn => "#ctl00_BaseContent_mslp_btnLogin";

        #endregion

        public LoginPage(IBrowserDriver browserDriver) : base(browserDriver)
        {
            MainPageUrl = "login";
            CentralMainPageUrl = "inContact/Login.aspx";
        }

        public LoginPage(Task<IPage> page) : base(page) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GoLoginPageAsync()
        {
            if (!(await _page).Url.Contains(MainPageUrl))
            {
                await _interactions.GoToUrl(MainPageUrl, NavigationErrorMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task SetEmailFieldAsync(string username, bool isCentral = false)
        {
            if(isCentral)
                await _interactions.SendTextAsync(CentralEmailField, username, string.Format(SendKeysErrorMessage, CentralEmailField, "Username field", username));
            else
                await _interactions.SendTextAsync(EmailField, username, string.Format(SendKeysErrorMessage, EmailField, "Username field", username));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task SetPasswordFieldAsync(string password, bool isCentral = false)
        {
            if (isCentral)
                await _interactions.SendTextAsync(CentralPasswordField, password, string.Format(SendKeysErrorMessage, CentralPasswordField, "Password field", password));
            else
                await _interactions.SendTextAsync(PasswordField, password, string.Format(SendKeysErrorMessage, PasswordField, "Password field", password));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClickNextButtonAsync(bool isCentral = false)
        {
            if (isCentral)
                await _interactions.ClickAsync(CentralNextBtn, string.Format(ClickElementErrorMessage, CentralNextBtn, "Next button"));
            else
                await _interactions.ClickAsync(NextBtn, string.Format(ClickElementErrorMessage, NextBtn, "Next button"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClickSingInButtonAsync(bool isCentral = false)
        {
            if (isCentral)
                await _interactions.ClickAsync(CentralSingInBtn, string.Format(ClickElementErrorMessage, CentralSingInBtn, "Sing In button"));
            else
                await _interactions.ClickAsync(SingInBtn, string.Format(ClickElementErrorMessage, SingInBtn, "Sing In button"));
        }

        public async Task AwaitHomePage(bool isCentral = false)
        {
            if (isCentral)
                await _interactions.WaitForSelectorAsync(CentralMainHomePage, string.Format(NotFoundElementMessage, CentralMainHomePage, "Main Home Page"), new FrameWaitForSelectorOptions { Timeout = 60000 });
            else
                await _interactions.WaitForSelectorAsync(MainHomePage, string.Format(NotFoundElementMessage, MainHomePage, "Main Home Page"), new FrameWaitForSelectorOptions { Timeout = 60000 });
        }
    }
}
