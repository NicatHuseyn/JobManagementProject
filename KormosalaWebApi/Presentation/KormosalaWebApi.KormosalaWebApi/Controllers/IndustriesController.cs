using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry;
using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.RemoveIndustry;
using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.UpdateIndustry;
using KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetAllIndustry;
using KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetByIdIndustry;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using KormosalaWebApi.KormosalaWebApi.Models;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KormosalaWebApi.KormosalaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndustriesController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData([FromQuery]GetAllIndustryQueryRequest request)
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
        public async Task<IActionResult> GetByIdData([FromRoute]GetByIdIndustryQueryRequest request)
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
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData([FromBody]UpdateIndustryCommandRequest request)
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
                    return Ok(new { Data = response});
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveData([FromRoute]RemoveIndustryCommandRequest request)
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

        //[HttpPost("[action]")]
        //public async Task<IActionResult> UploadFile()
        //{

        //    var uploadFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "ImageResource/Images");

        //    if (!Directory.Exists(uploadFilePath))
        //    {
        //        Directory.CreateDirectory(uploadFilePath);
        //    }



        //    var files = Request.Form.Files;

        //    foreach (var file in files)
        //    {
        //        if (file is null && file.Length == 0)
        //        {
        //            ModelState.AddModelError("", "File Not Selected");
        //        }

        //        if (ModelState.IsValid)
        //        {

        //            var uniqueFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";

        //            var fullFilePath = Path.Combine(uploadFilePath, uniqueFileName);

        //            using var fileStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
        //            await file.CopyToAsync(fileStream);

        //            fileStream.Flush();

        //            return Ok();
        //        }
        //    }

        //    return Ok();
        //}
    }
}
