using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TestNinja.Mocking
{
    class FileDownLoader : IFileDownLoader
    {
        public void DownLoadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
