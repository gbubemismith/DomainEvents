using System;

namespace domainEvents.Services
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("MessageService: Sending a text message....." + e.Video.Title);
        }
    }
}