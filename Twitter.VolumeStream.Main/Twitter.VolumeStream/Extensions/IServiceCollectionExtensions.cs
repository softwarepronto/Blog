// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddTwitterApiServices(this IServiceCollection services)
        {
            services.AddSingleton<ITwitterApiEnvironmentConfiguration, TwitterApiEnvironmentConfiguration>();
            services.AddTransient<ITweetClient, TweetClient>();
            services.AddTransient<ITweetReader, TweetReader>();
            services.AddTransient<ITweetHashtagStatistics, TweetHashtagStatistics>();
            services.AddTransient<ITweetStatistician, TweetStatistician>();
            services.AddTransient<ITweetStatistics, TweetStatistics>();
            services.AddHostedService<TweetStatisticianWorker>();
        }

        public static void AddTwitterApiLogging(this IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
        }

    }
}
