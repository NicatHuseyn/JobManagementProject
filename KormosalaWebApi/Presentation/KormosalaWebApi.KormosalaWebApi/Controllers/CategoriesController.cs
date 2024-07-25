﻿using KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.CreateCategory;
using KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.RemoveCategroy;
using KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.UpdateCategory;
using KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetAllCategory;
using KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetByIdCategory;
using KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetCategoryWithJobs;
using KormosalaWebApi.Application.Interfaces.CategoryInterfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICategoryWithJobs _categoryWithJobs;

        public CategoriesController(IMediator mediator, ICategoryWithJobs categoryWithJobs)
        {
            _mediator = mediator;
            _categoryWithJobs = categoryWithJobs;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromQuery] GetAllCategoryQueryRequest request)
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
        public async Task<IActionResult> GetByIdData([FromRoute] GetByIdCategoryQueryRequest request)
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
        public async Task<IActionResult> CreateData([FromBody] CreateCategoryCommandRequest request)
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
        public async Task<IActionResult> UpdateData([FromBody] UpdateCategoryCommandRequest request)
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
        public async Task<IActionResult> RemoveData([FromRoute] RemoveCategoryCommandRequest request)
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


        [HttpGet]
        [Route("GetCategoryWithJobs")]
        public async Task<IActionResult> GetCategoryWithJobs([FromQuery]GetCategoryWithJobsQueryRequest request)
        {
            var responses = await _mediator.Send(request);
            return Ok(responses);
        }
    }
}
