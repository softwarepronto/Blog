﻿// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.Models
{
    public class HasttagStatsTests
    {
        private const ulong IncrementTestCountMax = 10;

        [Fact]
        public void AllTest()
        {

            var hasttags = new string[] { "a", "123", "phoenixentertainment" };

            foreach (var hashtag in hasttags)
            {
                var hashtagStats = new HashtagStatistics(hashtag);

                for (var i = 1ul; i <= IncrementTestCountMax; i++)
                {
                    Assert.Equal(hashtagStats.Hashtag, hashtag);
                    Assert.Equal(hashtagStats.Count, i);
                    hashtagStats.Increment();
                }

                Assert.Equal(hashtag, hashtagStats.Hashtag);
                Assert.Equal(IncrementTestCountMax, hashtagStats.Count + 1ul);
            }
        }
    }
}
