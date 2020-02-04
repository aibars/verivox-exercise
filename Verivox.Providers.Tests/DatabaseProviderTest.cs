using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Verivox.Domain.Data;
using Xunit;

namespace Verivox.Providers.Tests
{
    public class DatabaseProviderTest : IDisposable
    {
        private readonly DatabaseProvider _databaseProvider;
        private readonly ApplicationDbContext _context;

        public DatabaseProviderTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "temp")
                      .Options;
            _context = new ApplicationDbContext(options);

            _databaseProvider = new DatabaseProvider(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public void GetUserTest()
        {
            // Arrange
            _context.Users.AddRange(FakeData.GetUsers());
            _context.SaveChanges();
            var username = _context.Users.First().UserName;

            // Act
            var result = _databaseProvider.GetUser(username).Result;

            // Assert
            Assert.Equal(username, result.UserName);
        }

        [Fact]
        public void GetConsumptionsTest()
        {
            // Arrange
            var consumptions = FakeData.GetConsumptions();
            _context.Consumptions.AddRange(consumptions);
            _context.SaveChanges();

            // Act
            var result = _databaseProvider.GetConsumptions().Result;

            // Assert
            Assert.Equal(result.Count, consumptions.Count);
        }

        [Fact]
        public async Task SaveConsumptionTest()
        {
            // Act
            await _databaseProvider.SaveConsumption(1);
            var result = _context.Consumptions.First();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public async Task SaveProductTest()
        {
            // Act
            await _databaseProvider.SaveProduct(new Domain.ApiModels.Request.ProductModel
            {
                TariffName = "test"
            });
            var result = _context.Products.First();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test", result.TariffName);
        }
    }
}
