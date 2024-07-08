using KormosalaWebApi.Application.Repositories.LocationRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, CreateLocationCommandResponse>
    {
        private readonly ILocationRepository _repository;

        public CreateLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Location
                {
                    AddressName = request.AddressName,
                    CompanyId = request.CompanyId,
                });

                await _repository.SaveAsync();

                return new CreateLocationCommandResponse
                {
                    Success = true,
                    Message = "Location Create Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateLocationCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
