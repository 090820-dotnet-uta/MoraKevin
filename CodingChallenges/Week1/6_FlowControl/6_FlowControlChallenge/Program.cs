using System;

namespace _6_FlowControl
{
    public class Program
    {
        //create global variables to hold users login data.
        public static string username;
        public static string password;

        static void Main(string[] args){
        }

        // This method gets a valid temperaturebetween -40 asnd 135 inclusive 
        // and returns the valid int.
        public static int GetValidTemperature(){
            int i;
            string input;
            do{
                Console.WriteLine("\nPlease input a number between -40 and 135.");
                input = Console.ReadLine();
                // Checks to see if input is an int.
                if(int.TryParse(input, out i)){
                    // checks to see if input is within range.
                    if(i >= -40 && i <= 135){
                        break;
                    }
                }
                Console.WriteLine("Not a valid temperature");
            }while(true);
            return i;
        }

        // This method has one int parameter
        // It gives outdoor activity advice and temperature opinion based on 20 degree
        // increments starting at -20 and ending at 135 
        // n < -20 = hella cold
        // -20 <= n < 0 = pretty cold
        //  0 <= n < 20 = cold
        // 20 <= n < 40 = thawed out
        // 40 <= n < 60 = feels like Autumn
        // 60 <= n < 80 = perfect outdoor workout temperature
        // 80 <= n < 90 = niiice
        // 90 <= n < 100 = hella hot
        // 100 <= n < 135 = hottest
        public static void GiveActivityAdvice(int temp){
            var result = (temp < -20) ? "hella cold" : (-20 <= temp && temp < 0) ? "pretty cold" : 
                        (0 <= temp && temp < 20) ? "cold" : (20 <= temp && temp < 40) ? "thawed out" : 
                        (40 <= temp && temp < 60) ? "feels like Autumn" : (60 <= temp && temp < 80) ? "perfect outdoor workout temperature" :
                        (80 <= temp && temp < 90) ? "niiice" : 90 <= temp && temp < 100 ? "hella hot" : "hottest";
            Console.WriteLine($"\n{result}");
        }

        // This method gets a username and password from the user
        // and stores that data in the global variables of the 
        // names in the method.
        public static void Register(){
            string usrnm = Console.ReadLine();
            username = usrnm;
            string pswrd = Console.ReadLine();
            password = pswrd;
        }

        // This method gets username and password from the user and
        // compares them with the username and password global variables
        // or the names provided. If the password and username match,
        // the method returns true. If they do not match, the user is 
        // prompted again for the username and password.
        public static bool Login(){
            string uInput;
            string pInput;
            do {
                Console.WriteLine("\n------------- Login ------------- \n\nUsername:");
                uInput = Console.ReadLine();

                Console.WriteLine("\n\nPassword:");
                pInput = Console.ReadLine();
                
                if (username != uInput && password != pInput){
                    Console.WriteLine("\nUsername or Password does not match, please try again");
                }
            } while(username != uInput || password != pInput);
            return true;
        }

        // This method as one int parameter.
        // It chack is the int is <=42, between 
        // 43 and 78 inclusive, or > 78.
        // For each temperature range, a different 
        // advice is given. 
        public static void GetTemperatureTernary(int temp){
            var result = temp <= 42 ? $"{temp} is too cold!" : 
            temp >= 43 && temp <= 78 ? $"{temp} is an ok temperature" : $"{temp} is too hot!";
            Console.WriteLine($"\n{result}");
        }
    }//end of Program()
}
