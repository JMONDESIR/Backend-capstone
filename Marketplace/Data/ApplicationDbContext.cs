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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Helps with the navigation between object of the two classes
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>()
                .HasOne<User>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);


            User User = new User
            {
                FirstName = "Jim",
                LastName = "Bean",
                UserName = "JimBean",
                NormalizedUserName = "jim@jimbean.com",
                Email = "jim@jimbean.com.com",
                NormalizedEmail = "jim@jimbean.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-aaaa-bbbb-cccc-dddddddddddd"
            };
            var passwordHash = new PasswordHasher<User>();
            User.PasswordHash = passwordHash.HashPassword(User, "Password!@690");
            modelBuilder.Entity<User>().HasData(User);

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

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    CategoryId = 3,
                    StatusId = 2,
                    SellerId = User.Id,
                    Description = "1.75 liter bottle of Triple distilled Irish whiskey. Great for first time whiskey tasters.",
                    Title = "Jameson Irish Whiskey",
                    ListPrice = 50.00
                },
                new Item()
                {
                    ItemId = 2,
                    CategoryId = 1,
                    StatusId = 1,
                    SellerId = User.Id,
                    Description = "The classic, fast-paced, wheelin' & dealin, property trading board game. I bought this back in 1990, now I'm passing it to you.",
                    Title = "Monopoly",
                    ListPrice = 150.00
                },
                new Item()
                {
                    ItemId = 3,
                    CategoryId = 2,
                    StatusId = 1,
                    SellerId = User.Id,
                    Description = "A deluxe padded seat with adjustable backrest and adjustable foot pegs, this kayak is a great choice for touring lazy rivers or doing some exploration on smaller lakes. Must sell to make room in my garage.",
                    Title = "Perception Conduit 13.0 Kayak",
                    ListPrice = 400.00
                }

            );
        }
    }
}
