using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.UpdateIndustry
{
    public class UpdateIndustryCommandHandler : IRequestHandler<UpdateIndustryCommandRequest, UpdateIndustryCommandResponse>
    {
        private readonly IIndustryRepository _repository;

        public UpdateIndustryCommandHandler(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateIndustryCommandResponse> Handle(UpdateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var industry = await _repository.GetByIdAsync(request.Id);

            if (industry is null)
            {
                return new UpdateIndustryCommandResponse
                {
                    Success = false,
                    Message = "Industry Not Found"
                };
            }

            try
            {
                industry.Name = request.Name;

                await _repository.SaveAsync();

                return new UpdateIndustryCommandResponse
                {
                    Success = true,
                    Message = "Industry Updated Successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateIndustryCommandResponse { Success = false, Message = ex.Message }; 
            }
        }
    }
}
