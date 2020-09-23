using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Utilities
{
    class InputControl
    {
        private const string LRQ = "LOGIN REGISTER OR QUIT";
        private const string TRQ = "TRY AGAIN OR QUIT";
        private const string CHP = "CUSTOMER HOME PAGE";
        private const string PRP = "PRODUCTS PAGE";

        internal static string VerifyChoice(string s)
        {
            string input = "";
            switch (s){
                /// LOGIN REGISTER OR QUIT
                case LRQ:
                    do
                    {
                        input = Console.ReadLine();
                        input = input.Trim();
                        if (input == "1")
                        {
                            input = "LOG IN";
                        }
                        else if (input == "2")
                        {
                            input = "REGISTER";
                        }
                        else if (input == "3")
                        {
                            input = "QUIT";
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter 1 for Log in 2 for Registration or 3 to Quit");
                        }
                    } while (input != "LOG IN" && input != "REGISTER" && input != "QUIT");
                    break;
                // TRY AGAIN OR QUIT
                case TRQ:
                    do
                    {
                        input = Console.ReadLine();
                        input = input.Trim();
                        input = input.ToLower();
                        if (input == "1")
                        {
                            input = "LOG IN";
                        }
                        else if (input == "2")
                        {
                            input = "QUIT";
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter 1 to Try Again or 2 to Quit");
                        }
                    } while (input != "LOG IN" && input != "QUIT");
                    break;
                // CUSTOMER HOME PAGE
                case CHP:
                    do
                    {
                        input = Console.ReadLine();
                        input = input.Trim();
                        if (input == "1")
                        {
                            input = "VIEW PRODUCTS";
                        }
                        else if (input == "2")
                        {
                            input = "VIEW STORE LOCATIONS";
                        }
                        else if (input == "3")
                        {
                            input = "VIEW PAST ORDERS";
                        }
                        else if (input == "4")
                        {
                            input = "VIEW CUSTOMERS";
                        }
                        else if(input == "5")
                        {
                            input = "LOGOUT";
                        }
                        else 
                        {
                            Console.WriteLine("\nPlease enter 1, 2, 3, 4, or 5 to proceed");
                            Console.WriteLine("\n1.View Products");
                            Console.WriteLine("2.View Store Locations");
                            Console.WriteLine("3.View Past Orders");
                            Console.WriteLine("4. View Customers");
                            Console.WriteLine("5. Logout\n");
                        }
                    } while (input != "VIEW PRODUCTS" && input != "VIEW STORE LOCATIONS" && 
                    input != "VIEW PAST ORDERS" && input != "VIEW CUSTOMERS" && input != "LOGOUT");
                    break;
                // PRODUCTS PAGE
                case PRP:
                    do
                    {
                        input = Console.ReadLine();
                        input = input.Trim();
                        if (input == "1")
                        {
                            input = "GUITAR";
                        }
                        else if (input == "2")
                        {
                            input = "BASS";
                        }
                        else if (input == "3")
                        {
                            input = "DRUMS";
                        }
                        else if (input == "4")
                        {
                            input = "PIANO";
                        }
                        else if (input == "5")
                        {
                            input = "MIC";
                        }
                        else if (input == "6")
                        {
                            input = "ACC";
                        }
                        else if (input == "7")
                        {
                            input = "LOGOUT";
                        }
                        else if (input == "0")
                        {
                            input = "GO BACK";
                        }
                        else
                        {
                            Console.WriteLine("\nWhat kind of product are you looking for?");
                            Console.WriteLine("\n1. Guitar");
                            Console.WriteLine("2. Bass");
                            Console.WriteLine("3. Drum");
                            Console.WriteLine("4. Piano");
                            Console.WriteLine("5. Microphones");
                            Console.WriteLine("6. Accessories");
                            Console.WriteLine("7. Logout\n");

                            Console.WriteLine("Enter 0 if you wish to go back to the previous page\n");
                        }
                    } while (input != "GUITAR" && input != "BASS" &&
                    input != "DRUMS" && input != "PIANO" && input != "MIC" &&
                    input != "ACC" && input != "LOGOUT" && input !="GO BACK");
                    break;
                default:
                    break;
        }
            return input;
        }

        internal static int VerifyListChoiceStartingAt0(int Num)
        {
            int choice;
            bool isInt;
            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out choice);
                if (!isInt || (choice < 0 || choice > Num))
                {
                    Console.WriteLine($"\nYou must enter a number between 0 and {Num}");
                }
            } while (!isInt && (choice < 0 && choice > Num));
            choice--;
            return choice;
        }

        internal static int VerifyListChoiceStartingAt1(int Num)
        {
            int choice;
            bool isInt;
            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out choice);
                if (!isInt || (choice < 1 || choice > Num))
                {
                    Console.WriteLine($"\nYou must enter a number between 1 and {Num}");
                }
            } while (!isInt || (choice < 1 || choice > Num));
            choice--;
            return choice;
        }

        internal static string VerifyChoiceLocationHome()
        {
            string NextPage = "QUIT";
            string input;
            bool isInt;
            int i;
            do
            {
                input = Console.ReadLine();
                input.Trim();
                isInt = int.TryParse(input, out i);
                if (!isInt || i < 0 || i > 5)
                {
                    Console.WriteLine("\nYou must enter a number between 0 and 5! Please try again.");
                }
            } while (!isInt || i < 0 || i > 5);

            if (i == 0)
            {
                NextPage = "CUSTOMER HOMEPAGE";
            }
            else if (i == 1)
            {
                NextPage = "VIEW PRODUCTS AT STORE";
            }
            else if (i == 2)
            {
                NextPage = "VIEW SHOPPING CART";
            }
            else  if (i == 3)
            {
                NextPage = "VIEW PAST ORDERS FROM LOCATION";
            }
            else if (i == 4)
            {
                NextPage = "CHECKOUT";
            }
            else if (i == 5)
            {
                NextPage = "LOGOUT";
            }
            return NextPage;
        }

        internal static string VerifyPostProductSelectionChoice()
        {
            String NextPage = "STORE HOMEPAGE";
            String userInput;
            bool isNum;
            int k;
            do
            {
                userInput = Console.ReadLine();
                userInput.Trim();
                isNum = int.TryParse(userInput, out k);
                if (!isNum || (k < 1 || k > 3))
                {
                    Console.WriteLine("\n You must insert a number between 1 and 3!");
                }
            } while (!isNum || (k < 1 || k > 3));
            if (k == 1)
            {
                NextPage = "VIEW PRODUCTS AT STORE";
            }
            else if (k == 2)
            {
                NextPage = "VIEW SHOPPING CART";
            }
            else if (k == 3)
            {
                NextPage = "CHECKOUT";
            }
            return NextPage;
        }

        internal static string VerifyWantToCheckoutChoice()
        {
            string NextPage = "STORE HOMEPAGE";
            int j;
            bool isNum;
            string input;
            do
            {
                input = Console.ReadLine();
                input.Trim();
                isNum = int.TryParse(input, out j);
                if (!isNum || j <= 0 || j > 2)
                {
                    Console.WriteLine("\nYou must enter 1 for Yes or 2 for No.");
                }
            } while (!isNum || j <= 0 || j > 2);
            if (j == 1)
            {
                NextPage = "CHECKOUT";
            }
            return NextPage;
        }

        internal static int VerifyCheckoutHomeChoice()
        {
            int j;
            bool isNum;
            string input;
            do
            {
                input = Console.ReadLine();
                input.Trim();
                isNum = int.TryParse(input, out j);
                if (!isNum || j <= 0 || j > 2)
                {
                    Console.WriteLine("\nYou must enter 1 or 2.");
                }
            } while (!isNum || j <= 0 || j > 2);
            return j;
        }
    }
}
