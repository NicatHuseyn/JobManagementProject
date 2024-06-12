using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry;
using KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetAllIndustry;
using KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetByIdIndustry;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndustriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllIndustryQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = await _mediator.Send(request);

            if (responses.Count == 0)
            {
                return Ok(new { Message = "Industries is empty"});
            }

            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdIndustryQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);

                if (response.Success)
                {
                    return Ok(new { Data = response });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody]CreateIndustryCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var respnse = await _mediator.Send(request);

                if (respnse.Success)
                {
                    return Ok(new { Data = respnse});
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
