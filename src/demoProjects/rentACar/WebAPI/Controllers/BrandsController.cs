using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandEntityCommand createBrandEntityCommand)
        {
            CreatedBrandEntityDto createdBrandEntityDto = await Mediator.Send(createBrandEntityCommand);
            return Created("", createdBrandEntityDto);
        }
    }
}
