// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetStatistics : ITweetStatistics
    {
        private ulong _totalTweets = 0UL;

        private readonly Dictionary<string, ulong> _hashTagCounts = new Dictionary<string, ulong>();

        private readonly TweetHashtagStatistics _topHashtagStatistics;

        private readonly Logger<TweetStatistics> _logger;

        public TweetStatistics(Logger<TweetStatistics> logger, IServiceProvider services)
        {
            _logger = logger;
            _topHashtagStatistics = services.GetRequiredService<TweetHashtagStatistics>();
        }

        public ulong TotalTweets
        {
            get
            {
                return Interlocked.Read(ref _totalTweets);
            }
        }

        public IEnumerable<string> TopHashtags => _topHashtagStatistics.TopHashtags;

        public void Increment()
        {
            Interlocked.Increment(ref _totalTweets);
        }

        public void Increment(string[] hashtags)
        {
            var currentHashtagCount = 0UL;

            Increment();
            foreach (var hashtag in hashtags)
            {
                if (_hashTagCounts.ContainsKey(hashtag))
                {
                    currentHashtagCount = ++_hashTagCounts[hashtag];
                }

                else
                {
                    _hashTagCounts.Add(hashtag, 1);
                    currentHashtagCount = 1;
                }

                _topHashtagStatistics.Add(hashtag, currentHashtagCount);
            }
        }
    }
}
