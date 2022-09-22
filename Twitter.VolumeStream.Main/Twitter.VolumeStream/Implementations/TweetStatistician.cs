// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetStatistician : ITweetStatistician
    {
        private readonly ILogger<TweetStatistician> _logger;

        private readonly ITweetClient _tweetClient;

        public TweetStatistician(ILogger<TweetStatistician> logger, ITweetClient tweetClient)
        {
            _logger = logger;
            _tweetClient = tweetClient;
        }

        public async Task GenerateAsync(CancellationToken stoppingToken)
        {
            var hashtags = new StringBuilder();
            using var tweetReader = await _tweetClient.GetAsync();

            while (!(stoppingToken.IsCancellationRequested))
            {
                var tweetJson = await tweetReader.ReadLineAsync();

                if (string.IsNullOrEmpty(tweetJson))
                {
                    continue;
                }

                if (tweetJson.Contains("\"hashtags\":"))
                {
                    var root = JsonSerializer.Deserialize<Root>((string)tweetJson);

                    if (root == null)
                    {
                        continue; // warning
                    }

                    hashtags.Clear();
                    foreach (var hashtag in root.data.entities.hashtags)
                    {
                        if (hashtags.Length > 0)
                        {
                            hashtags.Append(" ");
                        }

                        hashtags.Append(hashtag.tag);
                    }
                }
            }

        }
    }
}
