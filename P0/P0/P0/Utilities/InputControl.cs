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
                        input = input.ToLower();
                        if (input != "login" || input != "log in" || input != "l" ||
                            input != "1" || input != "registration" || input != "register" ||
                            input != "r" || input != "2" || input != "quit" || input != "q" ||
                            input != "3")
                        {
                            Console.WriteLine("\nPlease enter 1 for Log in 2 for Registration or 3 to Quit");
                        }
                    } while (input != "login" && input != "log in" && input != "l" &&
                            input != "1" && input != "registration" && input != "register" &&
                            input != "r" && input != "2" && input != "quit" && input != "q" &&
                            input != "3");
                    break;
                // TRY AGAIN OR QUIT
                case TRQ:
                    do
                    {
                        input = Console.ReadLine();
                        input = input.Trim();
                        input = input.ToLower();
                        if (input == "try" || input == "try again" || input == "t" || input == "1")
                        {
                            input = "t";
                        }
                        else if (input == "quit" || input == "q" || input == "2")
                        {
                            input = "q";
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter 1 to Try Again or 2 to Quit");
                        }
                    } while (input != "t" && input != "q");
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
                            input = "VIEW SHOPPING CART";
                        }
                        else if (input == "5")
                        {
                            input = "CHECKOUT";
                        }
                        else if (input == "6")
                        {
                            input = "EDIT ACCOUNT INFO";
                        }
                        else if(input == "7")
                        {
                            input = "LOGOUT";
                        }
                        else 
                        {
                            Console.WriteLine("\nPlease enter 1, 2, 3, 4, 5, or 7 to proceed");
                            Console.WriteLine("\n1.View Products");
                            Console.WriteLine("2.View Store Locations");
                            Console.WriteLine("3.View Past Orders");
                            Console.WriteLine("4.View Shopping Cart");
                            Console.WriteLine("5. Checkout");
                            Console.WriteLine("6. Edit Account Information");
                            Console.WriteLine("7. Logout\n");
                        }
                    } while (input != "VIEW PRODUCTS" && input != "VIEW STORE LOCATIONS" && 
                    input != "VIEW SHOPPING CART" && input != "VIEW PAST ORDERS" && input != "CHECKOUT" && 
                    input != "EDIT ACCOUNT INFO" && input != "LOGOUT");
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
    }
}
