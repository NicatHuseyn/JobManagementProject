using KormosalaWebApi.Application.DTOs.IndustryDtos.CreateIndustryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.IndustryServices
{
    public interface IIndustryService
    {
        Task<CreateIndustryCommandResponseDto> CreateIndustryAsync(CreateIndustryCommandRequestDto requestDto);
    }
}
