using Cars.Business.Interfaces;
using Cars.Entity.Dtos.Version;
using Microsoft.AspNetCore.Mvc;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : BaseController<Version, VersionDto, int>
    {
        private readonly IVersionService _versionService;
        public VersionController(IService<Version, int> service, IVersionService versionService) : base(service)
        {
            _versionService = versionService;
        }


        [HttpGet("GetVersionsOfModel")]
        public async Task<IActionResult> GetVersionsOfModelAsync([FromQuery] int modelId)
        {
            return RestResponse(await _versionService.GetVersionsOfModelAsync(modelId));
        }
    }
}
