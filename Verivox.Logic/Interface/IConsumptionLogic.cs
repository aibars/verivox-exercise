using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Response;

namespace Verivox.Logic.Interface
{
    public interface IConsumptionLogic
    {
        List<ConsumptionCompareModel> GetProductsComparison(decimal consumption);

        Task<List<ConsumptionCompareModel>> GetAllConsumptionsComparisons();
    }
}
