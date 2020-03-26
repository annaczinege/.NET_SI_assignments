using System.Net;

namespace stockTrader
{
    public class RemoteURLReader
    {
        public static string ReadFromUrl(string endpoint) {
            using(var client = new WebClient()) {
                return client.DownloadString(endpoint);
            }
        }
    }
}