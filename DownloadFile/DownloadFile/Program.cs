using System.Net;

namespace DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(@"http://speedtest.ftp.otenet.gr/files/test100Mb.db", "TestFile.db");
            }
        }
    }
}
