using Microsoft.Extensions.Configuration;

namespace UILibrary.WebDrivers
{
    public interface IPlaywrightConfiguration
    {
        Browser Browser { get; }

        string[] Arguments { get; }

        float? DefaultTimeout { get; }

        bool? Headless { get; }
    }

    public class PlaywrightConfiguration : IPlaywrightConfiguration
    {
        private readonly IConfiguration _jsonLoader;
        
        /// <summary>
        /// Provides the configuration details for the webdriver instance
        /// </summary>
        /// <param name="jsonLoader"></param>
        public PlaywrightConfiguration(IConfiguration jsonLoader)
        {
            _jsonLoader = jsonLoader;
        }

        /// <summary>
        /// The browser specified in the configuration
        /// </summary>
        public Browser Browser => _jsonLoader.GetValue<Browser>("playwright:browser"); 

        /// <summary>
        /// Arguments used to configure the webdriver
        /// </summary>
        public string[] Arguments => _jsonLoader.GetValue<string[]>("playwright:arguments");

        /// <summary>
        /// The default timeout used to configure the webdriver
        /// </summary>
        public float? DefaultTimeout => _jsonLoader.GetValue<float?>("playwright:defaultTimeout");

        /// <summary>
        /// The default timeout used to configure the webdriver
        /// </summary>
        public bool? Headless => _jsonLoader.GetValue<bool?>("playwright:headless");
    }
}