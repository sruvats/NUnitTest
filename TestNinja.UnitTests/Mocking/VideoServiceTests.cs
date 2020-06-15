using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Fundamentals;
using NUnit.Framework;
using Moq;
using System.Data;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IVideoRepository> _repository ;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_repository.Object);
            //_videoService.GetUnprocessedVideosAsCsv();


        }

        [Test]
        public void GetUnprocessedVideoAsCsv_whenCalled_ReturnsVideoIdString()
        {
            //   Mock<> videoContext = new Mock<IVideoContext>();

            _repository.Setup(r => r.GetUnProcessedVideo()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));

        }
        //   string result=  _videoService.GetUnprocessedVideosAsCsv();

        [Test]
        public void GetUnprocessedVideoAsCsv_AFewProcessedVideo_ReturnsAsStringWithId()
        {
            //   Mock<> videoContext = new Mock<IVideoContext>();

            _repository.Setup(r => r.GetUnProcessedVideo()).Returns(new List<Video>()
            {
                new Video{Id=1},
                new Video{Id=2},
                new Video{Id=3},
            });
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));

        }

        // Console.WriteLine(result);




    }
}
