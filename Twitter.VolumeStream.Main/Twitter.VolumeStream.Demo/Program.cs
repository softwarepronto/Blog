// Licensed to the softwarepronto.com blog under the GNU General Public License.

try
{
    using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(
        services =>
        {
            services.AddSingleton<ITwitterApiEnvironmentConfiguration, TwitterApiEnvironmentConfiguration>();
            services.AddTransient<ITweetClient, TweetClient>();
            services.AddTransient<ITweetReader, TweetReader>();
            services.AddTransient<ITweetStatistics, TweetStatistics>();
        })
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.AddTwitterApiEnvironmentConfiguration();
        })
        .Build();

    var tweetStatistics = host.Services.GetService<ITweetStatistics>();

    await tweetStatistics.GenerateAsync();
    await host.RunAsync();
}

catch (Exception ex)
{
    Console.Error.WriteLine($"{ex}");
}

return;
