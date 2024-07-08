using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetAllJob
{
    public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest, List<GetAllJobQueryResponse>>
    {
        public readonly IJobRepository _repository;

        public GetAllJobQueryHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllJobQueryResponse>> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var jobs = _repository.GetAll();

            return jobs.Select(x=> new GetAllJobQueryResponse
            {
                Id = x.Id,
                Description = x.Description,
                Experince = x.Experince,
                JobType = x.JobType,
                Name = x.Name,
                Salary = x.Salary,
                
                CategoryId = x.CategoryId,
                CompanyId = x.CompanyId,
            }).ToListAsync();
        }
    }
}
