﻿// Licensed to the softwarepronto.com blog under the GNU General Public License.

namespace Twitter.VolumeStream.Tests.TestUtilities
{
    public class TweatArchive
    {
        public const string TweetArchiveFolderName = "TweetArchive";

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().Location;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }

        public string TweetArchiveFolderPath => Path.Combine(AssemblyDirectory, TweetArchiveFolderName);
    }
}