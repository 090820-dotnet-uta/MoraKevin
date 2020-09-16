using System;

namespace HelloWorldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Kevin!");
            Console.WriteLine("What is you name?");
            var input = Console.ReadLine();
            Console.Write($"Hello {input}!");
        }
    }
}
