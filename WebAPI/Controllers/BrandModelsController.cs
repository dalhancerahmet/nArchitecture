using Application.Features.BrandModels.Models;
using Application.Features.BrandModels.Queries.GetListBrandModel;
using Core.Application.Requests;
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
          GetListBrandModelQuery getListBrandModelQuery= new GetListBrandModelQuery { PageRequest = pageRequest };
            BrandModelListModel result = await Mediator.Send(getListBrandModelQuery);
            return Ok(result);
        }
    }
}
