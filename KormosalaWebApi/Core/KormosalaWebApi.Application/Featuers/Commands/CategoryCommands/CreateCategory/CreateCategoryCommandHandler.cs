using KormosalaWebApi.Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Category
                {
                    Name = request.Name,
                    Description = request.Description
                });

                await _repository.SaveAsync();

                return new CreateCategoryCommandResponse
                {
                    Success = true,
                    Message = "Create Category Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
