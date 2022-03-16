using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UILibrary.WebDrivers
{
    public interface IBrowserDriver
    {
        Task<IBrowser> Current { get; }
    }
}