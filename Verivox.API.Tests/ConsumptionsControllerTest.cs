using System;
using System.Collections.Generic;
using System.Text;
using GenFu;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Verivox.Providers.Interface;
using AutoMapper;
using Verivox.Domain.ApiModels.Response;
using Verivox.Domain.Models;
using Verivox.API.Controllers;

namespace Verivox.API.Tests
{
   public class ConsumptionsControllerTest
    {
        [Fact]
        public void WhenGetMessagesReturnsAll()
        {
            // Arrange
            var service = new Mock<IDatabaseProvider>();
            var mapper = new Mock<IMapper>();

            var values = GetFakeData();
            service.Setup(x => x.GetConsumptions()).Returns(Task.FromResult(values));
            var models = GetModels();
            mapper.Setup(m => m.Map<List<ConsumptionModel>>(It.IsAny<List<Consumption>>())).Returns(models);
            var controller = new ConsumptionsController(service.Object, mapper.Object);

            // Act
            var results = controller.GetConsumptions().Result;

            var count = results.Count();

            // Assert
            Assert.Equal(26, count);
        }

        private List<Consumption> GetFakeData()
        {
            var values = A.ListOf<Consumption>(26);
            values.ForEach(y => y.Id = Guid.NewGuid());
            return values.Select(_ => _).ToList();
        }

        private List<ConsumptionModel> GetModels()
        {
            var models = A.ListOf<ConsumptionModel>(26);
            return models.Select(_ => _).ToList();
        }
    }
}