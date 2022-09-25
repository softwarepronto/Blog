// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.Implementations
{
    public class TweetStatisticsReporterTests
    {
        private readonly Mock<ILogger<TweetStatisticsReporter>> _loggerTweetStatisticsReporterMock =
                                new Mock<ILogger<TweetStatisticsReporter>>();

        const string StartTotalTweetsMarker = ": ";

        const string EndTotalTweetsMarker = ",";

        const string StartHashtagsCountMarker = "Top ";

        const string EndHashtagsCountMarker = " hashtags";

        private static ulong GetNumber(string reportText, string startMarker, string endMarker)
        {
            var startIndex = reportText.IndexOf(startMarker) + startMarker.Length;
            var length = reportText.IndexOf(endMarker) - startIndex;
            var numberCandidateText = reportText.Substring(startIndex, length);

            return ulong.Parse(numberCandidateText);
        }

        private static ulong GetTotalTweets(string reportText)
        {
            return GetNumber(reportText, StartTotalTweetsMarker, EndTotalTweetsMarker);
        }

        private static ulong GetHashtagCounts(string reportText)
        {
            return GetNumber(reportText, StartHashtagsCountMarker, EndHashtagsCountMarker);
        }

        [Fact]
        public void GetReportTextTest()
        {
            var tweetStatisticsMock = new Mock<ITweetStatistics>();
            var totalTweels = 0ul;
            var hashtags = new string[0];

            tweetStatisticsMock.SetupGet(m => m.TotalTweets).Returns(totalTweels);
            tweetStatisticsMock.SetupGet(m => m.TopHashtags).Returns(hashtags);

            var tweetStatisticsReporter = new TweetStatisticsReporter(
                                                _loggerTweetStatisticsReporterMock.Object,
                                                tweetStatisticsMock.Object);
            var reportText = tweetStatisticsReporter.GetReportText();

            Assert.Equal(totalTweels, GetTotalTweets(reportText));
            Assert.Equal((ulong)hashtags.Length, GetHashtagCounts(reportText));
            foreach (var hashtag in hashtags)
            {
                Assert.True(reportText.Contains(hashtag));
            }
        }
    }
}
