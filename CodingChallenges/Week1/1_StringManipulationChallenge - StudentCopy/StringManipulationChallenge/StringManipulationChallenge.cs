using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;
            
            //
            //
            //implement the required code here and within the methods below.
            // 
            //

            System.Console.WriteLine("Please enter your message and press enter");
            userInputString = System.Console.ReadLine();
            System.Console.WriteLine("Please enter a number LESS THAN the length of your string and press enter");
            string number = System.Console.ReadLine();
            int.TryParse(number, out elementNum);

            System.Console.WriteLine("StringToUpper produces: ");
            StringToUpper(userInputString);
            System.Console.WriteLine("\n");
            
            System.Console.WriteLine("StringToLower produces: ");
            StringToLower(userInputString);
            System.Console.WriteLine("\n");

            System.Console.WriteLine("StringTrim produces: ");
            StringTrim(userInputString);
            System.Console.WriteLine("\n");

            System.Console.WriteLine("StringSubstring produces: ");
            StringSubstring(userInputString, elementNum);
            System.Console.WriteLine("\n");

            System.Console.WriteLine("For which character should I search in your original message?");
            string c = System.Console.ReadLine();
            char1 = char.Parse(c);
            System.Console.WriteLine("\n");

            System.Console.WriteLine("SearchChar produces: ");
            int index = SearchChar(userInputString, char1);
            System.Console.WriteLine("Char at Index: " +  index.ToString());
            System.Console.WriteLine("\n");

            System.Console.WriteLine("Please enter your first name");
            fName = System.Console.ReadLine();
            System.Console.WriteLine("\n");

            System.Console.WriteLine("Please enter your last name");
            lName = System.Console.ReadLine();
            System.Console.WriteLine("\n");

            System.Console.WriteLine("ConcatName produces: ");
            userFullName = ConcatNames(fName, lName);
            System.Console.WriteLine("User full name: " + userFullName);





        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x){
            string s = x.ToUpper();
            System.Console.WriteLine(s);
            return s;
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x){
            string s = x.ToLower();
            System.Console.WriteLine(s);
            return s;
        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x){
            string s = "";
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].ToString() != " ") 
                {
                    s = x.Substring(i);
                    break;
                }
            }
            string t = s;
            for (int i = s.Length - 1; i > 0; i--)
             {
                if(s[i].ToString() != " ") 
                {
                    t = s.Substring(0, i + 1);
                    break;
                }
            }
            System.Console.WriteLine(t);
            return t;
        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum){
            string s = x.Substring(elementNum);
            System.Console.WriteLine(s);
            return s;

        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x){
            String s = userInputString;
            int index = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == x)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                System.Console.WriteLine("This string does not contain that char");
            }
            return index;
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName){
            String s = fName + " " + lName;
            return s;
        }



    }//end of program
}
