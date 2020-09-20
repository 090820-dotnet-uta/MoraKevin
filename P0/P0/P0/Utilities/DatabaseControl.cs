using System;
using System.Threading;
using P0.DAOs;
using P0.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P0.Utilities
{
    class DatabaseControl
    {
        internal static void CreateAccount(UserAccount Account, P0Context DB)
        {

            Console.WriteLine("\nFirst Name:");
            string fn = Console.ReadLine();
            Console.WriteLine("\nLast Name:");
            string ln = Console.ReadLine();

            Customer c = new Customer
            {
                FirstName = fn,
                LastName = ln
            };

            CustomerDAO.AddCustomer(c, DB);
            Account.Customer = c;
            UserAccountDAO.AddUserAccount(Account, DB);
        }
        internal static void SaveAccountToCustomerList(UserAccount Account, P0Context DB)
        {
            UserAccountDAO.LoadUserAccountsList(DB);

            Customer customer = new Customer();

            foreach (UserAccount a in DB.UserAccountsList)
            {
                if (Account.Username == a.Username && Account.Password == a.Password)
                {
                    customer.CustomerID = Account.CustomerID;
                    break;
                }
            }
            foreach (Customer c in DB.Customers.ToList())
                {
                    if(customer.CustomerID == c.CustomerID)
                    {
                        customer.FirstName = c.FirstName;
                        customer.LastName = c.LastName;
                        break;
                    }
                }
            DB.CustomersList = new List<Customer>();
            DB.CustomersList.Add(customer);
        }
        internal static bool LoginSuccesful(UserAccount Account, P0Context DB)
        {
            bool success = false;
            UserAccountDAO.LoadUserAccountsList(DB);

            foreach (UserAccount a in DB.UserAccountsList)
            {
                if(Account.Username == a.Username && Account.Password == a.Password)
                {
                    Account.CustomerID = a.CustomerID;
                    success = true;
                    break;
                }
            }
            return success;
        }
    }
}
