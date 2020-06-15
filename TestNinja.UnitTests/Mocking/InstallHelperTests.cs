using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using NUnit.Framework;
using Moq;
using System.Net;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallHelperTests
    {
        private Mock<IFileDownLoader> _fileDownloader;
        private InstallerHelper _installerHelper;
        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownLoader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
            
        }

        [Test]
        public void DownloadInstaller_whenPassedURL_ReturnsTrue()
        {
            //since it is not expecting a value to be returned, we dont need to setup
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.EqualTo(true));


        }
        [Test]
        public void DownloadInstaller_whenException_ReturnsFalse()
        {
            
            _fileDownloader.Setup(fd => fd.DownLoadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            var result= _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.EqualTo(false));



        }
    }
}
