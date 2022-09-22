// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetStatistics : ITweetStatistics
    {
        private ushort TopHashtagCount = 10;

        private ulong _totalTweets = 0UL;

        private ulong _leastMostPopularHashtagCount = 0UL;

        private readonly Dictionary<string, ulong> _hashTagCounts = new Dictionary<string, ulong>();

        private readonly Dictionary<string, ulong> _topHashTags = new Dictionary<string, ulong>();

        public ulong TotalTweets => _totalTweets;

        public IEnumerable<string> TopHashtags => throw new NotImplementedException();

        public void Add()
        {
            Interlocked.Increment(ref _totalTweets);
        }

        public void Add(string[] hashtags)
        {
            var currentHashtagCount = 0UL;

            Add();
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

                if (currentHashtagCount > _leastMostPopularHashtagCount)
                {

                }
            }
        }
    }
}
