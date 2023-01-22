using AutoMapper;
using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Dal.Interfaces;
using Cars.Entity.Dtos.Version;

namespace Cars.Business.Concrates
{
    public class VersionManager : IVersionService
    {
        private readonly IVersionDalService _versionDalService;
        private readonly IMapper _mapper;

        public VersionManager(IMapper mapper, IVersionDalService versionDalService)
        {
            _mapper = mapper;
            _versionDalService = versionDalService;
        }

        public async Task<ServiceResponse<List<VersionDto>>> GetVersionsOfModelAsync(int modelId)
        {
            var versions = await _versionDalService.GetVersionsOfModelAsync(modelId);
            var versionDtos = _mapper.Map<List<VersionDto>>(versions);
            return ServiceResponse<List<VersionDto>>.Ok(versionDtos);
        }
    }
}
