// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Implementations
{
    public class TwitterApiEnvironmentConfiguration : ITwitterApiEnvironmentConfiguration
    {
        public const string Prefix = "TWITTER_API_";

        private readonly ILogger<TwitterApiEnvironmentConfiguration> _logger;

        public string BearerTokenName => Prefix + "BEARER_TOKEN";

        private readonly IConfiguration _configuration;

        public TwitterApiEnvironmentConfiguration(
                    ILogger<TwitterApiEnvironmentConfiguration> logger,
                    IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string BearerToken => _configuration.GetValue<string>(BearerTokenName);
    }
}
