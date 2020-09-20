using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P0.Models;
using P0.DAOs;
using System.Threading;

namespace P0.Utilities
{
    class ConsoleControl
    {
        private const string GUITAR = "GUITAR";
        private const string BASS = "BASS";
        private const string PIANO = "PIANO";
        private const string DRUM = "DRUMS";
        private const string MICROPHONE = "MIC";
        private const string ACCESSORY = "ACC";

        internal static string DisplayHomePage(string UserChoice, P0Context DB)
        {
            string NextPage = "";
            if (UserChoice == "register" || UserChoice == "r" || UserChoice == "2")
            {
                UserAccount Account = DisplayRegistrationPage();
                DatabaseControl.CreateAccount(Account, DB);
                DatabaseControl.SaveAccountToCustomerList(Account, DB);
                NextPage = "CUSTOMER HOMEPAGE";
            }
            else if (UserChoice == "log in" || UserChoice == "login" || UserChoice == "l" || UserChoice == "1")
            {
                UserAccount Account = DisplayLoginPage();
                if (DatabaseControl.LoginSuccesful(Account, DB))
                {
                    DatabaseControl.SaveAccountToCustomerList(Account, DB);
                    NextPage = "CUSTOMER HOMEPAGE";
                }
                else
                {
                    string input = DisplayLoginFailed();
                    if (input == "t")
                    {
                        NextPage = "LOG IN";
                    }
                    else if (input == "q")
                    {
                        NextPage = "QUIT";
                    }
                }
            }
            else if (UserChoice == "quit" || UserChoice == "q" || UserChoice == "3")
            {
                NextPage = "QUIT";
            }
            return NextPage;
        }

        internal static string DisplayWelcomePage()
        {
            Console.WriteLine("\n\n\t\t\tHello!");
            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("\n(1) Log In OR (2) Register OR (3) Quit");

            return InputControl.VerifyChoice("LOGIN REGISTER OR QUIT");
        }

        private static UserAccount DisplayRegistrationPage()
        {
            UserAccount Account = new UserAccount();
            Console.WriteLine("\n\n-------------REGISTRATION HOMEPAGE---------------");
            Console.WriteLine("\nUsername:");
            string UsernameI = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            string PasswordI = Console.ReadLine();
            string PasswordI2;
            do
            {
                Console.WriteLine("\nVerify Password:");
                PasswordI2 = Console.ReadLine();
                if (!PasswordI.Equals(PasswordI2))
                {
                    Console.WriteLine("\nPasswords must match! Please try again.");
                }
            } while (!PasswordI.Equals(PasswordI2));
            Account.Username = UsernameI;
            Account.Password = PasswordI;
            return Account;
        }

        private static UserAccount DisplayLoginPage()
        {
            Console.WriteLine("\n\n-------------LOG IN HOMEPAGE---------------");
            Console.WriteLine("\nUsername:");
            string UsernameI = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            string PasswordI = Console.ReadLine();

            UserAccount UserInfo = new UserAccount()
            {
                Username = UsernameI,
                Password = PasswordI
            };

            return UserInfo;
        }

        private static string DisplayLoginFailed()
        {
            Console.WriteLine("\n\n-------------LOGIN FAILED---------------");
            Console.WriteLine("\n Would You like to (1) try again or (2) quit?");
            return InputControl.VerifyChoice("TRY AGAIN OR QUIT");
        }

        internal static string DisplayCustomerHomePage(P0Context DB)
        {
            Console.WriteLine($"\n-------------WELCOME {DB.CustomersList[0].FirstName.ToUpper()}----------------");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. View Store Locations");
            Console.WriteLine("3. View Past Orders");
            Console.WriteLine("4. View Shopping Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Edit Account Information");
            Console.WriteLine("7. Logout\n");
            return InputControl.VerifyChoice("CUSTOMER HOME PAGE");
        }

        internal static void DisplayCustomers(P0Context DB)
        {
            foreach (Customer c in DB.Customers.ToList())
            {
                Console.WriteLine($"\nFirst Name: {c.FirstName}");
                Console.WriteLine($"Last Name: {c.LastName}");
            }
        }

        internal static void DisplayUserAccounts(P0Context DB)
        {
            foreach (UserAccount u in DB.UserAccounts.ToList())
            {
                Console.WriteLine($"\nCustomerID: {u.CustomerID}");
                Console.WriteLine($"Password: {u.Password}");
                Console.WriteLine($"\nUsername: {u.Username}");
                Console.WriteLine($"Password: {u.Password}");
            }
        }

        internal static string DisplayProductsHome(P0Context DB)
        {
            Console.WriteLine($"\n-------------PRODUCTS HOME PAGE----------------");
            Console.WriteLine("\nWhat kind of product are you looking for?");
            Console.WriteLine("\n1. Guitar");
            Console.WriteLine("2. Bass");
            Console.WriteLine("3. Drums");
            Console.WriteLine("4. Piano");
            Console.WriteLine("5. Microphones");
            Console.WriteLine("6. Accessories");
            Console.WriteLine("7. Logout\n");

            Console.WriteLine("Enter 0 if you wish to go back to the previous page\n");
            return InputControl.VerifyChoice("PRODUCTS PAGE");
        }

        internal static string DisplayProductPage(string Type, P0Context DB)
        {
            string NextPage = "QUIT";
            int i = 1;
            List<Product> Products = DB.Products.ToList();
            List<Product> ProductsOfType = new List<Product>();
            foreach (Product p in Products)
            {
                if (p.Type == Type)
                {
                    Console.WriteLine($"\nProduct {i}:");
                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Price: {p.Price}");
                    Console.WriteLine($"Description: {p.Description}");
                    ProductsOfType.Add(p);
                    i++;
                }
            }
            i--;
            int j;
            bool isInt;
            Console.WriteLine("\nEnter a number to add a product to your cart or enter 0 to go back");
            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out j);
                if (!isInt || (j < 0 || j > i))
                {
                    Console.WriteLine($"\nYou must enter a number between 0 and {i}");
                }
            } while (!isInt && (j < 0 && j > i));

            j--;
            if (j == -1)
            {
                NextPage = "GO BACK";
            }
            else
            {
                Product ProductToBuy = ProductsOfType[j];
                DB.TempShoppingCart.Add(ProductToBuy);
                NextPage = "LOCATIONS WITH PRODUCT";
            }
            return NextPage;
        }

        internal static string DisplayLocationsWithProduct(P0Context DB)
        {
            string NextPage = "";
            LocationProductsDAO.LoadLocationProductsList(DB);
            int i = 1;
            foreach (LocationProducts p in DB.LocationProductsList)
            {
                if (DB.TempShoppingCart[0].ProductID == p.ProductID)
                {
                    Console.WriteLine($"\nStore {i}:" +
                        $"\n{p.Location.AddressNum} {p.Location.AddressStreet} " +
                        $"\n{p.Location.AddressCity}, {p.Location.AddressState} {p.Location.AddressState}");
                    i++;
                }
            }
            return NextPage;
        }
    }
}
