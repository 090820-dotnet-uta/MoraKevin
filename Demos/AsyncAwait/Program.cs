using System;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace AsyncAwait
{
    class Program
    {
        private static System.Timers.Timer aTimer;

        static async Task Main(string[] args)
        {
            AsyncMethods am = new AsyncMethods();

            var time1 = DateTime.Now;
            System.Console.WriteLine($"The first time is {time1}");

            var m1 = am.Method1Async();
            var m2 = am.Method2Async(2);
            var m3 = am.Method2Async(3);
            var m4 = am.Method2Async(4);
            var m5 = am.Method2Async(5);

            var time2 = DateTime.Now;
            System.Console.WriteLine($"The second time is {time2}");

            await m1;
            Console.WriteLine("M1 Returned");
            await m2;
            Console.WriteLine("M2 Returned");
            await m3;
            Console.WriteLine("M3 Returned");
            await m4;
            Console.WriteLine("M4 Returned");
            await m5;
            Console.WriteLine("M5 Returned");

            var time3 = DateTime.Now;
            System.Console.WriteLine($"The second time is {time3}");




            //create a timer delegate to be raised every second.
            // https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer.elapsed?view=netcore-3.1
            //     aTimer = new System.Timers.Timer(); // create a timer
            //     aTimer.Interval = 1000;              // set the timer interval to half a second
            //     aTimer.Elapsed += OnTimedEvent;     // subscribe the event to the timer
            //     aTimer.AutoReset = true;            // have the timer fire repeatedly
            //     aTimer.Enabled = true;              // start the timer



            //     // Neither the class nor the methods are static so you can 
            //     // only access them through an instance of the class.
            //     AsyncMethods am = new AsyncMethods();

            //     var time1 = DateTime.Now;
            //     System.Console.WriteLine($"The first time is {time1}");

            //     //call the methods the save the returned task into a Task.
            //     Task<int> m1Task = am.Method1Async();
            //     var m2Task = am.Method2Async();
            //     var m3Task = am.Method3Async();
            //     var m4Task = am.Method4Async();
            //     var m5Task = am.Method5Async();

            //     //print the current time
            //     var time2 = DateTime.Now;
            //     System.Console.WriteLine($"The second time is {time2}");

            //     // now await the tasks.
            //     int m1Int = await m1Task;
            //     int m2Int = await m2Task;
            //     int m3Int = await m3Task;
            //     int m4Int = await m4Task;
            //     int m5Int = await m5Task;

            //     //wait 4 seconds to allow enough time for the methods to return
            //     Task.Delay(4000).Wait();

            //     // print the current time
            //     var time3 = DateTime.Now;
            //     System.Console.WriteLine($"The third time is {time3}");
        }//end of Main()

        // This event will fire based ont he trigger interal set above.
        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            System.Console.WriteLine($"The time now is {e.SignalTime}");
        }
    }//end of Program
}//End of NameSpace