using Cars.Business.Interfaces;
using Cars.Entity.Dtos.TransmissionType;
using Cars.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionTypeController : BaseController<TransmissionType, TransmissionTypeDto, short>
    {
        public TransmissionTypeController(IService<TransmissionType, short> service) : base(service)
        {
        }
    }
}
