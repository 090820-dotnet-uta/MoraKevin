using Microsoft.EntityFrameworkCore;
using P0.Models;
using P0.Utilities;
using P0.DAOs;
using System;
using System.Collections.Generic;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            // CREATE NEW CONTEXT
            P0Context DB = new P0Context();
            /*
            int i = 0;
            while (i < 20){
                Console.WriteLine("Product Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Product Price:");
                int.TryParse(Console.ReadLine(), out int price);
                Console.WriteLine("Product Description:");
                string desc = Console.ReadLine();
                Console.WriteLine("Product Type:");
                string type = Console.ReadLine();
                i++;
                Product p = new Product
                {
                    Name = name,
                    Price = price,
                    Description = desc,
                    Type = type
                };
                ProductDAO.AddProduct(p, DB);
            }
            */

            // DISPLAY WELCOME PAGE AND RETURN USERS CHOICE FOR NEXT PAGE
            string NextPage = ConsoleControl.DisplayWelcomePage();

            // DISPLAY PAGE USER CHOSE OR DISPLAY NOTHING IF USER CHOSE TO QUIT AND PASS CONTROL TO WHILE LOOP
            NextPage = ConsoleControl.DisplayHomePage(NextPage, DB);

            // WHILE LOOP WHICH SIMULATES BEING 'INSIDE' THE USERS ACCOUNT 
            // ALLOWS USER TO NAVIGATE BETWEEN PAGES AND GO BACK TO PREVIOUS PAGE OR LOGOUT OF ACCOUNT

            String ThisPage;
            String PrevPage = "LOGOUT";
            DB.ShoppingCart = new List<Product>();
            DB.TempShoppingCart = new List<Product>();
            while (NextPage != "QUIT")
            {
                if (NextPage == "CUSTOMER HOMEPAGE")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayCustomerHomePage(DB);
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                    }
                    PrevPage = ThisPage;
                }
                else if (NextPage == "LOG IN")
                {
                    NextPage = ConsoleControl.DisplayHomePage("login", DB);
                }
                else if (NextPage == "VIEW PRODUCTS")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayProductsHome(DB);
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                    }
                    PrevPage = ThisPage;
                }
                if (NextPage == "GUITAR" || NextPage == "BASS" || NextPage == "DRUMS" || NextPage == "PIANO" || NextPage == "MIC" || NextPage == "ACC")
                {
                    ThisPage = NextPage;
                    PrevPage = "VIEW PRODUCTS";

                    NextPage = ConsoleControl.DisplayProductPage(NextPage, DB);

                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                        PrevPage = "CUSTOMER HOMEPAGE";
                    }
                    else
                    {
                        PrevPage = ThisPage;
                    }
                }
                else if (NextPage == "VIEW STORE LOCATIONS")
                {
                    NextPage = "QUIT";
                }
                else if (NextPage == "VIEW SHOPPING CART")
                {
                    NextPage = "QUIT";
                }
                else if (NextPage == "CHECKOUT")
                {
                    NextPage = "QUIT";
                }
                else if (NextPage == "EDIT ACCOUNT INFO")
                {
                    NextPage = "QUIT";
                }
                else if (NextPage == "LOGOUT")
                {
                    NextPage = "QUIT";
                }
                else if (NextPage == "LOCATIONS WITH PRODUCT")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayLocationsWithProduct(DB);
                    NextPage = "GO BACK";
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                        PrevPage = ThisPage;
                    }
                }
            }
            Console.WriteLine("\nCome back again soon!");
            Console.WriteLine("\n----------------GOODBYE-----------------");
        }
    }
}
