// Licensed to the softwarepronto.com blog under the GNU General Public License.

try
{
    using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(
        services =>
        {
            services.AddTwiterApiServices();
        })
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.AddTwitterApiConfiguration();
        })
        .Build();

    await host.RunAsync();
}

catch (Exception ex)
{
    Console.Error.WriteLine($"{ex}");
}
