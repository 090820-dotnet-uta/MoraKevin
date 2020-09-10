using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


        }

        public static string GetName()
        {
            System.Console.Write("Please enter your name.");
            string name = System.Console.ReadLine();
            return name;
        }

        public static void GreetFriend(string name)
        {
            //Greeting should be: Hello, nameVar. You are my friend
            //Ex: Hello, Jim. You are my friend
            System.Console.WriteLine($"Hello, {name}. You are my friend");
        }

        public static double GetNumber()
        {
            //Should throw FormatException if the user did not input a number
            double d;
            System.Console.WriteLine("Please input a number");
            string input = System.Console.ReadLine();
            if (double.TryParse(input, out d))
            {
                System.Console.WriteLine("Thanks!");
            }
            else{
                throw new FormatException("I need a number!");
            }
            return d;
        }

        public static int GetAction()
        {   int x;
            while (true)
            {
                System.Console.WriteLine("Please enter 1 for addittion, 2 for subtraction, 3 for multiplication, or 4 for division.");
                string s = System.Console.ReadLine();
                if(int.TryParse(s, out x))
                {
                    if(x > 0 && x < 5){
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("You must enter a number between the specified range!");
                    }
                }
                else{
                    System.Console.WriteLine("You must enter a number!");
                }
            }
            return x;
        }

        public static double DoAction(double x, double y, int z)
        { double value = 0;
            if (z < 1 || z > 4){
                throw new FormatException("Z is not 1, 2, 3, or 4");
            }
            if (z == 1)
            {
                value = x + y;
            }
            else if (z == 2)
            {
                value = y - x;
            }
            else if (z == 3)
            {
                value = x * y;
            }
            else if (z == 4)
            {
                value = x / y;
            }
            return value;
        }
    }
}
