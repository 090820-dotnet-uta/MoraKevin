using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using P1.Models;

namespace P1
{
    public static class Storage
    {
        private static Customer customer;
        private static Location location;
        private static ProductInStock ProductToBuy;
        private static List<ProductInStock> ShoppingCart;
        private static Product product;
        private static ProductInStock ProductEditing;
        private static Billing CardUsing;
        private static Shipping Addy;
        private static Order Order;

        public static void Clean()
        {
            location = null;
            ProductToBuy = null;
            ShoppingCart = null;
            product = null;
            ProductEditing = null;
            CardUsing = null;
            Addy = null;
            Order = null;
        }

        public static void CleanAfterOrder()
        {
            ProductToBuy = null;
            ShoppingCart = null;
            product = null;
            ProductEditing = null;
            CardUsing = null;
            Addy = null;
            Order = null;
        }


        public static Product GetProduct()
        {
            return product;
        }

        public static void SetProduct(Product p)
        {
            product = p;
        }

        public static Shipping WhatsTheAddy()
        {
            return Addy;
        }

        public static void SetAddy(Shipping address)
        {
            Addy = address;
        }

        public static Billing GetCardUsing()
        {
            return CardUsing;
        }

        public static void SetCardUsing(Billing b)
        {
            CardUsing = b;
        }

        public static ProductInStock GetProductEditing()
        {
            return ProductEditing;
        }

        public static void SetProductEditing(ProductInStock p)
        {
            ProductEditing = p;
        }

        public static List<ProductInStock> GetShoppingCart()
        {
            if(ShoppingCart == null)
            {
                ShoppingCart = new List<ProductInStock>();
            }
            return ShoppingCart;
        }

        public static void SetShoppingCart(List<ProductInStock> sc)
        {
            ShoppingCart = sc;
        }

        public static bool ShoppingCartHas(ProductInStock ps)
        {
            bool contains = false;
            if(ShoppingCart != null)
            {
                foreach(ProductInStock productInStock in ShoppingCart)
                {
                    if (productInStock.ProductID == ps.ProductID)
                    {
                        contains = true;
                    }
                }
            }
            return contains;
        }

        public static ProductInStock GetFromCart(int ID)
        {
            ProductInStock prodInStock = new ProductInStock();
            foreach (ProductInStock ps in ShoppingCart)
            {
                if (ps.ProductID == ID)
                {
                    prodInStock = ps;
                    break;
                }
            }
            return prodInStock;
        }

        public static void ChangeQuantity(int quantity)
        {
            for (int i = 0; i < ShoppingCart.Count; i++)
            {
                if(ShoppingCart[i].ProductID == ProductEditing.ProductID)
                {
                    ProductInStock productEdited = ProductEditing;
                    productEdited.Quantity = quantity;
                    ShoppingCart[i] = productEdited;
                    break;
                }
            }
            /*ProductInStock productEdited = ProductEditing;
            productEdited.Quantity = quantity;
            ShoppingCart.Add(productEdited);
            ShoppingCart.Remove(ProductEditing);*/
        }

        public static void DeleteProductInCart(int ID)
        {
            if(ShoppingCart.Count == 1)
            {
                ShoppingCart = null;
            }
            else
            {
                ProductInStock p = GetFromCart(ID);
                ShoppingCart.Remove(p);
            }
        }

        public static Customer GetCustomer()
        {
            return customer;
        }

        public static void SetCustomer(Customer c)
        {
            customer = c;
        }

        public static Location GetLocation()
        {
            return location;
        }

        public static void SetLocation(Location l)
        {
            location = l;
        }

        public static ProductInStock GetProductToBuy()
        {
            return ProductToBuy;
        }

        public static void SetProductToBuy(ProductInStock p)
        {
            ProductToBuy = p;
        }

        public static void SetOrderDetails()
        {
            Order = new Order()
            {
                Customer = customer,
                Location = location,
                Billing = CardUsing,
                Shipping = Addy,
                ShoppingCart = ShoppingCart
            };
        }

        public static Order GetOrder()
        {
            return Order;
        }

    }
}
