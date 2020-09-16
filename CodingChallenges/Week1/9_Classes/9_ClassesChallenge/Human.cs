using System;

namespace _9_ClassesChallenge
{
    public class Human
    {   
        public string lastName = "Smyth";
        public string firstName = "Pat";
        public string eyeColor;
        public int age = -1; 
        public int Weight { 
            get{
                return Weight;
            } 
            set{
                if (Weight > 0 && Weight <= 400){
                    this.Weight = value;
                }
            } 
        }
        //default constructor is needed when you create a parameterized constructor.
        public Human() { 
        }
        public Human(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Human(string firstName, string lastName, string eyeColor) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }
        public Human(string firstName, string lastName, int age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age; 
        }
        public Human(string firstName, string lastName, string eyeColor, int age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age; 
        }

        public void AboutMe(){
            if(eyeColor == null && age == -1){
                Console.WriteLine($"My name is {firstName} {lastName}.");
            } else if (eyeColor == null){
                Console.WriteLine($"My name is {firstName} {lastName}. My age is {age}.");
            } else if (age == -1){
                Console.WriteLine($"My name is {firstName} {lastName}. My eye color is {eyeColor}.");
            } else{
                 Console.WriteLine($"My name is {firstName} {lastName}. My eye color is {eyeColor} and my age is {age}.");
            }
        }

    }//end of class
}//end of namespace