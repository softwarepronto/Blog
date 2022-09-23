// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.Implementations
{
    public class TweetHashtagStatisticsTests
    {
        private readonly Mock<ILogger<TweetHashtagStatistics>> _loggerTweetHashtagStatistics =
                                new Mock<ILogger<TweetHashtagStatistics>>();

        [Fact]
        public void AddOneTweet()
        {
            const int MaxNumberOfHashtagInstances = 50;
            var hashtag = "buddy_holly";
            var tweetHashtagStatistics =
                        new TweetHashtagStatistics(_loggerTweetHashtagStatistics.Object);

            Assert.Empty(tweetHashtagStatistics.TopHashtags);
            for (var count = 1; count <= MaxNumberOfHashtagInstances; count++)
            {
                tweetHashtagStatistics.Add(hashtag, (ulong)count);
                Assert.True(tweetHashtagStatistics.TopHashtags.Contains(hashtag));
            }
        }

    }
}
