using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetCategoryWithJobs
{
    public class GetCategoryWithJobsQueryHandler : IRequestHandler<GetCategoryWithJobsQueryRequest, List<GetCategoryWithJobsQueryResponse>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryWithJobsQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCategoryWithJobsQueryResponse>> Handle(GetCategoryWithJobsQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _repository.GetAll();

            return categories.Select(x=> new GetCategoryWithJobsQueryResponse
            {
                Name = x.Name,
                Description = x.Description,
                Jobs = x.Jobs,
            }).ToListAsync();
        }
    }
}
