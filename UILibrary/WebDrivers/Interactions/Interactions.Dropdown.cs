using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace UILibrary.WebDrivers.Interactions
{
    public partial class Interactions
    {
        /// <summary>
        /// Selects the option from a select element by its value
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="value"></param>
        /// <param name="pageSelectOptionOptions"></param>
        /// <returns></returns>
        public async Task SelectDropdownOptionAsync(string selector, string value, string errorMessage, PageSelectOptionOptions pageSelectOptionOptions = null)
        {
            try
            {
                await (await _page).SelectOptionAsync(selector, new SelectOptionValue { Value = value }, pageSelectOptionOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Selects the option from a select element by its index
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="index"></param>
        /// <param name="pageSelectOptionOptions"></param>
        /// <returns></returns>
        public async Task SelectDropdownOptionAsync(string selector, int index, string errorMessage, PageSelectOptionOptions pageSelectOptionOptions = null)
        {
            try
            {
                await (await _page).SelectOptionAsync(selector, new SelectOptionValue { Index = index }, pageSelectOptionOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

    }
}