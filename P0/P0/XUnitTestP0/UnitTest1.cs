using System;
using Xunit;
using P0;
using P0.Models;
using P0.DAOs;
using P0.Utilities;

namespace XUnitTestP0
{
    public class UnitTest1
    {
        [Fact]
        public void CreateAccountShouldAdd1UserAccount()
        {
            UserAccount U = new UserAccount
            {
                Username = "44sGod",
                Password = "stillTippin"
            };

            Customer C = new Customer
            {
                FirstName = "Paul",
                LastName = "Wall"
            };

            int numC;
            int numU;
            int nC;
            int nU;

            using (var DB = new P0Context())
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                CustomerDAO.LoadCustomersList(DB);
                numU = DB.UserAccountsList.Count;
                numC = DB.CustomersList.Count;
            }

            DatabaseControl.RegisterAccount(U, C);

            using (var DB = new P0Context())
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                CustomerDAO.LoadCustomersList(DB);
                nU = DB.UserAccountsList.Count - 1;
                nC = DB.CustomersList.Count - 1;
            }

            Assert.Equal(numU, nU);
        }

        [Fact]
        public void CreateAccountShouldAdd1Customer()
        {
            UserAccount U = new UserAccount
            {
                Username = "slimthugga",
                Password = "h-tine"
            };

            Customer C = new Customer
            {
                FirstName = "Statyve",
                LastName = "Thomas"
            };

            int numC;
            int numU;
            int nC;
            int nU;

            using (var DB = new P0Context())
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                CustomerDAO.LoadCustomersList(DB);
                numU = DB.UserAccountsList.Count;
                numC = DB.CustomersList.Count;
            }

            DatabaseControl.RegisterAccount(U, C);

            using (var DB = new P0Context())
            {
                UserAccountDAO.LoadUserAccountsList(DB);
                CustomerDAO.LoadCustomersList(DB);
                nU = DB.UserAccountsList.Count - 1;
                nC = DB.CustomersList.Count - 1;
            }

            Assert.Equal(numC, nU);
        }
    }
}
