using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args){
            Human h1 = new Human();
            Human h2 = new Human();
            h2.firstName = "Kevin";
            h2.lastName = "Mora";
            h1.AboutMe();
            h2.AboutMe();
            Human h3 = new Human();
            Human h4 = new Human();
            h3.eyeColor = "green";
            h4.age = 23;
            Human h5 = new Human("Mario", "Williams", "brown", 35);
            h3.AboutMe();
            h4.AboutMe();
            h5.AboutMe();
            Human h6 = new Human();
            h6.Weight = 280;
            Console.WriteLine($"{h6.firstName}'s weight is {h6.Weight}");
            h6.Weight = 450;
        }
    }
}
