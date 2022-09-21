// Licensed to the softwarepronto.com blog under the GNU General Public License.

using Twitter.VolumeStream.Implementations;

namespace Twitter.VolumeStream.Extensions
{
    public static class IConfigurationBuilderExtensions
    {
        public static void AddTwitterApiEnvironmentConfiguration(this IConfigurationBuilder configHost)
        {
            configHost.AddEnvironmentVariables(prefix: TwitterApiEnvironmentConfiguration.Prefix);
        }
    }
}
