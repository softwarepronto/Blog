namespace Twitter.VolumeStream.Tests.TestUtilities
{
    public class TweetArchiveWriter
    {
        private string[] tweets;

        private ushort count = 0;

        public TweetArchiveWriter(ushort maxNumberOfTweets)
        {
            MaxNumberOfTweets = maxNumberOfTweets;
            tweets = new string[MaxNumberOfTweets];
        }

        public ushort MaxNumberOfTweets { get; }

        public void Add(string tweet)
        {
            tweets[count] = tweet;
            count++;
            if (MaxNumberOfTweets == count)
            {
                var filename = $"Tweets{DateTime.UtcNow.ToString("yyyyMMddhhmmss")}";
                var filePath = Path.Combine(@"C:\Temp", filename);

                File.WriteAllLines(filePath, tweets);
                count = 0;
            }
        }
    }
}
