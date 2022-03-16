using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using UILibrary.PageObjects.CXone.Login;
using Utilities.Clusters;

namespace UILibrary.WebDrivers
{
    public class Config
    {
        public static LoginPage Init()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IPlaywrightConfiguration, PlaywrightConfiguration > ();
                    services.AddTransient<IDriverInitialiser, DriverInitialiser> ();
                    services.AddTransient<IBrowserDriver, BrowserDriver> ();
                    services.AddTransient<LoginPage> ();
                })
                .Build();            
            return ActivatorUtilities.CreateInstance<LoginPage>(host.Services);
        }
        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
