namespace Twitter.VolumeStream.Tests.TestUtilities
{
    public class TweatArchive
    {
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }

        public string TweetArchiveFolderName = "TweetArchive";

        public string TweetArchiveFolderPath => Path.Combine(AssemblyDirectory, TweetArchiveFolderName);
    }
}
