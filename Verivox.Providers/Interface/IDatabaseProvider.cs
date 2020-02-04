using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Request;
using Verivox.Domain.Models;

namespace Verivox.Providers.Interface
{
    public interface IDatabaseProvider
    {
        Task<ApplicationUser> GetUser(string username);

        Task SaveProduct(ProductModel model);

        Task SaveConsumption(decimal value);

        Task<List<Consumption>> GetConsumptions();
    }
}