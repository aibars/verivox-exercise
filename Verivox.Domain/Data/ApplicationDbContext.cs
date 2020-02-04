using Verivox.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Verivox.Domain.Data
{
    /// <summary>
    /// EF Context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                  new Product { Id = new Guid("{93EF10BB-24CC-43D7-BBA8-06C8647B96AE}"), TariffName = "Base Electricity Tariff" },
                  new Product { Id = new Guid("{1065E7F9-F433-49D5-B4EE-46FFDCCF8962}"), TariffName = "Packages Tariff" }
               );

            builder.Entity<Consumption>().HasData(
                new Consumption { Id = new Guid("{3F3CF52A-52DE-4FDA-BE3C-99168B01E36F}"), Value = 3500, ReadDate = DateTime.UtcNow },
                new Consumption { Id = new Guid("{C36154B3-BBF5-4DC5-8291-3B2B816081F3}"), Value = 4500, ReadDate = DateTime.UtcNow },
                new Consumption { Id = new Guid("{6C4C002E-FC16-43A9-807E-FEDD44649BC4}"), Value = 6000, ReadDate = DateTime.UtcNow });
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Consumption> Consumptions { get; set; }
    }
}