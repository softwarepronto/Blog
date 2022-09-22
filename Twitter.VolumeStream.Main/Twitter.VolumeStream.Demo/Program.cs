// Licensed to the softwarepronto.com blog under the GNU General Public License.

try
{
    using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(
        services =>
        {
            services.AddSingleton<ITwitterApiEnvironmentConfiguration, TwitterApiEnvironmentConfiguration>();
            services.AddTransient<ITweetClient, TweetClient>();
            services.AddTransient<ITweetReader, TweetReader>();
            services.AddTransient<ITweetStatistician, TweetStatistician>();
            services.AddTransient<ITweetStatistics, TweetStatistics>();
            services.AddHostedService<TweetStatisticianWorker>();
        })
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.AddTwitterApiEnvironmentConfiguration();
        })
        .Build();

    await host.RunAsync();
}

catch (Exception ex)
{
    Console.Error.WriteLine($"{ex}");
}
