using KormosalaWebApi.Application.Repositories.LocationRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.LocationQueries.GetByIdLocation
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQueryRequest, GetByIdLocationQueryResponse>
    {
        private readonly ILocationRepository _repository;

        public GetByIdLocationQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdLocationQueryResponse> Handle(GetByIdLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);

            if (location is null)
            {
                return new GetByIdLocationQueryResponse
                {
                    Success = false,
                    Message = "Location Not Found"
                };
            }

            try
            {
                return new GetByIdLocationQueryResponse
                {
                    Id = location.Id,
                    AddressName = location.AddressName,
                    CompanyId = location.CompanyId,

                    Success = true,
                    Message = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdLocationQueryResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
