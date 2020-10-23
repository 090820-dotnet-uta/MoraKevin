using System;
using System.Threading;
using P1.DAOs;
using P1.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Data;

namespace P1
{
    public class DatabaseControl
    {
        /*private static P1Context _context;
        public static void SetContext(P1Context context)
        {
            _context = context;
        }*/
        /// <summary>
        /// Creates a new entries in the Customers Table and UserAccounts Table for new Users
        /// </summary>
        /// <param name="Account"></param>
        public static void RegisterAccount(UserAccount Account, Customer c, P1Context _context)
        {

            var DB = _context;
            CustomerDAO.AddCustomer(c, DB);
            Account.Customer = c;
            UserAccountDAO.AddUserAccount(Account, DB);
        }

        public static bool CustomerExists(Customer customer, P1Context _context)
        {
            bool exists = false;
            List<Customer> customers = new List<Customer>();
            var DB = _context;
            CustomerDAO.LoadCustomersList(DB);
            customers = DB.CustomersList.Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName).ToList();
            if (customers.Count > 0)
            {
                exists = true;
            }
            return exists;
        }

        internal static List<Customer> CustomersWithName(Customer customer, P1Context _context)
        {

            List<Customer> customers = new List<Customer>();
            var DB = _context;
            CustomerDAO.LoadCustomersList(DB);
            customers = DB.CustomersList.Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName).ToList();
            return customers;
        }

        internal static List<UserAccount> Accounts(List<Customer> customers, P1Context _context)
        {
            List<UserAccount> accounts = new List<UserAccount>();
            var DB = _context;
            foreach (Customer c in customers)
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                UserAccount a = DB.UserAccountsList.First(u => u.CustomerID == c.CustomerID);
                a.Customer = c;
                accounts.Add(a);
            }
            return accounts;
        }

        public static bool AccountExists(UserAccount Account, P1Context _context)
        {
            bool exists;
            var DB = _context;
            UserAccountDAO.LoadUserAccountsList(DB);
            exists = DB.UserAccountsList.Any(a => a.Username == Account.Username);
            return exists;
        }

        public static bool AccountExists(string username, P1Context _context)
        {
            bool exists;
            var DB = _context;
            UserAccountDAO.LoadUserAccountsList(DB);
            exists = DB.UserAccountsList.Any(a => a.Username == username);
            return exists;
        }

        /// <summary>
        /// Fetches information about the Customer based on their Account Information
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>A reference to the Current Customer</returns>
        internal static Customer GetCurrentCustomer(UserAccount Account, P1Context _context)
        {
            Customer CurrentCustomer;
            var DB = _context;
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
            return CurrentCustomer;
        }

        /// <summary>
        /// Takes in the Login Information and verifies that the user exits
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>True if user exists, false if username or password doesn't match</returns>
        internal static bool LoginSuccesful(UserAccount Account, P1Context _context)
        {
            bool success = false;
            var DB = _context;
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
            return success;
        }

        /*internal static List<Customer> GetAllCustomers(P1Context _context)
        {
            List<Customer> CustomerList = new List<Customer>();
            var DB = _context;
            CustomerDAO.LoadCustomersList(DB);
            CustomerList = DB.CustomersList;
            return CustomerList;
        }

        internal static List<Product> GetAllProducts(P1Context _context)
        {
            List<Product> ProductList;
            var DB = _context;
            ProductDAO.LoadProductsList(DB);
            ProductList = DB.ProductsList;
            return ProductList;
        }*/

        internal static ProductInStock GetProductInStock(int id, Location location, P1Context _context)
        {
            int max = FindNumInStockAtLocation(id, location, _context);
            Product p = GetProduct(id, _context);
            ProductInStock productInStock = new ProductInStock
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Price = p.Price,
                Type = p.Type,
                Description = p.Description,
                Max = max,
                Store = location
            };
            return productInStock;
        }

        internal static List<Product> GetAllProductsOfType(string type, P1Context _context)
        {
            List<Product> ProductList = new List<Product>();
            var DB = _context;
            ProductDAO.LoadProductsList(DB);
            foreach (Product p in DB.ProductsList)
            {
                if (p.Type == type)
                {
                    ProductList.Add(p);
                }
            }
            return ProductList;
        }

        /*internal static List<Location> GetAllLocations(P1Context _context)
        {
            List<Location> LocationList;
            var DB = _context;
            LocationDAO.LoadLocationsList(DB);
            LocationList = DB.LocationList;
            return LocationList;
        }*/

        public static Location GetLocation(int LocationID, P1Context _context)
        {
            Location location = new Location();
            var DB = _context;
            LocationDAO.LoadLocationsList(DB);
            foreach (Location l in DB.LocationList)
            {
                if (l.LocationID == LocationID)
                {
                    location = l;
                    break;
                }
            }
            return location;
        }

        public static Shipping GetAddress(int ShippingID, P1Context _context)
        {
            Shipping addy = new Shipping();
            var DB = _context;
            ShippingDAO.LoadShippingInfomrationList(DB);
            foreach (Shipping a in DB.ShippingInformationList)
            {
                if (a.ShippingID == ShippingID)
                {
                    addy = a;
                    break;
                }
            }
            return addy;
        }

        public static Billing GetCard(int BillingID, P1Context _context)
        {
            Billing card = new Billing();
            var DB = _context;
            BillingDAO.LoadBillingList(DB);
            foreach (Billing b in DB.BillingInformationList)
            {
                if (b.BillingID == BillingID)
                {
                    card = b;
                    break;
                }
            }
            return card;
        }

        /*internal static Location GetOrderLocation(Order o, P1Context _context)
        {
            Location Location;
            var DB = _context;
            LocationDAO.LoadLocationsList(DB);
            Location = DB.LocationList.First(l => l.LocationID == o.LocationID);
            return Location;
        }

        internal static List<int> FindLocationIDsWithProduct(Product ProductToBuy, P1Context _context)
        {
            List<int> LocationIDs = new List<int>();
            var DB = _context;
            LocationProductsDAO.LoadLocationProductsList(DB);
            foreach (LocationProducts lp in DB.LocationProductsList)
            {
                if (ProductToBuy.ProductID == lp.ProductID)
                {
                    LocationIDs.Add(lp.LocationID);
                }
            }
            return LocationIDs;
        }*/

        internal static List<Location> FindLocationsWithProduct(int ProductID, P1Context _context)
        {
            List<int> LocationIDs = new List<int>();
            var DB = _context;
            LocationProductsDAO.LoadLocationProductsList(DB);
            foreach (LocationProducts lp in DB.LocationProductsList)
            {
                if (ProductID == lp.ProductID)
                {
                    LocationIDs.Add(lp.LocationID);
                }
            }
            List<Location> StoreOptions = FindLocationsWithProduct(LocationIDs, _context);
            return StoreOptions;
        }

        internal static List<Location> FindLocationsWithProduct(Product ProductToBuy, List<int> LocationIDs, P1Context _context)
        {
            List<Location> StoreOptions = new List<Location>();

            var DB = _context;
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
            return StoreOptions;
        }

        internal static Product GetProduct(int ID, P1Context _context)
        {
            Product product = new Product();
            var DB = _context;
            ProductDAO.LoadProductsList(DB);
            foreach (Product p in DB.ProductsList)
            {
                if (p.ProductID == ID)
                {
                    product = p;
                    break;
                }
            }
            return product;
        }

        internal static List<Location> FindLocationsWithProduct(List<int> LocationIDs, P1Context _context)
        {
            List<Location> StoreOptions = new List<Location>();

            var DB = _context;
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
            return StoreOptions;
        }

        internal static List<ProductInStock> GetProductsInStockAtLocation(List<Product> Products, Location Location, P1Context _context)
        {
            List<ProductInStock> prodsInStock = new List<ProductInStock>();
            foreach(Product p in Products)
            {
                int max = FindNumInStockAtLocation(p, Location, _context);
                ProductInStock prodInStock = new ProductInStock
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Price = p.Price,
                    Type = p.Type,
                    Description = p.Description,
                    Store = Location,
                    Max = max
                };
                prodsInStock.Add(prodInStock);
            }
            return prodsInStock;

        }

        internal static int FindNumInStockAtLocation(Product ProductToBuy, Location CurrentLocation, P1Context _context)
        {
            int InStock = 0;
            var DB = _context;
            LocationProductsDAO.LoadLocationProductsList(DB);
            foreach (LocationProducts LP in DB.LocationProductsList)
            {
                if (LP.LocationID == CurrentLocation.LocationID && LP.ProductID == ProductToBuy.ProductID)
                {
                    InStock = LP.Inventory;
                    break;
                }
            }
            return InStock;
        }

        internal static int FindNumInStockAtLocation(int ProductID, Location CurrentLocation, P1Context _context)
        {
            int InStock = 0;
            var DB = _context;
            LocationProductsDAO.LoadLocationProductsList(DB);
            foreach (LocationProducts LP in DB.LocationProductsList)
            {
                if (LP.LocationID == CurrentLocation.LocationID && LP.ProductID == ProductID)
                {
                    InStock = LP.Inventory;
                    break;
                }
            }
            return InStock;
        }

        internal static List<Product> FindProductsOfTypeFromStore(string Type, Location CurrentLocation, P1Context _context)
        {
            List<Product> ProductsOfType = new List<Product>();

            var DB = _context;
            ProductDAO.LoadProductsList(DB);
            LocationProductsDAO.LoadLocationProductsList(DB);

            foreach (LocationProducts lp in DB.LocationProductsList)
            {
                if (lp.LocationID == CurrentLocation.LocationID)
                {
                    foreach (Product p in DB.ProductsList)
                    {
                        if (p.Type == Type && lp.ProductID == p.ProductID)
                        {
                            ProductsOfType.Add(p);
                        }
                    }
                }
            }
            return ProductsOfType;
        }

        internal static void AddNewCardInformationToUser(Billing CardInfoEntered, Customer CurrentCustomer, P1Context _context)
        {
            var DB = _context;
            BillingDAO.AddBilling(CardInfoEntered, DB);
            CustomerBilling CB = new CustomerBilling
            {
                CustomerID = CurrentCustomer.CustomerID,
                BillingID = CardInfoEntered.BillingID
            };
            CustomerBillingDAO.AddCustomerBilling(CB, DB);
        }

        internal static void AddNewShippingInformationToUser(Shipping address, Customer customer, P1Context _context)
        {
            var DB = _context;
            ShippingDAO.AddShippingInformation(address, DB);
            CustomerShipping CS = new CustomerShipping
            {
                CustomerID = customer.CustomerID,
                ShippingID = address.ShippingID
            };
            CustomerShippingDAO.AddCustomerShipping(CS, DB);
        }

        internal static void AddNewShippingInformationToUser(Billing card, Customer customer, P1Context _context)
        {
            Shipping S = new Shipping
            {
                AddressNum = card.AddressNum,
                AddressStreet = card.AddressStreet,
                AddressCity = card.AddressCity,
                AddressState = card.AddressState,
                AddressZipCode = card.AddressZipCode,
                
            };
            var DB = _context;
            ShippingDAO.AddShippingInformation(S, DB);
            CustomerShipping CS = new CustomerShipping
            {
                CustomerID = customer.CustomerID,
                ShippingID = S.ShippingID
            };
            CustomerShippingDAO.AddCustomerShipping(CS, DB);
        }

        internal static List<Shipping> GetShippingAddresssesOnFileForCustomer(Customer customer, P1Context _context)
        {
            List<Shipping> ships = new List<Shipping>();
            var DB = _context;
            CustomerShippingDAO.LoadCustomersShippingList(DB);
            ShippingDAO.LoadShippingInfomrationList(DB);

            foreach (CustomerShipping cs in DB.CustomerShippingList)
            {
                if (cs.CustomerID == customer.CustomerID)
                {
                    foreach (Shipping s in DB.ShippingInformationList)
                    {
                        if (cs.ShippingID == s.ShippingID)
                        {
                            ships.Add(s);
                        }
                    }
                }
            }
            return ships;
        }

        internal static List<Billing> GetCardsOnFileForCustomer(Customer CurrentCustomer, P1Context _context)
        {
            List<Billing> CardOptions = new List<Billing>();

            var DB = _context;
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
            return CardOptions;
        }

        internal static void UpdateQuantity(Product p, int quanity, Location location, P1Context _context)
        {
            var DB = _context;
            LocationProductsDAO.LoadLocationProductsList(DB);
            foreach (LocationProducts lp in DB.LocationProductsList)
            {
                if (lp.LocationID == location.LocationID && lp.ProductID == p.ProductID)
                {
                    lp.Inventory -= quanity;
                    LocationProductsDAO.UpdateLocationProducts(lp, DB);
                    break;
                }
            }
        }

        internal static List<Order> GetOrdersInfoFromLocation(Location CurrentLocation, P1Context _context)
        {
            List<Order> OrdersFromLocation = new List<Order>();

            var DB = _context;
            OrderDAO.LoadOrdersList(DB);
            OrderProductsDAO.LoadOrderProductsList(DB);
            ProductDAO.LoadProductsList(DB);
            CustomerDAO.LoadCustomersList(DB);
            BillingDAO.LoadBillingList(DB);
            ShippingDAO.LoadShippingInfomrationList(DB);

            OrdersFromLocation = DB.OrdersList.Where(o => o.LocationID == CurrentLocation.LocationID).ToList();

            for (int i = 0; i < OrdersFromLocation.Count; i++)
            {
                Order o = OrdersFromLocation[i];

                List<ProductInStock> prodsOrdered = new List<ProductInStock>();

                List<OrderProducts> prodIDsAndQuantityInOrder = DB.OrderProductsList.Where(op => op.OrderID == OrdersFromLocation[i].OrderID).ToList();
                foreach (OrderProducts OP in prodIDsAndQuantityInOrder)
                {
                    ProductInStock prodOrdered = new ProductInStock();
                    Product p = DB.ProductsList.First(p => p.ProductID == OP.ProductID);
                    prodOrdered.Name = p.Name;
                    prodOrdered.Price = p.Price;
                    prodOrdered.Description = p.Description;
                    prodOrdered.Quantity = OP.Quantity;
                    prodsOrdered.Add(prodOrdered);
                }

                o.ShoppingCart = prodsOrdered;

                o.Billing = DB.BillingInformationList.First(b => b.BillingID == OrdersFromLocation[i].BillingID);

                o.Shipping = DB.ShippingInformation.First(s => s.ShippingID == OrdersFromLocation[i].ShippingID);

                o.Customer = DB.CustomersList.First(c => c.CustomerID == OrdersFromLocation[i].CustomerID);

                OrdersFromLocation[i] = o;
            }
            return OrdersFromLocation;
        }

        internal static List<Order> GetPastOrdersFromCustomer(Customer customer, P1Context _context)
        {
            List<Order> OrdersByCustomer = new List<Order>();

            var DB = _context;
            OrderDAO.LoadOrdersList(DB);
            OrderProductsDAO.LoadOrderProductsList(DB);
            ProductDAO.LoadProductsList(DB);
            LocationDAO.LoadLocationsList(DB);
            BillingDAO.LoadBillingList(DB);
            CustomerDAO.LoadCustomersList(DB);
            ShippingDAO.LoadShippingInfomrationList(DB);

            OrdersByCustomer = DB.OrdersList.Where(o => o.CustomerID == customer.CustomerID).ToList();

            for (int i = 0; i < OrdersByCustomer.Count; i++)
            {
                Order o = OrdersByCustomer[i];

                List<ProductInStock> prodsOrdered = new List<ProductInStock>();

                List<OrderProducts> prodIDsAndQuantityInOrder = DB.OrderProductsList.Where(op => op.OrderID == OrdersByCustomer[i].OrderID).ToList();
                foreach (OrderProducts OP in prodIDsAndQuantityInOrder)
                {
                    ProductInStock prodOrdered = new ProductInStock();
                    Product p = DB.ProductsList.First(p => p.ProductID == OP.ProductID);
                    prodOrdered.Name = p.Name;
                    prodOrdered.Price = p.Price;
                    prodOrdered.Description = p.Description;
                    prodOrdered.Quantity = OP.Quantity;
                    prodsOrdered.Add(prodOrdered);
                }

                o.ShoppingCart = prodsOrdered;

                o.Billing = DB.BillingInformationList.First(b => b.BillingID == OrdersByCustomer[i].BillingID);

                o.Shipping = DB.ShippingInformation.First(s => s.ShippingID == OrdersByCustomer[i].ShippingID);

                o.Location = DB.LocationList.First(l => l.LocationID == OrdersByCustomer[i].LocationID);

                o.Customer = DB.CustomersList.First(c => c.CustomerID == OrdersByCustomer[i].CustomerID);

                OrdersByCustomer[i] = o;
            }
            return OrdersByCustomer;
        }

        internal static Order GetOrder(int ID, bool inStore, P1Context _context)
        {
            Order order = new Order();
            if (inStore)
            {
                List<Order> orders = GetOrdersInfoFromLocation(Storage.GetLocation(), _context);
                foreach (Order o in orders)
                {
                    if (o.OrderID == ID)
                    {
                        order = o;
                        break;
                    }
                }
                order.Location = Storage.GetLocation();
            }
            else
            {
                List<Order> orders = GetPastOrdersFromCustomer(Storage.GetCustomer(), _context);
                foreach (Order o in orders)
                {
                    if (o.OrderID == ID)
                    {
                        order = o;
                        break;
                    }
                }
            }
            return order;
        }

        internal static void PlaceOrder(List<ProductInStock> ShoppingCart, Billing BillingInfo, Shipping ShippingInfo, Customer CurrentCustomer, Location CurrentLocation, P1Context _context)
        {
            DateTime now = System.DateTime.Now;
            var DB = _context;
            Order Order = new Order
            {
                CustomerID = CurrentCustomer.CustomerID,
                LocationID = CurrentLocation.LocationID,
                BillingID = BillingInfo.BillingID,
                ShippingID = ShippingInfo.ShippingID,
                OrderTime = now.ToString()

            };
            OrderDAO.AddOrders(Order, DB);
            LocationProductsDAO.LoadLocationProductsList(DB);

            foreach (ProductInStock p in ShoppingCart)
            {
                OrderProducts OP = new OrderProducts
                {
                    OrderID = Order.OrderID,
                    ProductID = p.ProductID,
                    Quantity = p.Quantity
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
