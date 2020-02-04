using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Response;
using Verivox.Logic.Interface;
using Verivox.Providers.Interface;

namespace Verivox.Logic
{
    public class ConsumptionLogic : IConsumptionLogic
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ConsumptionLogic(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<ConsumptionCompareModel>> GetAllConsumptionsComparisons()
        {
            var consumptions = await _databaseProvider.GetConsumptions();

            var results = new List<ConsumptionCompareModel>();

            foreach (var c in consumptions)
            {
                results.Add(new ConsumptionCompareModel { AnnualCost = CalculateProductA(c.Value), TariffName = Domain.Constants.Tariffs.ProductA });
                results.Add(new ConsumptionCompareModel { AnnualCost = CalculateProductB(c.Value), TariffName = Domain.Constants.Tariffs.ProductB });
            }

            return results.OrderBy(x => x.AnnualCost).ToList();
        }

        public List<ConsumptionCompareModel> GetProductsComparison(decimal consumption)
        {
            var results = new List<ConsumptionCompareModel> {
               new ConsumptionCompareModel
               {
                   AnnualCost = CalculateProductA(consumption),
                   TariffName = Domain.Constants.Tariffs.ProductA
               },
                new ConsumptionCompareModel
               {
                   AnnualCost = CalculateProductB(consumption),
                   TariffName = Domain.Constants.Tariffs.ProductB
               },
            };

            return results.OrderBy(x => x.AnnualCost).ToList();
        }


        private decimal CalculateProductA(decimal consumption)
        {
            // 5€ * 12 Months = 60
            // 0.22 € Consumption Cost
            return 60 + consumption * 0.22m;
        }

        private decimal CalculateProductB(decimal consumption)
        {
            // 800€ up to 4000 KWh/year
            // Above 4000 KWh/year additionally 0.3€
            return consumption < 4000 ? 800m : 800 + ((consumption - 4000) * 0.3m);
        }
    }
}