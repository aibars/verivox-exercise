using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Request;
using Verivox.Domain.Data;
using Verivox.Domain.Models;
using Verivox.Providers.Interface;

namespace Verivox.Providers
{
    /// <summary>
    /// Methods for accessing the database
    /// </summary>
    public class DatabaseProvider : IDatabaseProvider
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IConfiguration _configuration;

        public DatabaseProvider(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtains a user by username
        /// </summary>
        public async Task<ApplicationUser> GetUser(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task SaveProduct(ProductModel model)
        {
            try
            {
                _context.Products.Add(new Product
                {
                    TariffName = model.TariffName
                });

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error creating product", ex);
            }
        }

        public async Task SaveConsumption(decimal value)
        {
            try
            {
                _context.Consumptions.Add(new Consumption
                {
                    Value = value,
                    ReadDate = DateTime.UtcNow,
                });

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error adding consumption", ex);
            }
        }

        public async Task<List<Consumption>> GetConsumptions()
        {
            return await _context.Consumptions.ToListAsync();
        }
    }
}
