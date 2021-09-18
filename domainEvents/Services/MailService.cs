using System;

namespace domainEvents.Services
{
    //Subscriber for video encoder event
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("MailService: Sending an email....." + e.Video.Title);
        }
    }
}