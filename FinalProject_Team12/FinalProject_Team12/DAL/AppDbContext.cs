using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using FinalProject_Team12.Models;

namespace FinalProject_Team12.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
    }
}