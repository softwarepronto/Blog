var twitterBearerTokenEnvVariableName = "APP_ACCESS_TOKEN";
var twitterTweetsStreamUrlV2 = @"https://api.twitter.com/2/tweets/sample/stream?tweet.fields=entities,created_at";

try
{
    var httpClient = new HttpClient();
    var bearerToken = Environment.GetEnvironmentVariable(twitterBearerTokenEnvVariableName);

    if (bearerToken == null)
    {
        throw new Exception(
                    $"Twitter bearer token environment variable ({twitterBearerTokenEnvVariableName}) not set.");
    }


    httpClient.DefaultRequestHeaders.Authorization =
       new AuthenticationHeaderValue("Bearer", bearerToken);

    var response = await httpClient.GetAsync(twitterTweetsStreamUrlV2, HttpCompletionOption.ResponseHeadersRead);

    response.EnsureSuccessStatusCode();
    
    using var stream = response.Content.ReadAsStream();
    using var reader = new StreamReader(stream);

    var hashtags = new StringBuilder();
    var tweetsPerArchive = (ushort)10000;
    var numberOfTweets = (ulong)10 * tweetsPerArchive;
    var tweetArchive = new TweatArchive(tweetsPerArchive);


    for (var count = 0; count < 50; count++)
    {
        var tweetJson = reader.ReadLine();

        if (string.IsNullOrEmpty(tweetJson))
        {
            continue;
        }

        if (tweetJson.Contains("\"hashtags\":"))
        {
            var root = JsonSerializer.Deserialize<Root>(tweetJson);

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

            Console.WriteLine(hashtags);
        }

        tweetArchive.Add(tweetJson);
    }
}

catch (Exception ex)
{
    Console.Error.WriteLine($"{ex}");
}

