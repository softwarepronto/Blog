namespace Twitter.Stream.Demo
{
    public class TweatArchive
    {
        private string[] tweets;

        private ushort count = 0;

        public TweatArchive(ushort numberOfTweets)
        {
            NumberOfTweets = numberOfTweets;
            tweets = new string[NumberOfTweets];
        }

        public ushort NumberOfTweets { get; } 


        public void Add(string tweet)
        {
            tweets[count] = tweet;
            count++;
            if (NumberOfTweets == count)
            {
                var filename = $"Tweets{DateTime.UtcNow.ToString("yyyyMMddhhmmss")}";
                var filePath = Path.Combine(@"C:\Temp", filename);

                File.WriteAllLines(filePath, tweets);
                count = 0;
            }
        }
    }
}
