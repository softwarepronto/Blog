// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TopHashtagStatistics
    {
        private const ushort TopHashtagCount = 10;

        private readonly HashtagStatistics[] _topHashTagStatistics = new HashtagStatistics[TopHashtagCount];

        private string[] _topHashTags = new string[0];

        private ulong _leastMostPopularHashtagCount = 0UL;

        public IEnumerable<string> TopHashtags
        {
            get
            {
                IEnumerable<string>? currentTopHashtags = null;

                Interlocked.Exchange<IEnumerable<string>?>(ref currentTopHashtags, _topHashTags);

                return currentTopHashtags;
            }
        }

        public void Add(string hashtag, ulong count)
        {
            if (count <= _leastMostPopularHashtagCount)
            {
                return;
            }

            if (_topHashTags.Length == TopHashtagCount)
            {
                // for (var i = 0; i < _topHashTagStatistics.Length; i++)
                // {
                //    if (topHashTagStatistics.Count < count)
                //    {
                //        // could overwrite yourself or someone else and have two of the same
                //        topHashTagStatistics.Overwrite();
                //    }
                //}
            }

            else // Initiaizing (_topHashTags.Length < TopHashtagCount)
            {
                var nextTopHashtags = new string[_topHashTags.Length + 1];

                _topHashTagStatistics[_topHashTags.Length] = new HashtagStatistics(hashtag, count);
                for (var i = 0; i < _topHashTags.Length; i++)
                {
                    nextTopHashtags[i] = _topHashTags[i];
                }

                nextTopHashtags[_topHashTags.Length] = hashtag;
                Interlocked.Exchange<string[]>(ref _topHashTags, nextTopHashtags);
                if (_topHashTags.Length == TopHashtagCount)
                {
                    _leastMostPopularHashtagCount = _topHashTagStatistics.Min(hs => hs.Count);
                }
            }
        }
    }
}
