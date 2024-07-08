using KormosalaWebApi.Application.Featuers.Commands.JobCommands.CreateJob;
using KormosalaWebApi.Application.Featuers.Commands.JobCommands.RemoveJob;
using KormosalaWebApi.Application.Featuers.Commands.JobCommands.UpdateJob;
using KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetAllJob;
using KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetByIdJob;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromQuery] GetAllJobQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = await _mediator.Send(request);

            if (responses.Count == 0)
            {
                return Ok(new { Message = "Jobs is empty" });
            }

            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdData([FromRoute] GetByIdJobQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);

                if (response.Sucess)
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
        public async Task<IActionResult> CreateData([FromBody] CreateJobCommandRequest request)
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
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData([FromBody] UpdateJobCommandRequest request)
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
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveData([FromRoute] RemoveJobCommandRequest request)
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
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
