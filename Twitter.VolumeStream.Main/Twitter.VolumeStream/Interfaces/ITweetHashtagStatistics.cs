// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Interfaces
{
    public interface ITweetHashtagStatistics
    {
        IEnumerable<string> TopHashtags { get; }

        void Add(string hashtag, ulong count);
    }
}
