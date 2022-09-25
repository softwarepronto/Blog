﻿// Licensed to the softwarepronto.com blog under the GNU General Public License.

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
            var totalTweets = 0ul;
            var hashtags = new List<string>();
            var hashtagCandidates = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            const int hashTagLength = 12;

            tweetStatisticsMock.SetupGet(m => m.TotalTweets).Returns(() => { return totalTweets; });
            tweetStatisticsMock.SetupGet(m => m.TopHashtags).Returns(hashtags);

            var tweetStatisticsReporter = new TweetStatisticsReporter(
                                                _loggerTweetStatisticsReporterMock.Object,
                                                tweetStatisticsMock.Object);
            var reportText = tweetStatisticsReporter.GetReportText();

            Assert.Equal(totalTweets, GetTotalTweets(reportText));
            Assert.Equal((ulong)hashtags.Count, GetHashtagCounts(reportText));
            foreach (var hashtag in hashtags)
            {
                Assert.Contains(hashtag, reportText);
            }

            foreach (var hashtagCandidate in hashtagCandidates)
            {
                totalTweets += 5ul;
                hashtags.Add(new string(hashtagCandidate, hashTagLength));
                reportText = tweetStatisticsReporter.GetReportText();
                Assert.Equal(totalTweets, GetTotalTweets(reportText));
                Assert.Equal((ulong)hashtags.Count, GetHashtagCounts(reportText));
                foreach (var hashtag in hashtags)
                {
                    Assert.Contains(hashtag, reportText);
                }
            }
        }
    }
}