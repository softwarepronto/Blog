using System.Reflection.Metadata.Ecma335;
using Twitter.VolumeStream.Interfaces;

namespace Twitter.VolumeStream.Implementations
{
    public class TweetClient : ITweetClient
    {
        private const string twitterTweetsStreamUrlV2 = @"https://api.twitter.com/2/tweets/sample/stream?tweet.fields=entities,created_at";

        private readonly ITwitterApiEnvironmentConfiguration _twitterConfiguration;

        public TweetClient(ITwitterApiEnvironmentConfiguration twitterConfiguration)
        {
            _twitterConfiguration = twitterConfiguration;
        }

        public async Task<ITweetReader> GetAsync()
        {
            var bearerToken = _twitterConfiguration.BearerToken;

            if (bearerToken == null)
            {
                throw new Exception("Twitter API bearer token not set.");
            }

            HttpClientExtensions.Client.AssignBearerToken(bearerToken);

            var response = await HttpClientExtensions.Client.GetAsync(twitterTweetsStreamUrlV2, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            return new TweetReader(await response.Content.ReadAsStreamAsync());
        }      
    }
}
