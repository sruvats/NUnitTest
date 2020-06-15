using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.Fundamentals
{
  public  interface IVideoRepository 
    {
        IEnumerable<Video> GetUnProcessedVideo();
    }
}