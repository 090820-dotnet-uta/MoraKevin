using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P0.Models;
using P0.DAOs;
using System.Threading;
using System.Globalization;
using System.Security.Authentication;
using System.ComponentModel;
using Microsoft.IdentityModel.Protocols;
using System.Runtime.InteropServices;

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

        /// <summary>
        /// Displays the Welcome Page with options to Login, Register, or Quit, makes call to InputControl to
        /// get user's next choice.
        /// </summary>
        /// <returns>User's Next Choice</returns>
        internal static string DisplayWelcomePage()
        {
            Console.WriteLine("\n\n\t\t\tHello!");
            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("\n(1) Log In OR (2) Register OR (3) Quit");

            return InputControl.VerifyChoice("LOGIN REGISTER OR QUIT");
        }



        /// <summary>
        /// Makes calls to DisplayRegistation() page or DisplayLoginPage() based on users choice.
        /// Makes calls to DatabaseControl to store or verify the users information
        /// If user log in is invalid, method calls LoginFailed()
        /// If user selected to quit, method does nothing and passes control forward
        /// Otherwise, method sets the NextPage to 'CUSTOMER HOMEPAGE'
        /// </summary>
        /// <param name="UserChoice"></param>
        /// <returns>NextPage, CurrentCustomer</returns>
        internal static (string, Customer) DisplayLoginRegisterOrQuit(string UserChoice)
        {
            string NextPage = "CUSTOMER HOMEPAGE";
            Customer CurrentCustomer = new Customer();
            if (UserChoice == "REGISTER")
            {
                UserAccount Account = DisplayRegistrationPage();
                DatabaseControl.RegisterAccount(Account);
                CurrentCustomer = DatabaseControl.GetCurrentCustomer(Account);
            }
            else if (UserChoice == "LOG IN")
            {
                UserAccount Account = DisplayLoginPage();
                if (DatabaseControl.LoginSuccesful(Account))
                {
                    CurrentCustomer = DatabaseControl.GetCurrentCustomer(Account);
                }
                else
                {
                    NextPage = DisplayLoginFailed();
                }
            }
            else if (UserChoice == "QUIT")
            {
                NextPage = "QUIT";
            }
            return (NextPage, CurrentCustomer);
        }



        /// <summary>
        /// Displays the Registration Homepage and gets input from the user for a username and password
        /// Passes control back to DisplayLoginRegisterOrQuit()
        /// </summary>
        /// <returns>UserAccount</returns>
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



        /// <summary>
        /// Displays the Login Homepage and get input from the user for their username and password
        /// Passes control back to DisplayLoginRegisterOrQuit()
        /// </summary>
        /// <returns>UserAccount</returns>
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



        /// <summary>
        /// Alerts the user if login was unsuccesful asks, user to quit or try again
        /// Calls InputControl to get user's choice and passes control back to LoginRegisterOrQuit()
        /// </summary>
        /// <returns>NextPage</returns>
        private static string DisplayLoginFailed()
        {
            Console.WriteLine("\n\n-------------LOGIN FAILED---------------");
            Console.WriteLine("\n Would You like to (1) try again or (2) quit?");
            return InputControl.VerifyChoice("TRY AGAIN OR QUIT");
        }



        /// <summary>
        /// Diplays the Customers Homepage with various page options to select from
        /// Calls InputControl to get the NextPage
        /// </summary>
        /// <returns>NextPage</returns>
        internal static string DisplayCustomerHomePage(Customer CurrentCustomer)
        {
            Console.WriteLine($"\n-------------WELCOME {CurrentCustomer.FirstName.ToUpper()}----------------");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. View Store Locations");
            Console.WriteLine("3. View Past Orders");
            Console.WriteLine("4. View Customers");
            Console.WriteLine("5. Logout\n");
            return InputControl.VerifyChoice("CUSTOMER HOME PAGE");
        }


        
        /// <summary>
        /// Displays the Products Homepage with various product types to select from
        /// Calls InputControl to get the NextPage
        /// </summary>
        /// <returns>NextPage</returns>
        internal static string DisplayProductsHome()
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



        /// <summary>
        /// Calls DatabaseControl to GetAllProducts and Display those of the Type
        /// the user selected.
        /// Calls InputControl to get the users selection and returns directions for 
        /// the NextPage and the Product the user chose (ProductToBuy = null if user chose to go back)
        /// </summary>
        /// <param name="Type">NextPage, ProductToBuy</param>
        /// <returns></returns>
        internal static (string, Product) DisplayProductPage(string Type)
        {
            string NextPage = "GO BACK";
            Product ProductToBuy = null;

            int NumProducts = 1;

            List<Product> Products = DatabaseControl.GetAllProducts();
            List<Product> ProductsOfType = new List<Product>();

            foreach (Product p in Products)
            {
                if (p.Type == Type)
                {
                    Console.WriteLine($"\nProduct {NumProducts}:");
                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Price: {p.Price}");
                    Console.WriteLine($"Description: {p.Description}");
                    ProductsOfType.Add(p);
                    NumProducts++;
                }
            }
            NumProducts--;

            Console.WriteLine("\nEnter a number to add a product to your cart or enter 0 to go back");
            int choice = InputControl.VerifyListChoiceStartingAt0(NumProducts);

            if (choice != -1)
            {
                ProductToBuy = ProductsOfType[choice];
                NextPage = "LOCATIONS WITH PRODUCT";
            }
            return (NextPage, ProductToBuy);
        }



        /// <summary>
        /// Calls DatabaseControl to find the locationss that carry the chosen product
        /// and displays those to the user
        /// Calls InputControl to get the users store choice, or reroutes if there are no stores
        /// which currently sell the product selected
        /// </summary>
        /// <param name="ProductToBuy"></param>
        /// <returns>NextPage, CurrentLocation</returns>
        internal static (string, Location) DisplayLocationsWithProduct(Product ProductToBuy)
        {
            string NextPage = "GO BACK";
            Location CurrentLocation = null;

            List<int> LocationIDs = DatabaseControl.FindLocationIDsWithProduct(ProductToBuy);

            if (LocationIDs.Count() > 0)
            {
                Console.WriteLine("----------------------STORES---------------------------");
                Console.WriteLine("\nThe following stores currently have your item in stock:");
                
                List<Location> StoreOptions = DatabaseControl.FindLocationsWithProduct(ProductToBuy, LocationIDs);
                
                int NumStores = 1;
                foreach (Location l in StoreOptions)
                {
                    Console.WriteLine($"\n\nStore #{NumStores}" +
                        $"\n--------------{l.Name}--------------" +
                        $"\n{l.AddressNum} {l.AddressStreet} " +
                        $"\n{l.AddressCity}, {l.AddressState} {l.AddressZipCode}");
                    NumStores++;
                }
                Console.WriteLine("\nWhich store would you like to order from? Enter the store number to proceed");
                int choice = InputControl.VerifyListChoiceStartingAt1(NumStores);

                CurrentLocation = StoreOptions[choice];
                NextPage = "STORE HOMEPAGE";
            }
            else
            {
                Console.WriteLine("\n\n-----------------ERROR--------------------");
                Console.WriteLine("\nWe are sorry, no stores currently carry that product.");
                Console.WriteLine("\n---Routing you back to make another selection.---");
                Thread.Sleep(2000);
            }
            return (NextPage, CurrentLocation);
        }



        /// <summary>
        /// Calls DatabaseControl to get a list of Locations, Displays Locations
        /// Calls InputControl to get users choice of location or returing to Customer Homepage
        /// </summary>
        /// <returns>NextPage, CurrentLocation</returns>
        internal static (string, Location) DisplayStoreLocations()
        {
            Location CurrentLocation;
            string NextPage = "STORE HOMEPAGE";

            List<Location> Locations = DatabaseControl.GetAllLocations();

            Console.WriteLine("----------------------STORES---------------------------");
            int NumStores = 1;
            foreach (Location l in Locations)
            {
                Console.WriteLine($"\n\nStore #{NumStores}" +
                    $"\n--------------{l.Name}--------------" +
                    $"\n{l.AddressNum} {l.AddressStreet} " +
                    $"\n{l.AddressCity}, {l.AddressState} {l.AddressZipCode}");
                NumStores++;
            }
            Console.WriteLine("\nWhich store would you like to visit?" +
                "\nEnter the store number to proceed" +
                "\nEnter 0 to go back to the Customer Homepage");

            int choice = InputControl.VerifyListChoiceStartingAt0(NumStores);

            if (choice == -1)
            {
                NextPage = "CUSTOMER HOMEPAGE";
                CurrentLocation = null;
            }
            else
            {
                CurrentLocation = Locations[choice];
            }
            return (NextPage, CurrentLocation);
        }



        /// <summary>
        /// Displays options available in Store Homepage
        /// Calls InputControl to get the user's choice
        /// </summary>
        /// <param name="CurrentLocation"></param>
        /// <returns>NextPage</returns>
        internal static string DisplayStoreHomePage(Location CurrentLocation)
        {
            Console.WriteLine($"\n------------WELCOME-TO-{CurrentLocation.Name}--------------");
            Console.WriteLine($"\n{CurrentLocation.Description}");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. View Shopping Cart");
            Console.WriteLine("3. View Past Order From This Location");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Logout");

            Console.WriteLine("\nEnter 0 if you wish to go back to the Customer Home Page");
            Console.WriteLine("\nWARNING: Going back to the Customer Home Page will reset your Shopping Cart" +
                " (You can only order from one store at a time.)");
    
            return InputControl.VerifyChoiceLocationHome();
        }



        /// <summary>
        /// Displays A number of Product Options for a specific Store Location
        /// Calls InputControl for the users choice
        /// Adds ' FROM STORE' to string NextPage if choice is not go back or log out to conform to Program.cs while loop standards
        /// </summary>
        /// <param name="CurrentLocation"></param>
        /// <returns></returns>
        internal static string DisplayProductsAtStoreHome(Location CurrentLocation)
        {
            Console.WriteLine($"\n-------------{CurrentLocation.Name}----------------");
            Console.WriteLine("\nWhat kind of product are you looking for?");
            Console.WriteLine("\n1. Guitar");
            Console.WriteLine("2. Bass");
            Console.WriteLine("3. Drums");
            Console.WriteLine("4. Piano");
            Console.WriteLine("5. Microphones");
            Console.WriteLine("6. Accessories");
            Console.WriteLine("7. Logout\n");

            Console.WriteLine("Enter 0 if you wish to go back to the previous page\n");

            string NextPage = InputControl.VerifyChoice("PRODUCTS PAGE");

            if (NextPage != "GO BACK" && NextPage != "LOGOUT")
            {
                NextPage += " FROM STORE";
            }

            return NextPage;
        }



        /// <summary>
        /// Calls DatabaseControl to get a list of all Products of a specific type from a specific location
        /// Displays these products, Calls InputControl to get the user's choice
        /// If a product is selected, it is added to the Shopping Cart, and DisplayPostProductSelectionAtLocation() is called
        /// and returns the NextPage that the user chooses, which this method then returns to the while loop in Program.cs
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="CurrentLocation"></param>
        /// <param name="ShoppingCart"></param>
        /// <returns>NextPage, ShoppingCart</returns>
        internal static (string, List<Product>, List<int>) DisplayProductAtStore(string Type, Location CurrentLocation, List<Product> ShoppingCart, List<int> Quantities)
        {
            String NextPage;
            List<Product> ProductsOfType = DatabaseControl.FindProductsOfTypeFromStore(Type, CurrentLocation);
            if (ProductsOfType.Count > 0)
            {
                int NumStores = 1;
                foreach (Product p in ProductsOfType.ToList())
                {
                    Console.WriteLine($"\nProduct {NumStores}:");
                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Price: {p.Price}");
                    Console.WriteLine($"Description: {p.Description}");
                    ProductsOfType.Add(p);
                    NumStores++;
                }
                NumStores--;
                Console.WriteLine("\nEnter a number to add a product to your cart or enter 0 to go back");

                int choice = InputControl.VerifyListChoiceStartingAt0(NumStores);

                if (choice == -1)
                {
                    NextPage = "GO BACK";
                }
                else
                {
                    Product ProductToBuy = ProductsOfType[choice];
                    int Quantity = DisplayQuantityPrompt(ProductToBuy, CurrentLocation);
                    ShoppingCart.Add(ProductToBuy);
                    Quantities.Add(Quantity);
                    NextPage = DisplayPostProductSelectionAtLocation(ProductToBuy);
                }
            }
            else
            {
                Console.WriteLine("Oops! We are all out of those!");
                Thread.Sleep(1000);
                Console.WriteLine("\n-----ROUTING-YOU-BACK-TO-THE-PRODUCTS-HOMEPAGE-----");
                Thread.Sleep(1250);
                NextPage = "VIEW PRODUCTS AT STORE";
            }
            return (NextPage, ShoppingCart, Quantities);
        }


        internal static int DisplayQuantityPrompt(Product ProductToBuy, Location CurrentLocation)
        {
            int InStock = DatabaseControl.FindNumInStockAtLocation(ProductToBuy, CurrentLocation);
            Console.WriteLine($"\n{ProductToBuy.Name}");
            Console.WriteLine($"In stock: {InStock}");
            Console.WriteLine("\nEnter Quantity:");
            return InputControl.VerifyListChoiceStartingAt1(InStock) + 1;
        }

        /// <summary>
        /// Lets user know that product has been added to Shopping Cart
        /// Displays next page options for the user, Calls InputControl to get and verify choice
        /// Returns control to the DisplayProductAtStore() method, so that it knows where to point the user next
        /// </summary>
        /// <param name="ProductToBuy"></param>
        /// <returns>NextPage</returns>
        internal static string DisplayPostProductSelectionAtLocation(Product ProductToBuy)
        {
            Console.WriteLine($"\n{ProductToBuy.Name} has been added to your shopping cart!");
            Thread.Sleep(1500);
            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("1. Continue Shopping" +
                "\n2. View Shopping Cart" +
                "\n3. Checkout");

            return InputControl.VerifyPostProductSelectionChoice();
        }



        /// <summary>
        /// Takes in a bool "view" which tells the method if we are just viewing the shopping cart
        /// or attempting to checkout
        /// Display shopping cart and Total Cost of products, if there are no items in the shopping cart,
        /// method alerts user and automatically reroutes back to "STORE HOMEPAGE", 
        /// if JustViewing, User is routed back to "STORE HOMEPAGE" after any entry, if checking out,
        /// user is asked to verify that they want to checkout, calls InputControl to verify user's choice
        /// </summary>
        /// <param name="view"></param>
        /// <param name="ShoppingCart"></param>
        /// <returns>NextPage</returns>
        internal static string DisplayShoppingCart(bool JustViewing, List<Product> ShoppingCart, List<int> Quantites)
        {
            Console.WriteLine("\n---------------SHOPPING-CART----------------");
            string NextPage;
            if(ShoppingCart.Count() == 0)
            {
                Console.WriteLine("\nThere are currently no items in your shopping cart.");
                Thread.Sleep(1000);
                Console.WriteLine("\n-----ROUTING-YOU-BACK-TO-THE-STORE-HOMEPAGE-----");
                Thread.Sleep(1250);
                NextPage = "STORE HOMEPAGE";
            }
            else
            {
                int NumItems = 1;
                int Cost = 0;
                foreach (Product p in ShoppingCart)
                {
                    int Index = ShoppingCart.IndexOf(p);
                    Console.WriteLine($"\nItem {NumItems}:" +
                        $"\nName: {p.Name}" +
                        $"\nQuantity: {Quantites[Index]}" +
                        $"\nPrice: ${p.Price * Quantites[Index]}" +
                        $"\nDescription: {p.Description}");
                    NumItems++;
                    Cost += (p.Price * Quantites[Index]);
                }
                Console.WriteLine($"\nTotal Price: ${Cost}");
                if(JustViewing)
                {
                    Console.WriteLine("\nEnter any key to go back");
                    Console.ReadLine();
                    NextPage = "STORE HOMEPAGE";
                }
                else
                {
                    Console.WriteLine("\nAre you sure you want to checkout?");
                    Console.WriteLine("1. Yes" +
                        "\n2. No");
                    NextPage = InputControl.VerifyWantToCheckoutChoice();
                }
            }
            return NextPage;
        }

        internal static void DisplayPastOrders(Customer CurrentCustomer)
        {
            Console.WriteLine($"\n----PAST-ORDERS-FOR-{CurrentCustomer.FirstName}-{CurrentCustomer.LastName}----");
            List<Order> OrdersByCustomer;
            List<List<OrderProducts>> OPs;
            List<List<Product>> PIOs;

            (OrdersByCustomer, OPs, PIOs) = DatabaseControl.GetOrdersInfo(CurrentCustomer);

            if (OrdersByCustomer.Count == 0)
            {
                Console.WriteLine("\nThere are currently no orders placed!");
                Console.WriteLine("Hit any key to go back.");
                Console.ReadLine();

            }
            else
            {
                foreach (Order o in OrdersByCustomer)
                {
                    Location l = DatabaseControl.GetOrderLocation(o);
                    Console.WriteLine("\n---------------------------------------------------------------------");
                    Console.WriteLine($"Order #{o.OrderID} made from {l.Name} at {o.OrderTime}:");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    int NumItems = 1;
                    int Cost = 0;
                    int PIOIndex = OrdersByCustomer.IndexOf(o);
                    foreach (Product p in PIOs[PIOIndex])
                    {
                        int OPIndex = PIOs[PIOIndex].IndexOf(p);
                        Console.WriteLine($"\nItem {NumItems}:" +
                            $"\nName: {p.Name}" +
                            $"\nQuantity: {OPs[PIOIndex][OPIndex].Quantity}" +
                            $"\nPrice: ${p.Price * OPs[PIOIndex][OPIndex].Quantity}" +
                            $"\nDescription: {p.Description}");
                        NumItems++;
                        Cost += (p.Price * OPs[PIOIndex][OPIndex].Quantity);
                    }
                    Console.WriteLine($"Total Cost = ${Cost}");
                }
                Console.WriteLine("\nHit any key to go back.");
                Console.ReadLine();
            }
        }

        internal static void DisplayPastOrdersFromLocation(Location CurrentLocation)
        {
            Console.WriteLine($"\n--------{CurrentLocation.Name}-PAST-ORDERS---------");
            List<Order> OrdersFromHere;
            List<List<OrderProducts>> OPs;
            List<List<Product>> PIOs;

            (OrdersFromHere, OPs, PIOs) = DatabaseControl.GetOrdersInfoFromLocation(CurrentLocation);

            if (OrdersFromHere.Count == 0)
            {
                Console.WriteLine("\nThere are currently no orders placed from here!");
                Console.WriteLine("Hit any key to go back.");
                Console.ReadLine();

            }
            else
            {
                foreach (Order o in OrdersFromHere)
                {
                    Console.WriteLine("\n--------------------------------------------");
                    Console.WriteLine($"Order #{o.OrderID} made at {o.OrderTime}:");
                    Console.WriteLine("--------------------------------------------");
                    int NumItems = 1;
                    int Cost = 0;
                    int PIOIndex = OrdersFromHere.IndexOf(o);
                    foreach (Product p in PIOs[PIOIndex])
                    {
                        int OPIndex = PIOs[PIOIndex].IndexOf(p);
                        Console.WriteLine($"\nItem {NumItems}:" +
                            $"\nName: {p.Name}" +
                            $"\nQuantity: {OPs[PIOIndex][OPIndex].Quantity}" +
                            $"\nPrice: ${p.Price * OPs[PIOIndex][OPIndex].Quantity}" +
                            $"\nDescription: {p.Description}");
                        NumItems++;
                        Cost += (p.Price * OPs[PIOIndex][OPIndex].Quantity);
                    }
                    Console.WriteLine($"Total Cost = ${Cost}");
                }
                Console.WriteLine("\nHit any key to go back.");
                Console.ReadLine();
            }

        }

        internal static int DisplayCheckoutPrompt()
        {
            Console.WriteLine("\n---------------CHECKING-OUT----------------\n");
            Console.WriteLine("\nWould you like to:" +
                "\n1. Enter a card" +
                "\n2. Use an existing card");
            return InputControl.VerifyCheckoutHomeChoice();
        }

        internal static string DisplayCheckoutHome(List<Product> ShoppingCart, Customer CurrentCustomer, Location CurrentLocation, List<int> Quantities)
        {
            String NextPage = DisplayShoppingCart(false, ShoppingCart, Quantities);
            Billing CardChosen = null;
            if(NextPage == "CHECKOUT")
            {
                int choice = DisplayCheckoutPrompt();
                if (choice == 1)
                {
                    Billing CardInfoEntered = DisplayGetBillingInformation();
                    DatabaseControl.AddNewCardInformationToUser(CardInfoEntered, CurrentCustomer);
                    NextPage = DisplayConfirmOrder(ShoppingCart, CardInfoEntered, CurrentCustomer, CurrentLocation, Quantities);
                }
                else if (choice == 2)
                {
                    List<Billing> CardOptions = DatabaseControl.GetCardsOnFileForCustomer(CurrentCustomer);
                    if (CardOptions.Count() == 0)
                    {
                        Console.WriteLine("\nYou do not have a card saved on file!");
                        Console.WriteLine("\n---------ROUTING-YOU-BACK-TO-CHECKOUT----------");
                        Thread.Sleep(1000);
                        NextPage = "CHECKOUT";
                    }
                    else
                    {
                        int NumCards = DisplayCardsOnFile(CardOptions);
                        Console.WriteLine("\nEnter a number to choose a card or 0 to go back to the Store Homepage");
                        int pick = InputControl.VerifyListChoiceStartingAt0(NumCards);
                        if(pick == -1)
                        {
                            NextPage = "STORE HOMEPAGE";
                        }
                        else
                        {
                            CardChosen = CardOptions[pick];
                            NextPage = DisplayConfirmOrder(ShoppingCart, CardChosen, CurrentCustomer, CurrentLocation, Quantities);
                        }
                    }
                }
            }
            return NextPage;
        }

        internal static int DisplayCardsOnFile(List<Billing> CardOptions)
        {
            int NumCards = 1;
            foreach (Billing b in CardOptions)
            {
                Console.WriteLine($"\nCard {NumCards}:" +
                    $"\n Card Number: {b.CardNumber}" +
                    $"\n Card Expiration: {b.ExpirationMonth}/{b.ExpirationYear}" +
                    $"\n Name on Card: {b.NameOnCard}");

            }
            NumCards--;
            return NumCards;
        }

        internal static Billing DisplayGetBillingInformation()
        {
            Console.WriteLine("\nEnter Card Number:");
            string CardNum = Console.ReadLine();

            Console.WriteLine("\nEnter the Full Name on the Card");
            string CardName = Console.ReadLine();

            Console.WriteLine("\nEnter Card Month:");
            int.TryParse(Console.ReadLine(), out int CardMonth);

            Console.WriteLine("\nEnter Card Year:");
            int.TryParse(Console.ReadLine(), out int CardYear);

            Console.WriteLine("\nEnter Card Security Code: ");
            int.TryParse(Console.ReadLine(), out int SecurityCode);

            Console.WriteLine("\nEnter the Billing Address Number:");
            int.TryParse(Console.ReadLine(), out int AddNum);

            Console.WriteLine("\nEnter the Billing Address Street Name:");
            string StreetName = Console.ReadLine();

            Console.WriteLine("\nEnter the Billing Address City:");
            string City = Console.ReadLine();

            Console.WriteLine("\nEnter the Billing Address State:");
            string State = Console.ReadLine();

            Console.WriteLine("\nEnter Billing Address Zip Code: ");
            int.TryParse(Console.ReadLine(), out int ZipCode);

            Billing CardInfoEntered = new Billing
            {
                CardNumber = CardNum,
                NameOnCard = CardName,
                ExpirationMonth = CardMonth,
                ExpirationYear = CardYear,
                SecurityCode = SecurityCode,
                AddressNum = AddNum,
                AddressStreet = StreetName,
                AddressCity = City,
                AddressState = State,
                AddressZipCode = ZipCode
            };
            return CardInfoEntered;
        }


        internal static string DisplayConfirmOrder(List<Product> ShoppingCart, Billing BillingInfo, Customer CurrentCustomer, Location CurrrentLocation, List<int> Quantities)
        {
            string NextPage = DisplayShoppingCart(false, ShoppingCart, Quantities);
            if (NextPage == "CHECKOUT")
            {
                Console.WriteLine("\n------CONFIRMING-YOUR-ORDER-------------");
                DatabaseControl.PlaceOrder(ShoppingCart, BillingInfo, CurrentCustomer, CurrrentLocation, Quantities);
                Thread.Sleep(1000);
                Console.WriteLine("\n---------------YOUR-ORDER-HAS-BEEN-CONFIRMED---------------");
                Console.WriteLine("\n---------ROUTING-YOU-BACK-TO-THE-STORES-HOMEPAGE-----------");
                NextPage = "CUSTOMER HOMEPAGE";
            }
            return NextPage;
        }


        internal static void DisplayCustomers()
        {
            List<Customer> Customers = DatabaseControl.GetAllCustomers();
            int NumC = 1;
            Console.WriteLine("\n-----------------SHOWING-CUSTOMERS----------------");
            foreach(Customer c in Customers)
            {
                Console.WriteLine($"\nCustomer {NumC}:");
                Console.WriteLine($"First Name: {c.FirstName}");
                Console.WriteLine($"Last Name: {c.LastName}");
                NumC++;
            }
            Console.WriteLine("\nHit any key to go back.");
            Console.ReadLine();
        }
    }
}
