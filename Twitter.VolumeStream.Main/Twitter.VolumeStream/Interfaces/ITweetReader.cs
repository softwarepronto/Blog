namespace Twitter.VolumeStream.Interfaces
{
    public interface ITweetReader : IDisposable
    {
        public void Dispose();

        Task<string?> ReadLineAsync();
    }
}
