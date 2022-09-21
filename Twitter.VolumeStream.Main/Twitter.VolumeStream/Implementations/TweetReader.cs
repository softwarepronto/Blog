namespace Twitter.VolumeStream.Implementations
{
    public class TweetReader : ITweetReader
    {
        private Stream? _stream = null;

        private StreamReader? _streamReader = null;

        private bool _disposedValue;

        public TweetReader(Stream stream)
        {
            _disposedValue = false;
            _stream = stream;
            _streamReader = new StreamReader(_stream);
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

                    if (_stream != null)
                    {
                        _stream.Dispose();
                        _stream = null;
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
