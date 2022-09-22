// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddTwiterApiServices(this IServiceCollection services)
        {
            services.AddSingleton<ITwitterApiEnvironmentConfiguration, TwitterApiEnvironmentConfiguration>();
            services.AddTransient<ITweetClient, TweetClient>();
            services.AddTransient<ITweetReader, TweetReader>();
            services.AddTransient<ITopHashtagStatistics, TopHashtagStatistics>();
            services.AddTransient<ITweetStatistician, TweetStatistician>();
            services.AddTransient<ITweetStatistics, TweetStatistics>();
            services.AddHostedService<TweetStatisticianWorker>();
        }
    }
}
