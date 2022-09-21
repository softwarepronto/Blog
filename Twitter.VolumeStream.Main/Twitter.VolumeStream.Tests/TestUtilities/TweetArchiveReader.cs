namespace Twitter.VolumeStream.Tests.TestUtilities
{
    public class TweetArchiveReader : TweatArchive, ITweetReader
    {
        public const string Tweets20220917092751 = "Tweets20220917092751";

        public const string Tweets20220917093203 = "Tweets20220917093203";

        public const string Tweets20220917093621 = "Tweets20220917093621";

        public const string Tweets20220917094037 = "Tweets20220917094037";

        public static readonly string[] TweetArchivesFilenames =
            {
                Tweets20220917092751,
                Tweets20220917093203,
                Tweets20220917093621,
                Tweets20220917094037
            };

        private StreamReader? _streamReader;

        private bool _disposedValue;

        public TweetArchiveReader()
        {
            var filePath = Path.Combine(TweetArchiveFolderPath, Tweets20220917092751);

            _disposedValue = false; 
            _streamReader = new StreamReader(filePath);
        }

        public async Task<string?> ReadLineAsync()
        {
            return await _streamReader.ReadLineAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_streamReader != null)
                    {
                        _streamReader.Dispose();
                        _streamReader = null;
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

