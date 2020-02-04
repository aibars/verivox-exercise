using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.ApiModels.Request;
using Verivox.Domain.ApiModels.Response;
using Verivox.Logic.Interface;
using Verivox.Providers.Interface;

namespace Verivox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        protected readonly IDatabaseProvider _databaseProvider;
        protected readonly IConsumptionLogic _consumptionLogic;
        protected readonly IMapper _mapper;

        public ProductsController(IDatabaseProvider databaseProvider, IMapper mapper, IConsumptionLogic consumptionLogic)
        {
            _databaseProvider = databaseProvider;
            _mapper = mapper;
            _consumptionLogic = consumptionLogic;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody]ProductModel model)
        {
            await _databaseProvider.SaveProduct(model);
            return Ok();
        }

        [HttpGet]
        [Route("compare/all")]
        public async Task<List<ConsumptionCompareModel>> GetAllProductsComparison()
        {
            return await _consumptionLogic.GetAllConsumptionsComparisons();
        }

        [HttpGet]
        [Route("compare")]
        public List<ConsumptionCompareModel> GetProductsComparison([FromQuery]decimal consumption)
        {
            return _consumptionLogic.GetProductsComparison(consumption);
        }
    }
}
