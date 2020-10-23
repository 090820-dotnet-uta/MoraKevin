using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;

namespace P0
{
    public class P0Context : DbContext
    {
        // DBSET<TENTITY> for each class used
        public DbSet<Billing> BillingInformation { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBilling> CustomersBilling { get; set; }
        public DbSet<CustomerShipping> CustomersShipping { get; set; }
        public DbSet<DefaultLocation> DefaultLocations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationProducts> LocationProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipping> ShippingInformation{ get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        // LIST PROPERTIES FOR EACH CLASS USED
        public List<Billing> BillingInformationList { get; set; }
        public List<Customer> CustomersList { get; set; }
        public List<CustomerBilling> CustomerBillingList { get; set; }
        public List<CustomerShipping> CustomerShippingList { get; set; }
        public List<DefaultLocation> DefaultLocationList { get; set; }
        public List<Location> LocationList { get; set; }
        public List<LocationProducts> LocationProductsList { get; set; }
        public List<Order> OrdersList { get; set; }
        public List<OrderProducts> OrderProductsList { get; set; }
        public List<Product> ProductsList { get; set; }
        public List<Shipping> ShippingInformationList { get; set; }
        public List<UserAccount> UserAccountsList { get; set; }
        public List<Product> ShoppingCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=kevinmora.database.windows.net;Initial Catalog=P1;User ID=kevinmora;Password=GdypKK27!!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
