using Microsoft.Playwright;
using System.Threading.Tasks;
using UILibrary.WebDrivers;
using UILibrary.WebDrivers.Interactions;

namespace UILibrary.PageObjects
{
    public class BasePage
    {
        // Common Error Messages
        protected string UnsupportedVersionMessage  = "Unsupported version supplied: {0}";
        protected string ExceptionCaughtMessage     = "Exception!: {0}";
        protected string NotFoundElementMessage     = "The Control: {0} : {1} was not found";
        protected string ElementIsNotHiddenMessage  = "The Control: {0} : {1} was still visible";
        protected string ElementIsEmptyMessage      = "The Control: {0} : {1} is empty";
        protected string ClickElementErrorMessage   = "Failed when try to click on the control: {0} : {1}.\n";
        protected string VisibilityErrorMessage     = "Failed to validate control {0} : {1} visibility. Expected: {2} - Actual: ";
        protected string IframeErrorMessage         = "Exception in detecting frame: {0} : {1}";
        protected string UploadFileErrorMessage     = "Failed to upload file {0} in \"{1}\", Exception Message : ";
        protected string DownloadFileErrorMessage   = "Failed to download file {0} from \"{1}\", Exception Message : ";
        protected string NavigationErrorMessage     = "Navigation Failed. Expected: {0} - Actual: {1}";
        protected string SetFieldErrorMessage       = "Failed to set control {0} : {1}. Expected value: {2} - current value: ";
        protected string SendKeysErrorMessage       = "Failed to set keys \"{2}\" on control {0} : {1}.";
        protected string JavascriptErrorMessage     = "Failed while executing javascript function for {0}, Exception Message : ";

        public readonly Task<IPage> _page;
        protected readonly Interactions _interactions;

        public string MainPageUrl { get; set; }

        public string CentralMainPageUrl { get; set; }

        public BasePage(IBrowserDriver browserDriver)
        {
            _page = CreatePageAsync(browserDriver.Current);
            _interactions = new Interactions(_page);
        }


        public BasePage(Task<IPage> page)
        {
            _page = page;
            _interactions = new Interactions(_page);
        }

        private async Task<IPage> CreatePageAsync(Task<IBrowser> browser)
        {
            var options = new BrowserNewPageOptions();
            options.ViewportSize = new ViewportSize { Width = 1920, Height = 1080};
            options.AcceptDownloads = true;
            // Creates a new page instance
            return await (await browser).NewPageAsync(options);
        }
    }
}
