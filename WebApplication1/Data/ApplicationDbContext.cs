using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clerks> Clerks { get; set; }
        public DbSet<DeliveryPeople> DeliveryPeople { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Customers> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clerks>().ToTable("Clerks");
            modelBuilder.Entity<DeliveryPeople>().ToTable("DeliveryPeople");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
            modelBuilder.Entity<Drinks>().ToTable("Drinks");
            modelBuilder.Entity<Customers>().ToTable("Customers");

            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Customer).WithMany(b => b.ListOrders);
            modelBuilder.Entity<Orders>().HasOne(p => p.Clerk).WithMany(b => b.ListOrders);
            modelBuilder.Entity<Orders>().HasOne(p => p.DeliveryPerson).WithMany(b => b.ListOrders);

        }


        public DbSet<WebApplication1.Models.ModelVueOrders>? ModelVueOrders { get; set; }


        public DbSet<WebApplication1.Models.ModelVueDrinks>? ModelVueDrinks { get; set; }


        public DbSet<WebApplication1.Models.ModelVuePizza>? ModelVuePizza { get; set; }


        public DbSet<WebApplication1.Models.ModelVueDeliveryPeople>? ModelVueDeliveryPeople { get; set; }


        public DbSet<WebApplication1.Models.ModelVueClerks>? ModelVueClerks { get; set; }


        public DbSet<WebApplication1.Models.ModelVueCustomers>? ModelVueCustomers { get; set; }
    }

}