using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetAllIndustry
{
    public class GetAllIndustryQueryHandler : IRequestHandler<GetAllIndustryQueryRequest, List<GetAllIndustryQueryResponse>>
    {
        private readonly IIndustryRepository _repository;

        public GetAllIndustryQueryHandler(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllIndustryQueryResponse>> Handle(GetAllIndustryQueryRequest request, CancellationToken cancellationToken)
        {
            var industries = _repository.GetAll();

            return industries.Select(x=> new GetAllIndustryQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Icon = x.Icon,
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,

                Success = true,
                Message = "Successfully"
            }).ToListAsync();
        }
    }
}
