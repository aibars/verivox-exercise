using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.Models;
using Verivox.Logic.Interface;
using Verivox.Providers.Interface;
using Xunit;

namespace Verivox.Logic.Tests
{
    public class ConsumptionLogicTest
    {
        private readonly IConsumptionLogic _consumptionLogic;
        private readonly Mock<IDatabaseProvider> _databaseProvider;

        public ConsumptionLogicTest()
        {
            _databaseProvider = new Mock<IDatabaseProvider>(); 
            _consumptionLogic = new ConsumptionLogic(_databaseProvider.Object);
        }

        [Fact]
        public async Task GetAllConsumptionsComparisonsTest()
        {
            var consumptions = new List<Consumption> {
                 new Consumption { Id = new Guid("{3F3CF52A-52DE-4FDA-BE3C-99168B01E36F}"), Value = 3500, ReadDate = DateTime.UtcNow },
                 new Consumption { Id = new Guid("{C36154B3-BBF5-4DC5-8291-3B2B816081F3}"), Value = 4500, ReadDate = DateTime.UtcNow },
                 new Consumption { Id = new Guid("{6C4C002E-FC16-43A9-807E-FEDD44649BC4}"), Value = 6000, ReadDate = DateTime.UtcNow }
                };

            _databaseProvider.Setup(x => x.GetConsumptions()).Returns(Task.FromResult(consumptions));

            var results = await _consumptionLogic.GetAllConsumptionsComparisons();

            Assert.NotNull(results);
            Assert.Equal(6, results.Count);
            Assert.Equal(800, results[0].AnnualCost);
            Assert.Equal(830, results[1].AnnualCost);
            Assert.Equal(950, results[2].AnnualCost);
            Assert.Equal(1050, results[3].AnnualCost);
            Assert.Equal(1380, results[4].AnnualCost);
            Assert.Equal(1400, results[5].AnnualCost);
        }

        [Fact]
        public void GetProductsComparisonTest()
        {
            var results = _consumptionLogic.GetProductsComparison(10);

            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
            Assert.Equal(62.2m, results[0].AnnualCost);
            Assert.Equal(800, results[1].AnnualCost);
        }
    }
}
