using Microsoft.Playwright;
using System.Threading.Tasks;
using Utilities.Factories;

namespace UILibrary.PageObjects.CXone.Menus
{
    public class Home : BasePage
    {
        #region Variables

        public AppPicker AppPicker { get; set; }
        public NavMenu NavMenu { get; set; }
        public AdminSidebar AdminSidebar { get; set; }
        public ACDSidebar ACDSidebar { get; set; }
        public ReportingSidebar ReportingSidebar { get; set; }

        #endregion

        public Home(Task<IPage> page) : base(page)
        {
            AppPicker           = PageFactory.GetPage<AppPicker>(page);
            NavMenu             = PageFactory.GetPage<NavMenu>(page);
            AdminSidebar        = PageFactory.GetPage<AdminSidebar>(page);
            ACDSidebar          = PageFactory.GetPage<ACDSidebar>(page);
            ReportingSidebar    = PageFactory.GetPage<ReportingSidebar>(page);
        }
       
    }
}
