using System;
using System.Threading.Tasks;

namespace UILibrary.WebDrivers.Interactions
{
    public partial class Interactions
    {
        /// <summary>
        /// Navigates to the specified URL
        /// </summary>
        /// <param name="url"></param>
        public async Task GoToUrl(string url, string errorMessage)
        {
            var result = (await (await _page).GotoAsync(url)).Url;
            if (!result.Contains(url))
                throw new Exception(string.Format(errorMessage, url, result));

        }

    }
}