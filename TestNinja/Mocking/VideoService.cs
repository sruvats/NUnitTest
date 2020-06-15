using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TestNinja.Fundamentals;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IVideoRepository _IVideoRepository;
        public VideoService(IVideoRepository IVideoRepository)
        {
            _IVideoRepository = IVideoRepository;


        }
      
        public string ReadVideoTitle()
        {
            var str = File.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            
            var videoIds = new List<int>();

            //using (var context = _IvideoContext)
            //{
            //var videos = 
            //    (from video in context.Videos
            //    where !video.IsProcessed
            //    select video).ToList();

            var videos = _IVideoRepository.GetUnProcessedVideo();
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
           // }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

   
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}