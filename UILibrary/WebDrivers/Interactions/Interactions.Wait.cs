using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace UILibrary.WebDrivers.Interactions
{
    public partial class Interactions
    {

        /// <summary>
        /// Waits for the value attribute of an element to not be empty
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task WaitForNonEmptyValue(string selector, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].WaitForFunctionAsync($"document.querySelector(\"{selector}\").value !== \"\"");
                else
                    await (await _page).Context.Pages[nroPage].WaitForFunctionAsync($"document.querySelector(\"{selector}\").value !== \"\"");
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Waits for the value attribute of an element to be empty
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task WaitForEmptyValue(string selector, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].WaitForFunctionAsync($"document.querySelector(\"{selector}\").value === \"\"");
                else
                    await (await _page).Context.Pages[nroPage].WaitForFunctionAsync($"document.querySelector(\"{selector}\").value === \"\"");
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task ClickAndWaitForPageAsync(string selector, string errorMessage)
        {
            try
            {
                await _page.Result.Context.RunAndWaitForPageAsync(async () =>
                {
                    await (await _page).ClickAsync(selector);
                });
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageTypeOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task<IElementHandle> WaitForSelectorAsync(string selector, string errorMessage, FrameWaitForSelectorOptions pageTypeOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                   return await (await _page).Frames[nroFrame].WaitForSelectorAsync(selector, pageTypeOptions);
                else
                   return await (await _page).Context.Pages[nroPage].MainFrame.WaitForSelectorAsync(selector, pageTypeOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task WaitForTimeoutAsync(float timeout, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].WaitForTimeoutAsync(timeout);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.WaitForTimeoutAsync(timeout);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        

    }
}