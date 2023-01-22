using Cars.Business.Interfaces;
using Cars.Entity.Dtos.Spesification;
using Cars.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpesificationController : BaseController<Spesification, SpesificationDto, int>
    {
        private readonly ISpesificationService _spesificationService;
        public SpesificationController(IService<Spesification, int> service, ISpesificationService spesificationService) : base(service)
        {
            _spesificationService = spesificationService;
        }
    }
}
