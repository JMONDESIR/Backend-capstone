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
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
