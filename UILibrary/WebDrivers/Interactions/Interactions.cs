using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UILibrary.WebDrivers.Interactions
{
    public partial class Interactions
    {
        private readonly Task<IPage> _page;

        public Interactions(Task<IPage> page)
        {
            _page = page;
        }


        /// <summary>
        /// Sends a string to the specified selector
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keys"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageFillOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task SendTextAsync(string selector, string keys, string errorMessage, FrameFillOptions pageFillOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].FillAsync(selector, keys, pageFillOptions);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.FillAsync(selector, keys, pageFillOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Sends individual keystrokes to the specified selecto
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="keys"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageTypeOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task SendKeystrokesAsync(string selector, string keys, string errorMessage, FrameTypeOptions pageTypeOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].TypeAsync(selector, keys, pageTypeOptions);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.TypeAsync(selector, keys, pageTypeOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Sends a click to an element
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageClickOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task ClickAsync(string selector, string errorMessage, FrameClickOptions pageClickOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].ClickAsync(selector, pageClickOptions);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.ClickAsync(selector, pageClickOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Sends a double click to an element
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageClickOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task DoubleClickAsync(string selector, string errorMessage, FrameDblClickOptions pageClickOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].DblClickAsync(selector, pageClickOptions);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.DblClickAsync(selector, pageClickOptions);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Gets the value attribute of an element
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageInputValueOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns>string</returns>
        public async Task<string> GetValueAttributeAsync(string selector, string errorMessage, FrameInputValueOptions pageInputValueOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    return await(await _page).Frames[nroFrame].InputValueAsync(selector, pageInputValueOptions);
                else
                    return await(await _page).Context.Pages[nroPage].MainFrame.InputValueAsync(selector, pageInputValueOptions);
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
        /// <param name="visible"></param>
        /// <param name="errorMessage"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsVisibleAsync(string selector, bool visible, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            var result = false;
            if (nroFrame != 0)
                result = await (await _page).Frames[nroFrame].IsVisibleAsync(selector);
            else
                result = await (await _page).Context.Pages[nroPage].MainFrame.IsVisibleAsync(selector);
            if(result != visible && !string.IsNullOrEmpty(errorMessage))
                throw new Exception(errorMessage + result);
            return result == visible;
        }

        /// <summary>
        /// Gets all elements by a given selector
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns>IReadOnlyList<IElementHandle></returns>
        public async Task<IReadOnlyList<IElementHandle>> QuerySelectorAllAsync(string selector, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    return await(await _page).Frames[nroFrame].QuerySelectorAllAsync(selector);
                else
                    return await(await _page).Context.Pages[nroPage].MainFrame.QuerySelectorAllAsync(selector);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Press a keyboard key in a selector
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task PressAsync(string selector, string key, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    await (await _page).Frames[nroFrame].PressAsync(selector, key);
                else
                    await (await _page).Context.Pages[nroPage].MainFrame.PressAsync(selector, key);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Sends a click to an element
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="pageClickOptions"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns></returns>
        public async Task<string> WaitForDownloadAsync(string selector, string path, string errorMessage, FrameClickOptions pageClickOptions = null, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                {
                    await (await _page).Frames[nroFrame].ClickAsync(selector, pageClickOptions);
                    var waitForDownloadTask = (await _page).WaitForDownloadAsync();
                    var download = await waitForDownloadTask;
                    await download.SaveAsAsync(string.Format(path, download.SuggestedFilename));
                    await download.DeleteAsync();
                    return download.SuggestedFilename;
                }
                else
                {
                    await (await _page).Context.Pages[nroPage].MainFrame.ClickAsync(selector, pageClickOptions);
                    var waitForDownloadTask = (await _page).WaitForDownloadAsync();
                    var download = await waitForDownloadTask;
                    await download.SaveAsAsync(string.Format(path, download.SuggestedFilename));
                    await download.DeleteAsync();
                    return download.SuggestedFilename;
                }
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }

        /// <summary>
        /// Gets element of given selector
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="errorMessage"></param>
        /// <param name="nroFrame"></param>
        /// <param name="nroPage"></param>
        /// <returns>IReadOnlyList<IElementHandle></returns>
        public async Task<IElementHandle> QuerySelectorAsync(string selector, string errorMessage, int nroFrame = 0, int nroPage = 0)
        {
            try
            {
                if (nroFrame != 0)
                    return await (await _page).Frames[nroFrame].QuerySelectorAsync(selector);
                else
                    return await (await _page).Context.Pages[nroPage].MainFrame.QuerySelectorAsync(selector);
            }
            catch (Exception e)
            {
                throw new Exception(errorMessage + e.Message);
            }
        }
    }
}