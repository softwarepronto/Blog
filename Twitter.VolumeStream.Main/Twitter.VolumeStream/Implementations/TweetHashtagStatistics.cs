// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TweetHashtagStatistics : ITweetHashtagStatistics
    {
        private const ushort TopHashtagCount = 10;

        private readonly ILogger<TweetHashtagStatistics> _logger;

        private readonly HashtagStatistics[] _topHashtagStatistics = new HashtagStatistics[TopHashtagCount];

        private string[] _topHashTags = new string[0];

        private ulong _leastMostPopularHashtagCount = 0UL;

        public TweetHashtagStatistics(ILogger<TweetHashtagStatistics> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> TopHashtags
        {
            get
            {
                IEnumerable<string>? currentTopHashtags = null;

                Interlocked.Exchange<IEnumerable<string>?>(ref currentTopHashtags, _topHashTags);

                return currentTopHashtags;
            }
        }

        private bool AttemptUpdate(string hashtag, ulong count)
        {
            foreach (var hashtagStatistics in _topHashtagStatistics)
            {
                if (hashtagStatistics == null)
                {
                    break;
                }

                if (hashtag == hashtagStatistics.Hashtag)
                {
                    if (count < hashtagStatistics.Count)
                    {
                        throw new ArgumentException($"Hasttag ({hashtag}) count ({hashtagStatistics.Count} cannot decrease ({count})");
                    }

                    hashtagStatistics.Update(count);

                    return true;
                }
            }

            return false;
        }

        private void UpadateLeastMostPopularHashtagCount()
        {
            _leastMostPopularHashtagCount = _topHashtagStatistics.Where(hs => hs != null).Min(hs => hs.Count);
        }

        public void Add(string hashtag, ulong count)
        {
            if (count <= _leastMostPopularHashtagCount)
            {
                return;
            }

            if (AttemptUpdate(hashtag, count))
            {
                UpadateLeastMostPopularHashtagCount();

                return;
            }


            if (_topHashTags.Length == TopHashtagCount)
            {

                // for (var i = 0; i < _topHashtagStatistics.Length; i++)
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

                _topHashtagStatistics[_topHashTags.Length] = new HashtagStatistics(hashtag, count);
                for (var i = 0; i < _topHashTags.Length; i++)
                {
                    nextTopHashtags[i] = _topHashTags[i];
                }

                nextTopHashtags[_topHashTags.Length] = hashtag;
                Interlocked.Exchange<string[]>(ref _topHashTags, nextTopHashtags);
                if (_topHashTags.Length == TopHashtagCount)
                {
                    _leastMostPopularHashtagCount = _topHashtagStatistics.Min(hs => hs.Count);
                }
            }
        }
    }
}
