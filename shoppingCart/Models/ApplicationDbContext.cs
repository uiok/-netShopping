using shoppingCart.Models.Customers;
using shoppingCart.Models.Discounts;
using shoppingCart.Models.News;
using shoppingCart.Models.Order;
using shoppingCart.Models.Product;
using shoppingCart.Models.WebsiteSettings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shoppingCart.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerLevel> CustomerLevel { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<CouponCode> CouponCode { get; set; }

        public DbSet<Discount> Discount { get; set; }

        public DbSet<DiscountUsedHistory> DiscountUsedHistory { get; set; }

        public DbSet<NewsComment> NewsComment { get; set; }

        public DbSet<Orders> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<PaymentHistory> PaymentHistory { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductDetail> ProductDetail { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<WebsiteSetting> WebsiteSetting { get; set; }

        


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}