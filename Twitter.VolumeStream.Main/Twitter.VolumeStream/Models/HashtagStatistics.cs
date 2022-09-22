// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Models
{
    // jdn more tests -- how many construtors do you need
    public class HashtagStatistics
    {
        private ulong _count;

        public HashtagStatistics(string hashtag)
        {
            Hashtag = hashtag;
            _count = 1;
        }

        public HashtagStatistics(string hashtag, ulong count)
        {
            Hashtag = hashtag;
            _count = count;
        }

        public void Overwrite(string hashtag, ulong count)
        {
            Hashtag = hashtag;
            _count = count;
        }

        public string Hashtag { get; private set; }

        public ulong Count => _count;

        public void Increment()
        {
            Interlocked.Increment(ref _count);
        }
    }
}
