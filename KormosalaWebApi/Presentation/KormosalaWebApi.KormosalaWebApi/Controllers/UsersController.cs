using KormosalaWebApi.Application.Abstractions.Services.MailServices;
using KormosalaWebApi.Application.Featuers.Commands.UserCommands.CreateUser;
using KormosalaWebApi.Application.Featuers.Commands.UserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailService _mailService;

        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _mediator.Send(request);

                return Ok(new { Message = user.Message, User = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExampleMailTest()
        {
            await _mailService.SendMessageAsync("nicat5075@gmail.com","Test Messag", "Salam Menim Adim Nicadir");
            return Ok();
        }

        
    }
}
