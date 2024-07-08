using KormosalaWebApi.Application.Repositories.JobRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetByIdJob
{
    public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQueryRequest, GetByIdJobQueryResponse>
    {
        private readonly IJobRepository _repository;

        public GetByIdJobQueryHandler(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdJobQueryResponse> Handle(GetByIdJobQueryRequest request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync(request.Id);

            if (job is null)
            {
                return new GetByIdJobQueryResponse
                {
                    Sucess = false,
                    Message = "Job Not Found"
                };
            }

            try
            {
                return new GetByIdJobQueryResponse
                {
                    Id = job.Id,
                    Description = job.Description,
                    Experince = job.Experince,
                    JobType = job.JobType,
                    Salary = job.Salary,
                    Name = job.Name,

                    CategoryId = job.CategoryId,
                    CompanyId = job.CompanyId,

                    Sucess = true,
                    Message = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdJobQueryResponse
                {
                    Sucess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
