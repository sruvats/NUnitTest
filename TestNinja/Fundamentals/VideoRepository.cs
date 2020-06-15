using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;


namespace TestNinja.Fundamentals
{
    class VideoRepository : IVideoRepository
    {
        
        public IEnumerable<Video> GetUnProcessedVideo()
        {
           

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();


                return videos;
            }
        }
    }
}
