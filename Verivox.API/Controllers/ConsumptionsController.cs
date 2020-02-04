using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Response;
using Verivox.Providers.Interface;

namespace Verivox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsumptionsController : ControllerBase
    {
        protected readonly IDatabaseProvider _databaseProvider;
        protected readonly IMapper _mapper;

        public ConsumptionsController(IDatabaseProvider databaseProvider, IMapper mapper)
        {
            _databaseProvider = databaseProvider;
            _mapper = mapper;
        }

        public async Task<List<ConsumptionModel>> GetConsumptions()
        {
            var consumptions =  await _databaseProvider.GetConsumptions();

            return _mapper.Map<List<ConsumptionModel>>(consumptions);
        }
    }
}
