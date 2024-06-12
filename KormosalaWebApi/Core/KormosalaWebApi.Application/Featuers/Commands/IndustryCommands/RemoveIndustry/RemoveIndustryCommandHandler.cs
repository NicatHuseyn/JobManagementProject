using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.RemoveIndustry
{
    public class RemoveIndustryCommandHandler : IRequestHandler<RemoveIndustryCommandRequest, RemoveIndustryCommandResponse>
    {
        private readonly IIndustryRepository _repository;

        public RemoveIndustryCommandHandler(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveIndustryCommandResponse> Handle(RemoveIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var industry  = await _repository.GetByIdAsync(request.Id);

            if (industry is null)
            {
                return new RemoveIndustryCommandResponse
                {
                    Success = false,
                    Message = "Industry Not Found"
                };
            }

            try
            {
                _repository.Remove(industry);
                await _repository.SaveAsync();

                return new RemoveIndustryCommandResponse { Success = true, Message = "Industry Deleted Successfully" };

            }
            catch (Exception ex)
            {
                return new RemoveIndustryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
