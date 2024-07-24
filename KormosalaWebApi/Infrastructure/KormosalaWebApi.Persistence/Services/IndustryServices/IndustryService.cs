using KormosalaWebApi.Application.Abstractions.Services.IndustryServices;
using KormosalaWebApi.Application.DTOs.IndustryDtos.CreateIndustryDtos;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Services.IndustryServices
{
    public class IndustryService : IIndustryService
    {
        private readonly IIndustryRepository _repository;

        public IndustryService(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateIndustryCommandResponseDto> CreateIndustryAsync(CreateIndustryCommandRequestDto requestDto)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Industry
                {
                    Name = requestDto.Name,
                });

                await _repository.SaveAsync();

                return new CreateIndustryCommandResponseDto
                {
                    Success = true,
                    Message = "Create Industry Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateIndustryCommandResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
