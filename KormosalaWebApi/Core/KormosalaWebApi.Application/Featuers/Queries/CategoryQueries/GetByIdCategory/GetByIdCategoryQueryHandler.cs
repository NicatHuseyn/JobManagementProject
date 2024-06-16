using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryRepository _repository;

        public GetByIdCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return new GetByIdCategoryQueryResponse
                {
                    Success = false,
                    Message = "Category Not Found"
                };
            }

            try
            {
                return new GetByIdCategoryQueryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    Icon = category.Icon,
                    CreateDate = category.CreateDate,
                    UpdateDate = category.UpdateDate,
                    
                    Success = true,
                    Message = "Category Found Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdCategoryQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
