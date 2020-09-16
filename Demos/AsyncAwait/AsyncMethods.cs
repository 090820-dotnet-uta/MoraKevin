using System;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    public class AsyncMethods
    {
        public async Task Method1Async()//convention says to add Async in the name of the method
        {
            await Task.Delay(5000);
            System.Console.WriteLine("Method 1 Just after await 5 secs");
            Thread.Sleep(5000);
            System.Console.WriteLine("In method 1 waited 5 seconds");
        }

        public async Task Method2Async(int i)//convention says to add Async in the name of the method
        {
            await Task.Delay(3000);
            System.Console.WriteLine($"Method {i} Just after await 3 secs");
            Thread.Sleep(5000);
            System.Console.WriteLine($"In method {i} waited 3 seconds");
        }


        //all asynchronous methods must return Task or Task<DataTypeHere>
        // public async Task<int> Method1Async()//convention says to add Async in the name of the method
        // {
        //     await Task.Delay(3000);
        //     System.Console.WriteLine("In method 1 now waiting 3 seconds");
        //     return 1;
        // }

        // public async Task<int> Method2Async()
        // {
        //     await Task.Delay(3000);
        //     System.Console.WriteLine("In method 2 now waiting 3 seconds");
        //     return 1;
        // }

        // public async Task<int> Method3Async()
        // {
        //     await Task.Delay(3000);
        //     System.Console.WriteLine("In method 3 now waiting 3 seconds");
        //     return 1;
        // }

        // public async Task<int> Method4Async()
        // {
        //     await Task.Delay(3000);
        //     System.Console.WriteLine("In method 4 now waiting 3 seconds");
        //     return 1;
        // }

        // public async Task<int> Method5Async()
        // {
        //     System.Console.WriteLine("In method 5 now waiting 3 seconds");
        //     await Task.Delay(3000);
        //     return 1;
        // }
    }
}