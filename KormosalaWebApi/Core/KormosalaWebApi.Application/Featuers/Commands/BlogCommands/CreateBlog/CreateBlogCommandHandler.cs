using KormosalaWebApi.Application.Repositories.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.BlogCommands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest, CreateBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;

        public CreateBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Blog
                {
                    Text = request.Text,
                    Image = request.Image,
                    Title = request.Title
                });

                await _repository.SaveAsync();

                return new CreateBlogCommandResponse
                {
                    Success = true,
                    Message = "Blog Create Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateBlogCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
