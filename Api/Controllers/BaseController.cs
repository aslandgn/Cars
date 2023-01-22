using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Brand;
using Cars.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cars.Api.Controllers
{
    public abstract class BaseController<T, TResult, N> : ControllerBase where T : BaseWithId<N>
    {
        private readonly IService<T, N> _service;

        protected BaseController(IService<T, N> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] N id)
        {
            return RestResponse(await _service.GetAsync<TResult>(x => x.Id.Equals(id)));
        }

        protected IActionResult RestResponse<R>(ServiceResponse<R> serviceResponse)
        {
            return serviceResponse.StatusCode switch
            {
                HttpStatusCode.OK => Ok(serviceResponse),
                HttpStatusCode.BadRequest => BadRequest(serviceResponse),
                HttpStatusCode.NotFound => NotFound(serviceResponse),
                _ => Ok(serviceResponse),
            };
        }
    }
}
