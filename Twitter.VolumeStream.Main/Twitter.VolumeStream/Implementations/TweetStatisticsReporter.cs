// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetStatisticsReporter : ITweetStatisticsReporter
    {
        private readonly ILogger<ITweetStatisticsReporter> _logger;

        private readonly ITweetStatistics _tweetStatistics;

        public TweetStatisticsReporter(
                    ILogger<ITweetStatisticsReporter> logger,
                    ITweetStatistics tweetStatistics)
        {
            _logger = logger;
            _tweetStatistics = tweetStatistics;
        }

        public string GetReportText()
        {
            var hashtagsText = string.Join(",", _tweetStatistics.TopHashtags);

            return $"Total tweets: {_tweetStatistics.TotalTweets}, " +
                   $"Top {_tweetStatistics.TopHashtags.Count()} hashtags {hashtagsText}";
        }

        public void Report()
        {
            _logger.LogInformation("Tweet statitics reported");


            Console.WriteLine(GetReportText());
        }
    }
}
