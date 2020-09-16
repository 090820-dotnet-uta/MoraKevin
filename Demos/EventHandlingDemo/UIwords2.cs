using System;
using System.Threading;

namespace EventHandlingDemo
{
    public class UIwords2
    {
        public void OnUserInput(object source, SentenceEventArgs args){
            Console.WriteLine("What do you want to say.");
            string ui = Console.ReadLine(); 
            Console.WriteLine("Waititing 2 seconds");
            Thread.Sleep(2000);
        }
    }
}