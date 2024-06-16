﻿using KormosalaWebApi.Application.Featuers.Commands.BlogCommands.CreateBlog;
using KormosalaWebApi.Application.Featuers.Commands.BlogCommands.RemoveBlog;
using KormosalaWebApi.Application.Featuers.Commands.BlogCommands.UpdateBlog;
using KormosalaWebApi.Application.Featuers.Queries.BlogQueries.GetAllBlog;
using KormosalaWebApi.Application.Featuers.Queries.BlogQueries.GetByIdBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromQuery] GetAllBlogQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var responses = await _mediator.Send(request);
                if (responses.Count == 0)
                {
                    return Ok(new { Data = "Blogs is empty"});
                }

                return Ok(new { Data = responses});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdData([FromRoute] GetByIdBlogQueryRequest request)
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
        public async Task<IActionResult> CreateData([FromBody] CreateBlogCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);
                var r = response.Success;

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
        public async Task<IActionResult> UpdateData([FromBody] UpdateBlogCommandRequest request)
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
        public async Task<IActionResult> RemoveData([FromRoute] RemoveBlogCommandRequest request)
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
