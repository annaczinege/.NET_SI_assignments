using System.Net;

namespace stockTrader
{
    public class RemoteURLReader: IRemoteURLReader
    {
        public string ReadFromUrl(string endpoint) {
            using(var client = new WebClient()) {
                return client.DownloadString(endpoint);
            }
        }
    }
}