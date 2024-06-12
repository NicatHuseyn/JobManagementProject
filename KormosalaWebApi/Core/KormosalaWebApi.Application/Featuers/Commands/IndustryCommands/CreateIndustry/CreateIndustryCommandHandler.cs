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
        private readonly IIndustryRepository _repository;

        public CreateIndustryCommandHandler(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateIndustryCommandResponse> Handle(CreateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Industry
                {
                    Name = request.Name,
                    Icon = request.Icon
                });

                await _repository.SaveAsync();

                return new CreateIndustryCommandResponse
                {
                    Success = true,
                    Message = "Industry Created Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateIndustryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
