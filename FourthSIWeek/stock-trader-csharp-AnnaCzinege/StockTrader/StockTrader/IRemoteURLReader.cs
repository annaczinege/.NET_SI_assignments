namespace stockTrader
{
    public interface IRemoteURLReader
    {
        string ReadFromUrl(string endpoint);
    }
}