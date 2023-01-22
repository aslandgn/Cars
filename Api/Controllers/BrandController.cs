using Cars.Business.Interfaces;
using Cars.Entity.Dtos.Brand;
using Cars.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController<Brand, BrandDto, int>
    {
        IService<Brand, int> _service;
        public BrandController(IService<Brand, int> service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrandsAsync()
        {
            return RestResponse(await _service.GetListAsync<BrandDto>());
        }
    }
}
