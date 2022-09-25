// Licensed to the softwarepronto.com blog under the GNU General Public License.

try
{
    using var host = Host.CreateDefaultBuilder(args).ConfigureServices(
        services =>
        {
            services.AddTwitterApiServices();
            services.AddTwitterApiLogging();
        })
        .ConfigureHostConfiguration(configurationHost =>
        {
            configurationHost.AddTwitterApiHostConfiguration();
        })
        .ConfigureAppConfiguration((hostingContext, configurationApp) =>
        {
            hostingContext.AddTwitterApiAppConfiguration(configurationApp);
        })
        .Build();

    await host.RunAsync();
}

catch (Exception ex)
{
    Console.WriteLine($"{ex}");
}
