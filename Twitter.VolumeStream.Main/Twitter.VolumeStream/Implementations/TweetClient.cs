// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetClient : ITweetClient
    {
        private const string TwitterTweetsStreamUrlV2 = @"https://api.twitter.com/2/tweets/sample/stream?tweet.fields=entities,created_at";

        private readonly ILogger<TweetClient> _logger;

        private readonly IServiceProvider _serviceProvider;

        private readonly ITwitterApiEnvironmentConfiguration _twitterApiEnvironmentConfiguration;

        public TweetClient(
                ILogger<TweetClient> logger,
                IServiceProvider serviceProvider,
                ITwitterApiEnvironmentConfiguration twitterApiEnvironmentConfiguration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _twitterApiEnvironmentConfiguration = twitterApiEnvironmentConfiguration;
        }

        public async Task<ITweetReader> GetAsync()
        {
            var bearerToken = _twitterApiEnvironmentConfiguration.BearerToken;

            if (bearerToken == null)
            {
                throw new Exception($"Twitter API bearer token not set.");
            }

            HttpClientExtensions.Client.AssignBearerToken(bearerToken);

            var response = await HttpClientExtensions.Client.GetAsync(TwitterTweetsStreamUrlV2, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            return (ITweetReader)ActivatorUtilities.CreateInstance(
                _serviceProvider,
                typeof(TweetReader),
                await response.Content.ReadAsStreamAsync());
        }
    }
}
