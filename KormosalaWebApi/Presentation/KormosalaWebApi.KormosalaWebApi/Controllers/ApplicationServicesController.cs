using KormosalaWebApi.Application.Abstractions.Services.ConfigurationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {

        private readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoint()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoint(typeof(Program));
            return Ok(datas);
        }
    }
}
