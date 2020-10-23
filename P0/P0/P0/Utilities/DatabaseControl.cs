using System;
using System.Threading;
using P0.DAOs;
using P0.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Data;

namespace P0.Utilities
{
    public class DatabaseControl
    {
        /// <summary>
        /// Creates a new entries in the Customers Table and UserAccounts Table for new Users
        /// </summary>
        /// <param name="Account"></param>
        public static void RegisterAccount(UserAccount Account, Customer c)
        {

            using (var DB = new P0Context())
            {
                CustomerDAO.AddCustomer(c, DB);
                Account.Customer = c;
                UserAccountDAO.AddUserAccount(Account, DB);
            }
        }



        /// <summary>
        /// Fetches information about the Customer based on their Account Information
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>A reference to the Current Customer</returns>
        internal static Customer GetCurrentCustomer(UserAccount Account)
        {
            Customer CurrentCustomer;
            using (var DB = new P0Context())
            {
                Customer customer = new Customer();

                UserAccountDAO.LoadUserAccountsList(DB);
                foreach (UserAccount a in DB.UserAccountsList)
                {
                    if (Account.Username == a.Username && Account.Password == a.Password)
                    {
                        customer.CustomerID = Account.CustomerID;
                        break;
                    }
                }

                CustomerDAO.LoadCustomersList(DB);
                foreach (Customer c in DB.CustomersList)
                {
                    if (customer.CustomerID == c.CustomerID)
                    {
                        customer.FirstName = c.FirstName;
                        customer.LastName = c.LastName;
                        break;
                    }
                }
                CurrentCustomer = customer;
            }
            return CurrentCustomer;
        }



        /// <summary>
        /// Takes in the Login Information and verifies that the user exits
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>True if user exists, false if username or password doesn't match</returns>
        internal static bool LoginSuccesful(UserAccount Account)
        {
            bool success = false;
            using (var DB = new P0Context())
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                foreach (UserAccount a in DB.UserAccountsList)
                {
                    if (Account.Username == a.Username && Account.Password == a.Password)
                    {
                        Account.CustomerID = a.CustomerID;
                        success = true;
                        break;
                    }
                }
            }
            return success;
        }

        internal static List<Customer> GetAllCustomers()
        {
            List<Customer> CustomerList = new List<Customer>();
            using (var DB = new P0Context())
            {
                CustomerDAO.LoadCustomersList(DB);
                CustomerList = DB.CustomersList;
            }
            return CustomerList;
        }

        internal static List<Product> GetAllProducts()
        {
            List<Product> ProductList;
            using (var DB = new P0Context())
            {
                ProductDAO.LoadProductsList(DB);
                ProductList = DB.ProductsList;
            }
            return ProductList;
        }

        internal static List<Location> GetAllLocations()
        {
            List<Location> LocationList;
            using (var DB = new P0Context())
            {
                LocationDAO.LoadLocationsList(DB);
                LocationList = DB.LocationList;
            }
            return LocationList;
        }

        internal static Location GetOrderLocation(Order o)
        {
            Location Location;
            using (var DB = new P0Context())
            {
                LocationDAO.LoadLocationsList(DB);
                Location = DB.LocationList.First(l => l.LocationID == o.LocationID);
            }
            return Location;
        }

        internal static List<int> FindLocationIDsWithProduct(Product ProductToBuy)
        {
            List<int> LocationIDs = new List<int>();
            using (var DB = new P0Context())
            {
                LocationProductsDAO.LoadLocationProductsList(DB);
                foreach (LocationProducts lp in DB.LocationProductsList)
                {
                    if (ProductToBuy.ProductID == lp.ProductID)
                    {
                        LocationIDs.Add(lp.LocationID);
                    }
                }
            }
            return LocationIDs;
        }

        internal static List<Location> FindLocationsWithProduct(Product ProductToBuy, List<int> LocationIDs)
        {
            List<Location> StoreOptions = new List<Location>();

            using(var DB = new P0Context())
            {
                LocationDAO.LoadLocationsList(DB);
                foreach (int LocationID in LocationIDs)
                {
                    foreach (Location l in DB.LocationList)
                    {
                        if (LocationID == l.LocationID)
                        {
                            StoreOptions.Add(l);
                        }
                    }
                }
            }
            return StoreOptions;
        }

        internal static int FindNumInStockAtLocation(Product ProductToBuy, Location CurrentLocation)
        {
            int InStock = 0;
            using (var DB = new P0Context())
            {
                LocationProductsDAO.LoadLocationProductsList(DB);
                foreach(LocationProducts LP in DB.LocationProductsList)
                {
                    if(LP.LocationID == CurrentLocation.LocationID && LP.ProductID == ProductToBuy.ProductID)
                    {
                        InStock = LP.Inventory;
                        break;
                    }
                }
            }
                return InStock;
        }

        internal static List<Product> FindProductsOfTypeFromStore(string Type, Location CurrentLocation)
        {
            List<Product> ProductsOfType = new List<Product>();

            using (var DB = new P0Context())
            {
                ProductDAO.LoadProductsList(DB);
                LocationProductsDAO.LoadLocationProductsList(DB);

                foreach (LocationProducts lp in DB.LocationProductsList)
                {
                    if (lp.LocationID == CurrentLocation.LocationID)
                    {
                        foreach (Product p in DB.ProductsList)
                        {
                            if (p.Type + " FROM STORE" == Type && lp.ProductID == p.ProductID)
                            {
                                ProductsOfType.Add(p);
                            }
                        }
                    }
                }
            }
            return ProductsOfType;
        }

        internal static void AddNewCardInformationToUser(Billing CardInfoEntered, Customer CurrentCustomer)
        {
            using (var DB = new P0Context())
            {
                BillingDAO.AddBilling(CardInfoEntered, DB);
                CustomerBilling CB = new CustomerBilling
                {
                    CustomerID = CurrentCustomer.CustomerID,
                    BillingID = CardInfoEntered.BillingID
                };
                CustomerBillingDAO.AddCustomerBilling(CB, DB);
            }
        }

        internal static List<Billing> GetCardsOnFileForCustomer(Customer CurrentCustomer)
        {
            List<Billing> CardOptions = new List<Billing>();

            using (var DB = new P0Context())
            {
                CustomerBillingDAO.LoadCustomersBillingList(DB);
                BillingDAO.LoadBillingList(DB);

                foreach (CustomerBilling cb in DB.CustomerBillingList)
                {
                    if (cb.CustomerID == CurrentCustomer.CustomerID)
                    {
                        foreach (Billing b in DB.BillingInformationList)
                        {
                            if (cb.BillingID == b.BillingID)
                                CardOptions.Add(b);
                        }
                    }
                }
            }
            return CardOptions;
        }

        internal static (List<Order>, List<List<OrderProducts>>, List<List<Product>>) GetOrdersInfo(Customer CurrentCustomer)
        {
            List<Order> OrdersByCustomer = new List<Order>();
            List<List<OrderProducts>> OPs = new List<List<OrderProducts>>();
            List<List<Product>> PIOs = new List<List<Product>>();

            using (var DB = new P0Context())
            {
                OrderDAO.LoadOrdersList(DB);
                OrdersByCustomer = DB.OrdersList.Where(o => o.CustomerID == CurrentCustomer.CustomerID).ToList();
                OrderProductsDAO.LoadOrderProductsList(DB);
                foreach (Order order in OrdersByCustomer)
                {
                    List<OrderProducts> OrderProducts = DB.OrderProductsList.Where(o => o.OrderID == order.OrderID).ToList();
                    OPs.Add(OrderProducts);
                }
                ProductDAO.LoadProductsList(DB);
                foreach (List<OrderProducts> ops in OPs)
                {
                    List<Product> ProductsInOrder = new List<Product>();
                    foreach (OrderProducts op in ops)
                    {
                        Product p = DB.ProductsList.First(p => p.ProductID == op.ProductID);
                        ProductsInOrder.Add(p);
                    }
                    PIOs.Add(ProductsInOrder);
                }
            }
            return (OrdersByCustomer, OPs, PIOs);
        }

        internal static (List<Order>, List<List<OrderProducts>>, List<List<Product>>) GetOrdersInfoFromLocation(Location CurrentLocation)
        {
            List<Order> OrdersFromLocation = new List<Order>();
            List<List<OrderProducts>> OPs = new List<List<OrderProducts>>();
            List<List<Product>> PIOs = new List<List<Product>>();

            using(var DB = new P0Context())
            {
                OrderDAO.LoadOrdersList(DB);
                OrdersFromLocation = DB.OrdersList.Where(o => o.LocationID == CurrentLocation.LocationID).ToList();
                OrderProductsDAO.LoadOrderProductsList(DB);
                foreach (Order order in OrdersFromLocation)
                {
                    List<OrderProducts> OrderProducts = DB.OrderProductsList.Where(o => o.OrderID == order.OrderID).ToList();
                    OPs.Add(OrderProducts);
                }
                ProductDAO.LoadProductsList(DB);
                foreach(List<OrderProducts> ops in OPs)
                {
                    List<Product> ProductsInOrder = new List<Product>();
                    foreach (OrderProducts op in ops)
                    {
                        Product p = DB.ProductsList.First(p => p.ProductID == op.ProductID);
                        ProductsInOrder.Add(p);
                    }
                    PIOs.Add(ProductsInOrder);
                }
            }
            return (OrdersFromLocation, OPs, PIOs);
        }

        internal static void PlaceOrder(List<Product> ShoppingCart, Billing BillingInfo, Customer CurrentCustomer, Location CurrentLocation, List<int> Quantities)
        {
            DateTime now = System.DateTime.Now;
            using (var DB = new P0Context())
            {
                Order Order = new Order
                {
                    CustomerID = CurrentCustomer.CustomerID,
                    LocationID = CurrentLocation.LocationID,
                    OrderTime = now.ToString()
                    
                };
                OrderDAO.AddOrders(Order, DB);
                LocationProductsDAO.LoadLocationProductsList(DB);
                foreach(Product p in ShoppingCart)
                {
                    int QuantityIndex = ShoppingCart.IndexOf(p);
                    OrderProducts OP = new OrderProducts
                    {
                        OrderID = Order.OrderID,
                        ProductID = p.ProductID,
                        Quantity = Quantities[QuantityIndex]
                    };
                    OrderProductsDAO.AddOrderProducts(OP, DB);
                    LocationProducts LP = DB.LocationProductsList.Single(
                        x => (x.LocationID == CurrentLocation.LocationID && x.ProductID == p.ProductID));
                    LP.Inventory -= OP.Quantity;
                    LocationProductsDAO.UpdateLocationProducts(LP, DB);
                }
            }
        }
    }
}
