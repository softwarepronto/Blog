// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.Implementations
{
    public class TweetHashtagStatisticsTests
    {
        private readonly Mock<ILogger<TweetHashtagStatistics>> _loggerTweetHashtagStatistics =
                                new Mock<ILogger<TweetHashtagStatistics>>();

        [Fact]
        public void AddOneTweetTest()
        {
            const int MaxNumberOfHashtagInstances = 50;
            var hashtag = "buddy_holly";
            var tweetHashtagStatistics =
                        new TweetHashtagStatistics(_loggerTweetHashtagStatistics.Object);

            Assert.Empty(tweetHashtagStatistics.TopHashtags);
            for (var count = 1; count <= MaxNumberOfHashtagInstances; count++)
            {
                tweetHashtagStatistics.Add(hashtag, (ulong)count);
                Assert.Contains(hashtag, tweetHashtagStatistics.TopHashtags);
            }
        }

        [Fact]
        public void AddTenTweetsTest()
        {
            const int MaxNumberOfHashtagInstances = 50;
            var hashtags = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            var tweetHashtagStatistics =
                        new TweetHashtagStatistics(_loggerTweetHashtagStatistics.Object);

            Assert.Empty(tweetHashtagStatistics.TopHashtags);
            for (var count = 1; count <= MaxNumberOfHashtagInstances; count++)
            {
                foreach (var hashtag in hashtags)
                {
                    tweetHashtagStatistics.Add(hashtag, (ulong)count);
                    Assert.Contains(hashtag, tweetHashtagStatistics.TopHashtags);
                }
            }

            var bumpHashtag = "k";

            for (var count = 1; count <= (2 * MaxNumberOfHashtagInstances); count++)
            {
                if (count == (MaxNumberOfHashtagInstances + 1))
                {
                    Assert.DoesNotContain(bumpHashtag, tweetHashtagStatistics.TopHashtags);
                }

                tweetHashtagStatistics.Add(bumpHashtag, (ulong)count);
                if (count > MaxNumberOfHashtagInstances)
                {
                    Assert.Contains(bumpHashtag, tweetHashtagStatistics.TopHashtags);
                }

                else
                {
                    Assert.DoesNotContain(bumpHashtag, tweetHashtagStatistics.TopHashtags);
                }
            }
        }
    }
}
