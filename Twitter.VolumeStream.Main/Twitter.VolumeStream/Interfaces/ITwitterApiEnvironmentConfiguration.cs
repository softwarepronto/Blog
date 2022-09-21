// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Interfaces
{
    public interface ITwitterApiEnvironmentConfiguration
    {
        string BearerTokenName { get; }

        string BearerToken { get; }
    }
}
