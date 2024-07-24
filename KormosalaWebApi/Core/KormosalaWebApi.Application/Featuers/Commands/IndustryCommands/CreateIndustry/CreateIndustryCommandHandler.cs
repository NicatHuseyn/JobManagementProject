using KormosalaWebApi.Application.Abstractions.Services.IndustryServices;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry
{
    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommandRequest, CreateIndustryCommandResponse>
    {
        private readonly IIndustryService _industryService;

        public CreateIndustryCommandHandler(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        public async Task<CreateIndustryCommandResponse> Handle(CreateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            await _industryService.CreateIndustryAsync(new DTOs.IndustryDtos.CreateIndustryDtos.CreateIndustryCommandRequestDto
            {
                Name = request.Name,
            });

            return new CreateIndustryCommandResponse
            {
                Success = true,
                Message = "Successfully"
            };
        }
    }
}
