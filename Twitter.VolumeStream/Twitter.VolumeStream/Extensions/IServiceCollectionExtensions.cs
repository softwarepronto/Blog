// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddTwitterApiServices(this IServiceCollection services)
        {
            services.AddSingleton<ITwitterApiConfiguration, TwitterApiConfiguration>();
            services.AddTransient<ITweetClient, TweetClient>();
            services.AddTransient<Func<Stream, ITweetReader>>((provider) =>
            {
                return new Func<Stream, ITweetReader>(
                    (stream) => new TweetReader(provider.GetService<ILogger<TweetReader>>()!, stream));
            });
            services.AddTransient<ITweetHashtagsStatistics, TweetHashtagsStatistics>();
            services.AddTransient<ITweetStatistician, TweetStatistician>();
            services.AddSingleton<ITweetStatistics, TweetStatistics>();
            services.AddTransient<ITweetStatisticsReporter, TweetStatisticsReporter>();
            services.AddHostedService<TweetStatisticianWorker>();
            services.AddHostedService<TweetStatisticsReporterWorker>();
        }

        public static void AddTwitterApiLogging(this IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
        }
    }
}
