using KormosalaWebApi.Application.Featuers.Commands.ContactCommands.CreateContact;
using KormosalaWebApi.Application.Featuers.Commands.ContactCommands.RemoveContact;
using KormosalaWebApi.Application.Featuers.Commands.ContactCommands.UpdateContact;
using KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetAllContact;
using KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetByIdContact;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromQuery] GetAllContactQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = await _mediator.Send(request);

            if (responses.Count == 0)
            {
                return Ok(new { Message = "Contacts is empty" });
            }

            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdData([FromRoute] GetByIdContactQueryRequest request)
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
        public async Task<IActionResult> CreateData([FromBody] CreateContactCommandRequest request)
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
        public async Task<IActionResult> UpdateData([FromBody] UpdateContactCommandRequest request)
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
        public async Task<IActionResult> RemoveData([FromRoute] RemoveContactCommandRequest request)
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
