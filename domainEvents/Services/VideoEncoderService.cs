using System;
using System.Threading;
using domainEvents.Entities;

namespace domainEvents.Services
{
    //using this to get familiar with pure events with c#
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoderService
    {
        //1. define a delegate
        //2. define an event based on that delegate
        //3. publish the event

        //1 old
        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        //simplier way to do 1 above (new)
        public event EventHandler<VideoEventArgs> VideoEncoded;
        public event EventHandler VideoEncoding;
        //2 old
        // public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video....");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        //3
        protected virtual void OnVideoEncoded(Video video)
        {
            //check if there are subscribers to the event
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}