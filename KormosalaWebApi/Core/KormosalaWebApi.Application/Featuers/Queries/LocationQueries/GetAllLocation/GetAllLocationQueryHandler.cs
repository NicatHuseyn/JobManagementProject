using KormosalaWebApi.Application.Repositories.LocationRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.LocationQueries.GetAllLocation
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQueryRequest, List<GetAllLocationQueryResponse>>
    {
        private readonly ILocationRepository _repository;

        public GetAllLocationQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllLocationQueryResponse>> Handle(GetAllLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var locations = _repository.GetAll();

            return locations.Select(x=> new GetAllLocationQueryResponse
            {
                Id = x.Id,
                AddressName = x.AddressName,
                CompanyId = x.CompanyId,

                Success = true,
                Message = "Successfully"
            }).ToListAsync();
        }
    }
}
