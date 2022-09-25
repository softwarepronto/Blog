// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.Implementations
{
    public class TweetStatisticsReporterTests
    {
        private readonly Mock<ILogger<TweetStatisticsReporter>> _loggerTweetStatisticsReporterMock =
                                new Mock<ILogger<TweetStatisticsReporter>>();

        [Fact]
        public void GetReportTextTest()
        {
            var tweetStatisticsMock = new Mock<ITweetStatistics>();
            var totalTweels = 0ul;

            // input.SetupGet(x => x.ColumnNames).Returns(temp);
            tweetStatisticsMock.SetupGet(m => m.TotalTweets).Returns(totalTweels);

            var tweetStatisticsReporter = new TweetStatisticsReporter(
                                                _loggerTweetStatisticsReporterMock.Object, 
                                                tweetStatisticsMock.Object);
        }
    }
}
