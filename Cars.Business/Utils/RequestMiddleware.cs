using Microsoft.AspNetCore.Http;
using Serilog;

namespace Cars.Business.Utils
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                await _next(httpContext);
                Log.Information("başarılı @e", httpContext);
            }
            catch (Exception e)
            {
                Log.Error("hata",e);
                throw;
            }
        }
    }
}
