using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private  IFileDownLoader _ifileDownLoader;
        public InstallerHelper(IFileDownLoader ifileDownLoader)
        {
            _ifileDownLoader = ifileDownLoader;
        }
        
        private string _setupDestinationFile;
      

        public bool DownloadInstaller(string customerName, string installerName)
        {
           // var client = new WebClient();
            try
            {
                //client.DownloadFile(
                //    string.Format("http://example.com/{0}/{1}",
                //        customerName,
                //        installerName),
                //    _setupDestinationFile);

                _ifileDownLoader.DownLoadFile(string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}