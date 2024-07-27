using KormosalaWebApi.Application.Featuers.Commands.BlogCommands.UpdateBlog;
using KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.CreateCompany;
using KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.UpdateCompany;
using KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.RemoveCompany;
using KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetAllCompany;
using KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetByIdCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KormosalaWebApi.Application.Consts;
using KormosalaWebApi.Application.CustomAttributes;
using KormosalaWebApi.Application.Enums;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Companies, ActionType = ActionType.Reading, Definition = "Get Company Items")]
        public async Task<IActionResult> GetAllData([FromQuery] GetAllCompanyQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = await _mediator.Send(request);

            if (responses.Count == 0)
            {
                return Ok(new { Message = "Industries is empty" });
            }

            return Ok(responses);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Companies, ActionType = ActionType.Reading, Definition = "Get Company By Id Item")]
        public async Task<IActionResult> GetByIdData([FromRoute] GetByIdCompanyQueryRequest request)
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
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Companies, ActionType = ActionType.Writing, Definition = "Create Company")]
        public async Task<IActionResult> CreateData([FromBody] CreateCompanyCommandRequest request)
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
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Companies, ActionType = ActionType.Updating, Definition = "Update Company")]
        public async Task<IActionResult> UpdateData([FromBody] UpdateCompanyCommandRequest request)
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
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Companies, ActionType = ActionType.Deleting, Definition = "Delete Company")]
        public async Task<IActionResult> RemoveData([FromRoute] RemoveCompanyCommandRequest request)
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
