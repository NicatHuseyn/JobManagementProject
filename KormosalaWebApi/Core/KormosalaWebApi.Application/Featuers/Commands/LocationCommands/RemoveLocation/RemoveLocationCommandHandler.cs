using KormosalaWebApi.Application.Repositories.LocationRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.RemoveLocation
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommandRequest, RemoveLocationCommandResponse>
    {
        private readonly ILocationRepository _repository;

        public RemoveLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveLocationCommandResponse> Handle(RemoveLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);

            if (location is null)
            {
                return new RemoveLocationCommandResponse
                {
                    Success = false,
                    Message = "Location Not Found"
                };
            }

            try
            {
                _repository.Remove(location);
                await _repository.SaveAsync();

                return new RemoveLocationCommandResponse
                {
                    Success = true,
                    Message = "Location Deleted Successfully"
                };
            }
            catch (Exception ex)
            {
                return new RemoveLocationCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
