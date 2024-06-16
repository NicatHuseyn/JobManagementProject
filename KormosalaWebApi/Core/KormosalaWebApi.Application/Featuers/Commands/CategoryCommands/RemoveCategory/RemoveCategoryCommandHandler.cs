using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.RemoveCategroy
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return new RemoveCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category Not Found"
                };
            }

            try
            {
                _repository.Remove(category);
                await _repository.SaveAsync();

                return new RemoveCategoryCommandResponse { Success = true, Message = "Category Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new RemoveCategoryCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
