using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Marketplace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Helps with the navigation between object of the two classes
            base.OnModelCreating(modelBuilder);

            User User = new User
            {
                FirstName = "Jim",
                LastName = "Bean",
                UserName = "JimB",
                NormalizedUserName = "jim@jimbean.com",
                Email = "jim@jimbean.com.com",
                NormalizedEmail = "jim@jimbean.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-aaaa-bbbb-cccc-dddddddddddd"
            };
            var passwordHash = new PasswordHasher<User>();
            User.PasswordHash = passwordHash.HashPassword(User, "PAssword!@690");
            modelBuilder.Entity<User>().HasData(User);

            User User1 = new User
            {
                FirstName = "Jack",
                LastName = "Daniels",
                UserName = "jackD",
                NormalizedUserName = "jack@jackdaniels.com",
                Email = "jack@jackdaniels.com.com",
                NormalizedEmail = "jack@jackdaniels.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                Id = "11111111-aaaa-bbbb-cccc-dddddddddddd"
            };
            var passwordHash1 = new PasswordHasher<User>();
            User1.PasswordHash = passwordHash1.HashPassword(User1, "PAssword!@690");
            modelBuilder.Entity<User>().HasData(User1);

            modelBuilder.Entity<Status>().HasData(
               new Status()
               {
                   StatusId = 1,
                   ListStatus = "Active"
               },
               new Status()
               {
                    StatusId = 2,
                    ListStatus = "Inactive"
               },
               new Status()
               {
                    StatusId = 3,
                    ListStatus = "Sold"
               }
);
            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   CategoryId = 1,
                   Label = "Toys/Games"
               },
               new Category()
               {
                   CategoryId = 2,
                   Label = "Sporting Goods"
               },
               new Category()
               {
                   CategoryId = 3,
                   Label = "Miscellaneous"
               }
);
            modelBuilder.Entity<Bid>().HasData(
               new Bid()
               {
                   BidId = 1,
                   ItemId = 1,
                   UserId = "11111111-aaaa-bbbb-cccc-dddddddddddd",
                   Offer = 420.00,
                   Comment = "I've been looking for one of these! Can we bargain?"
               }
 );
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    CategoryId = 1,
                    Description = "Classic Game with real gold and silver pieces.  1 of only 50 ever made.",
                    ListPrice = 500.00,
                    SellerId = "00000000-aaaa-bbbb-cccc-dddddddddddd",
                    StatusId = 1,
                    Title = "Monopoly Gold Edition"
                }
);

        }
    }
}
