namespace Twitter.VolumeStream.Implementations
{

    public class TweetStatistics : ITweetStatistics
    {
        private readonly ITweetClient _tweetClient;

        public TweetStatistics(ITweetClient tweetClient)
        {
            _tweetClient = tweetClient;
        }

        public async Task GenerateAsync()
        {
            var hashtags = new StringBuilder();
            using var tweetReader = await _tweetClient.GetAsync();
            
            for (var count = 0; count < 50; count++)
            {
                var tweetJson = await tweetReader.ReadLineAsync();

                if (string.IsNullOrEmpty(tweetJson))
                {
                    continue;
                }

                if (tweetJson.Contains("\"hashtags\":"))
                {
                    var root = JsonSerializer.Deserialize<Root>((string)tweetJson);

                    if (root == null)
                    {
                        continue; // warning
                    }

                    hashtags.Clear();
                    foreach (var hashtag in root.data.entities.hashtags)
                    {
                        if (hashtags.Length > 0)
                        {
                            hashtags.Append(" ");
                        }

                        hashtags.Append(hashtag.tag);
                    }

                    Console.WriteLine($"{count}: {hashtags}");
                }
            }

        }
    }
}
