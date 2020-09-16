using System;

namespace EventHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler UIEvent = new EventHandler(); //create the event class instance
            UIwords1 uiw1 = new UIwords1(); //class instance
            UIwords2 uiw2 = new UIwords2(); // class instance

            UIEvent.UIEvent += uiw1.OnUserInput; // subscribe the events
            UIEvent.UIEvent += uiw2.OnUserInput; // subscribe events

            // do things ......

            UIEvent.UserInputRecieved();

        }
    }
}
