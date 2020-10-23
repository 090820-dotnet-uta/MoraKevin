using System;
using Xunit;
using P1;
using P1.Models;
using SQLitePCL;
using System.Threading;

namespace P1_xUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void UserAccountExists_ReturnsFalse()
        {
            using (var _context = new P1Context()) 
            {
                /*DatabaseControl.SetContext(context);*/
                UserAccount account = new UserAccount
                {
                    Username = "fail",
                    Password = "fail"
                };
                bool exists = DatabaseControl.AccountExists(account, _context);
                Assert.False(exists);
            }
        }

        [Fact]
        public void UserAccountExists_ReturnsTrue()
        {
            using (var _context = new P1Context())
            {
                /*DatabaseControl.SetContext(context);*/
                UserAccount account = new UserAccount
                {
                    Username = "kmora",
                    Password = "data1"
                };
                bool exists = DatabaseControl.AccountExists(account, _context);

                Assert.True(exists);
            }
        }

       [Fact]
        public void CustomerExists_ReturnsTrue()
        {
            using (var _context = new P1Context())
            {
                /*DatabaseControl.SetContext(context);*/
                Customer customer = new Customer
                {
                    FirstName = "Kevin",
                    LastName = "Mora"
                };
                bool exists = DatabaseControl.CustomerExists(customer, _context);

                Assert.True(exists);
            }
        }

        [Fact]
        public void CustomerExists_ReturnsFalse()
        {
            using (var _context = new P1Context())
            {
                /*DatabaseControl.SetContext(context);*/
                Customer customer = new Customer
                {
                    FirstName = "Thomas",
                    LastName = "Brown"
                };
                bool exists = DatabaseControl.CustomerExists(customer, _context);

                Assert.False(exists);
            }
        }

        [Fact]
        public void GetCardReturns_CorrectCard()
        {
            using (var _context = new P1Context())
            {
                string CardNumber = "4634653646346466";
                Billing card = DatabaseControl.GetCard(1, _context);
                string cardNum = card.CardNumber;
                Assert.Equal(cardNum, CardNumber);
            }
        }

        [Fact]
        public void GetLocationReturns_CorrectLocation()
        {
            using (var _context = new P1Context())
            {
                string storeName = "Wavey Davey's";
                Location store = DatabaseControl.GetLocation(3, _context);
                string name = store.Name;
                Assert.Equal(storeName, name);
            }
        }

        [Fact]
        public void GetShippingReturns_CorrectAddress()
        {
            using (var _context = new P1Context())
            {
                int num = 8301;
                string street = "Melrose St";
                string city = "Houston";
                string state = "TX";
                string zip = "77022";

                Shipping address = DatabaseControl.GetAddress(1, _context);

                int numA = address.AddressNum;
                string streetA = address.AddressStreet;
                string cityA = address.AddressCity;
                string stateA = address.AddressState;
                string zipA = address.AddressZipCode;

                Assert.Equal(num, numA);
                Assert.Equal(street, streetA);
                Assert.Equal(city, cityA);
                Assert.Equal(state, stateA);
                Assert.Equal(zip, zipA);
            }
        }
    }
}
