using Microsoft.EntityFrameworkCore;
using P0.Models;
using P0.Utilities;
using P0.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using System.Runtime.CompilerServices;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            // DISPLAY WELCOME PAGE AND RETURN USERS CHOICE FOR NEXT PAGE
            string NextPage = ConsoleControl.DisplayWelcomePage();

            // DISPLAY PAGE USER CHOSE OR DISPLAY NOTHING IF USER CHOSE TO QUIT AND PASS CONTROL TO WHILE LOOP
            var items = ConsoleControl.DisplayLoginRegisterOrQuit(NextPage);

            // WHILE LOOP ALLOWS USER TO NAVIGATE BETWEEN PAGES AND GO BACK TO PREVIOUS PAGE OR LOGOUT OF ACCOUNT
            
            NextPage = items.Item1;
            String ThisPage;
            String PrevPage = "LOGOUT";
            Customer CurrentCustomer = items.Item2;
            Location CurrentLocation = null;
            List<Product> ShoppingCart = new List<Product>();
            List<int> Quantities = new List<int>();
            Product ProductToBuy = null;

            while (NextPage != "QUIT")
            {
                if (NextPage == "LOG IN")
                {
                    (NextPage, CurrentCustomer) = ConsoleControl.DisplayLoginRegisterOrQuit("LOG IN");
                }


                else if (NextPage == "CUSTOMER HOMEPAGE")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayCustomerHomePage(CurrentCustomer);

                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                    }
                    PrevPage = ThisPage;
                }


                else if (NextPage == "VIEW PRODUCTS")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayProductsHome();
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                    }
                    PrevPage = ThisPage;
                }


                else if (NextPage == "VIEW STORE LOCATIONS")
                {
                    ThisPage = NextPage;
                    (NextPage, CurrentLocation) = ConsoleControl.DisplayStoreLocations();
                    if(NextPage == "CUSTOMER HOMEPAGE")
                    {
                        ShoppingCart = new List<Product>();
                    }
                    PrevPage = ThisPage;
                }


                else if (NextPage == "GUITAR" || NextPage == "BASS" || NextPage == "DRUMS" || 
                    NextPage == "PIANO" || NextPage == "MIC" || NextPage == "ACC")
                {
                    ThisPage = NextPage;
                    PrevPage = "VIEW PRODUCTS";

                    (NextPage, ProductToBuy) = ConsoleControl.DisplayProductPage(NextPage);

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


                else if (NextPage == "LOCATIONS WITH PRODUCT")
                {
                    ThisPage = NextPage;
                    (NextPage, CurrentLocation) = ConsoleControl.DisplayLocationsWithProduct(ProductToBuy);
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                    }
                    else
                    {
                        int Quantity = ConsoleControl.DisplayQuantityPrompt(ProductToBuy, CurrentLocation);
                        ShoppingCart.Add(ProductToBuy);
                        Quantities.Add(Quantity);
                        ProductToBuy = null;
                    }
                    PrevPage = ThisPage;
                }


                else if (NextPage == "STORE HOMEPAGE")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayStoreHomePage(CurrentLocation);
                    PrevPage = ThisPage;
                    if(NextPage == "CUSTOMER HOMEPAGE")
                    {
                        CurrentLocation = null;
                        ShoppingCart = new List<Product>();
                    }
                }


                else if (NextPage == "VIEW PRODUCTS AT STORE")
                {
                    ThisPage = NextPage;

                    NextPage = ConsoleControl.DisplayProductsAtStoreHome(CurrentLocation);

                    if (NextPage == "GO BACK")
                    {
                        NextPage = "STORE HOMEPAGE";
                    }
                    PrevPage = ThisPage;
                }


                else if (NextPage == "GUITAR FROM STORE" || NextPage == "BASS FROM STORE" || NextPage == "DRUMS FROM STORE" 
                    || NextPage == "PIANO FROM STORE" || NextPage == "MIC FROM STORE" || NextPage == "ACC FROM STORE")
                {
                    ThisPage = NextPage;
                    PrevPage = "VIEW PRODUCTS AT STORE";

                    (NextPage, ShoppingCart, Quantities) = ConsoleControl.DisplayProductAtStore(NextPage, CurrentLocation, ShoppingCart, Quantities);
                    if (NextPage == "GO BACK")
                    {
                        NextPage = PrevPage;
                        PrevPage = "STORE HOMEPAGE";
                    }
                    else
                    {
                        PrevPage = ThisPage;
                    }
                }


                else if (NextPage == "VIEW SHOPPING CART")
                {
                    ThisPage = NextPage;
                    NextPage = ConsoleControl.DisplayShoppingCart(true, ShoppingCart, Quantities);
                    if (NextPage == "GO BACK")
                    {
                        NextPage = "VIEW PRODUCTS AT STORE";
                    }
                    PrevPage = "STORE HOMEPAGE";

                }


                else if (NextPage == "VIEW PAST ORDERS")
                {
                    ThisPage = NextPage;
                    ConsoleControl.DisplayPastOrders(CurrentCustomer);
                    NextPage = "CUSTOMER HOMEPAGE";
                    PrevPage = "LOG OUT";
                }


                else if (NextPage == "VIEW PAST ORDERS FROM LOCATION")
                {
                    ThisPage = NextPage;
                    ConsoleControl.DisplayPastOrdersFromLocation(CurrentLocation);
                    NextPage = "STORE HOMEPAGE";
                    PrevPage = "CUSTOMER HOMEPAGE";
                }


                else if (NextPage == "CHECKOUT")
                {
                    NextPage = ConsoleControl.DisplayCheckoutHome(ShoppingCart, CurrentCustomer, CurrentLocation, Quantities);
                    if(NextPage == "CUSTOMER HOMEPAGE")
                    {
                        ShoppingCart = new List<Product>();
                        Quantities = new List<int>();
                    }
                }


                else if (NextPage == "VIEW CUSTOMERS")
                {
                    ThisPage = NextPage;
                    ConsoleControl.DisplayCustomers();
                    NextPage = "CUSTOMER HOMEPAGE";
                    PrevPage = "LOG OUT";
                }

                else if (NextPage == "LOGOUT")
                {
                    ShoppingCart = new List<Product>();
                    Quantities = new List<int>();
                    CurrentLocation = null;
                    CurrentCustomer = null;
                    ProductToBuy = null;

                    NextPage = ConsoleControl.DisplayWelcomePage();
                    ThisPage = NextPage;

                    (NextPage, CurrentCustomer) = ConsoleControl.DisplayLoginRegisterOrQuit(NextPage);

                    PrevPage = ThisPage;
                }
            }
            Console.WriteLine("\nCome back again soon!");
            Console.WriteLine("\n----------------GOODBYE-----------------");
        }
    }
}
