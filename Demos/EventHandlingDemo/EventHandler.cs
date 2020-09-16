using System;
using System.Threading;

namespace EventHandlingDemo{
        public class EventHandler{
            // 1. Create the delegate event handler in the class where the even will be emitted.
            // public delegate void UserInputEventHandler(object source, EventArgs args);

            // 2. create an event based on the event handler
             // public event UserInputEventHandler UIEvent;

            // this event is the combination of the 2 steps above
             public event EventHandler<SentenceEventArgs> UIEvent;

             protected virtual void OnUserInput(/*File file*/){
                 if ( UIEvent != null){
                     UIEvent(this, new SentenceEventArgs() {UISentence = "This"});
                 }
             }

             public void UserInputRecieved(){
                 Console.WriteLine("The user input event has been fired.");
                 Thread.Sleep(1000);

                 OnUserInput();
             }
        }
}