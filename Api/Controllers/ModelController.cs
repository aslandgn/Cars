using Cars.Business.Interfaces;
using Cars.Entity.Dtos.Model;
using Cars.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController<Model, ModelDto, int>
    {
        private readonly IModelService _modelService;
        public ModelController(IService<Model, int> service, IModelService modelService) : base(service)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ModelAdd entityDto)
        {
            return RestResponse(await _modelService.AddModelAsync(entityDto));
        }

        [HttpGet("GetModelsOfBrand")]
        public async Task<IActionResult> GetModelsOfBrandAsync([FromQuery] int brandId)
        {
            return RestResponse(await _modelService.GetModelsOfBrandAsync(brandId));
        }
    }
}
