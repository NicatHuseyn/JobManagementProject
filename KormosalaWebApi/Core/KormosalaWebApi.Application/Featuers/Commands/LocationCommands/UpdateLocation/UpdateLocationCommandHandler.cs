using KormosalaWebApi.Application.Repositories.LocationRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, UpdateLocationCommandResponse>
    {
        private readonly ILocationRepository _repository;

        public UpdateLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        async Task<UpdateLocationCommandResponse> IRequestHandler<UpdateLocationCommandRequest, UpdateLocationCommandResponse>.Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);
            if (location is null)
            {
                return new UpdateLocationCommandResponse
                {
                    Success = true,
                    Message = "Location Not Found"
                };
            }

            try
            {
                location.AddressName = request.AddressName;
                location.CompanyId = request.CompanyId;

                _repository.Update(location);

                await _repository.SaveAsync();

                return new UpdateLocationCommandResponse
                {
                    Success = true,
                    Message = "Location Update Successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateLocationCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
