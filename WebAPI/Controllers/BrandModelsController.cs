using Application.Features.BrandModels.Models;
using Application.Features.BrandModels.Queries.GetListBrandModel;
using Application.Features.BrandModels.Queries.GetListBrandModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandModelsController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
          GetListBrandModelQuery getListBrandModelQuery= new GetListBrandModelQuery { PageRequest=pageRequest};
            BrandModelListModel result = await Mediator.Send(getListBrandModelQuery);
            return Ok(result);
        }
        [HttpPost("ByDynamic")]
        public async Task<IActionResult> GetAllByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBrandModelByDynamicQuery getListBrandModelByDynamicQuery =
                new GetListBrandModelByDynamicQuery { PageRequest=pageRequest,Dynamic=dynamic };
            BrandModelListModel brandModelListModel= await Mediator.Send(getListBrandModelByDynamicQuery);
            return Ok(brandModelListModel);
        }
    }
}
