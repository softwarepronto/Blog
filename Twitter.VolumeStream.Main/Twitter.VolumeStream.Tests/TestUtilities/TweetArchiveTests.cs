// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.TestUtilities
{
    public class TweetArchiveTests
    {
        [Fact]
        public async void ReaadTest()
        {
            var tweetArchiveReader = new TweetArchiveReader();

            while (true)
            {
                var tweetJson = await tweetArchiveReader.ReadLineAsync();

                Console.WriteLine(tweetJson);
            }
        }
    }
}
