using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using static System.Environment;

namespace SoftwarePronto.Azure.Utility.Master
{
    /*
     * https://github.com/projectkudu/kudu/wiki/Azure-runtime-environment
     * WEBSITE_SITE_NAME - The name of the site.
     * WEBSITE_SKU - The sku of the site 
     *   (Possible values: Free, Shared, Basic, Standard).
     * WEBSITE_COMPUTE_MODE - Specifies whether website is on a dedicated or 
     *   shared VM/s (Possible values: Shared, Dedicated).
     * WEBSITE_HOSTNAME - The Azure Website's primary host name for the site 
     *   (For example: site.azurewebsites.net). Note that custom hostnames are 
     *   not accounted for here.
     * WEBSITE_INSTANCE_ID - The id representing the VM that the site is running 
     *   on (If site runs on multiple instances, each instance 
     *   will have a different id).
     * WEBSITE_NODE_DEFAULT_VERSION - The default node version this 
     *   website is using.
     * WEBSOCKET_CONCURRENT_REQUEST_LIMIT - The limit for websocket's 
     *   concurrent requests.
     */
    public static class WebAppEnviroment
    {
        public static string _envNameWEBSITE_SITE_NAME = "WEBSITE_SITE_NAME";

        public static string _envNameWEBSITE_SKU = "WEBSITE_SKU";

        public static string _envNameWEBSITE_COMPUTE_MODE = "WEBSITE_COMPUTE_MODE";

        public static string _envNameWEBSITE_INSTANCE_ID = "WEBSITE_INSTANCE_ID";

        public static string _envNameWEBSITE_NODE_DEFAULT_VERSION = "WEBSITE_NODE_DEFAULT_VERSION";

        public static string _envNameWEBSOCKET_CONCURRENT_REQUEST_LIMIT = "WEBSOCKET_CONCURRENT_REQUEST_LIMIT";

        public static string WebSiteName =>
            GetEnvironmentVariable(_envNameWEBSITE_SITE_NAME);

        public static string WebSKU =>
            GetEnvironmentVariable(_envNameWEBSITE_SKU);

        public static string WebSitComputeMode =>
            GetEnvironmentVariable(_envNameWEBSITE_COMPUTE_MODE);

        public static string WebSiteInstanceId =>
            GetEnvironmentVariable(_envNameWEBSITE_INSTANCE_ID);

        public static string WebSiteNodeDefaultVersion =>
            GetEnvironmentVariable(_envNameWEBSITE_NODE_DEFAULT_VERSION);

        public static string WebSiteSocketConcurrentRequestLimit =>
            GetEnvironmentVariable(_envNameWEBSOCKET_CONCURRENT_REQUEST_LIMIT);

        public static Dictionary<string, string> Get() =>
            new Dictionary<string, string>
            {
                [_envNameWEBSITE_SITE_NAME] = WebSiteName,
                [_envNameWEBSITE_SKU] = WebSKU,
                [_envNameWEBSITE_COMPUTE_MODE] = WebSitComputeMode,
                [_envNameWEBSITE_INSTANCE_ID] = WebSitComputeMode,
                [_envNameWEBSITE_NODE_DEFAULT_VERSION] = WebSiteNodeDefaultVersion,
                [_envNameWEBSOCKET_CONCURRENT_REQUEST_LIMIT] = WebSiteSocketConcurrentRequestLimit
            };

        public static string GetAsText()
        {
            StringBuilder result = new StringBuilder();

            Get().ToList().ForEach(wsv =>
                result.AppendLine($"{wsv.Key}: {wsv.Value ?? String.Empty}"));

            return result.ToString();
        }
    }
}
