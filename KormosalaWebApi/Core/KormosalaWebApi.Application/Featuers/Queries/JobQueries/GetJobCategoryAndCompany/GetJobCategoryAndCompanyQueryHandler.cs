using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetJobCategoryAndCompany
{
    public class GetJobCategoryAndCompanyQueryHandler : IRequestHandler<GetJobCategoryAndCompanyQueryRequest, List<GetJobCategoryAndCompanyQueryResponse>>
    {
        private readonly IJobRepository _repository;

        public GetJobCategoryAndCompanyQueryHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetJobCategoryAndCompanyQueryResponse>> Handle(GetJobCategoryAndCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var jobs = _repository.GetAll();

            return jobs.Select(x=> new GetJobCategoryAndCompanyQueryResponse
            {
                Id = x.Id,
                Description = x.Description,
                Experience = x.Experience,
                JobType = x.JobType,
                Name = x.Name,
                Salary = x.Salary,
                ViewCount   = x.ViewCount,
                Category = x.Category,
                CategoryId = x.CategoryId,
                Company = x.Company,
                CompanyId = x.CompanyId
            }).ToListAsync();
        }
    }
}
