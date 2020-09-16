using System;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
        
        public static void UseFor()
        {   String s = "";
            for(int i = 0; i <= 50; i++){
                if ((i % 2) != 0){
                    s += $"{i} ";
                }
            }
            Console.WriteLine(s);
        }

        public static void UseDoWhile()
        {   
            string s = "";
            int i = 0;
            do{
                if ((i % 2) == 0){
                    s += $"{i} ";
                }
                i++;
            } while( i <= 50);
            Console.WriteLine(s);
        }

        public static void UseWhile()
        {
            int i = 0;
            while(true){
                if(i % 3 == 0 && i % 5 == 0){
                    Console.WriteLine("Skipping this number");
                } else if (i % 3 == 0){
                    Console.WriteLine($"{i}");
                }
                if(i > 100){
                    break;
                }
                i++;
            }
        }
    }
}
// 2. create a do/while loop that displays the even integers from 0 to 50.
// 3. create a while loop that displays the multiples of 3 integers from 0 to 100. 
//     1. Design the loop so that when every multiple of 3 and 5 coincide(like 15, 30, etc), you print "skipping this number" instead of the number.
//     2. Design the loop so that when you get above 100 you automatically stop the loop with a break statement.