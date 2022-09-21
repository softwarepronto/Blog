namespace Twitter.VolumeStream.Interfaces
{
    public interface ITweetClient
    {
        Task<ITweetReader> GetAsync();
    }
}
