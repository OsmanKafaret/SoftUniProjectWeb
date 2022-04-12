using EnduroStore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnduroStore.Data
{
    public class EnduroStoreDbContext : IdentityDbContext<User>
    {
        public EnduroStoreDbContext(DbContextOptions<EnduroStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<UserOrderHistory> UserOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            base.OnModelCreating(modelBuilder);
      
            modelBuilder.Entity<UserOrderHistory>()
                .HasKey(x => x.Id);
      
        }

    }
}
