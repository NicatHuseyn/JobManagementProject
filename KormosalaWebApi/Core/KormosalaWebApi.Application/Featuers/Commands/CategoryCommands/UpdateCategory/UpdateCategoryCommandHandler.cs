using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category Not Found"
                };
            }

            try
            {
                category.Name = request.Name;
                category.Description = request.Description;
                _repository.Update(category);
                await _repository.SaveAsync();

                return new UpdateCategoryCommandResponse
                {
                    Success = true,
                    Message = "Category Update Successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
