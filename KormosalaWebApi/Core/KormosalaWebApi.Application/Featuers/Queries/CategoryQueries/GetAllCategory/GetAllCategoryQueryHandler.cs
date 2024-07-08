using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _repository.GetAll();
            return categories.Select(x => new GetAllCategoryQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,

                Success = true,
                Message = "Successfully"
            }).ToListAsync();
        }
    }
}
