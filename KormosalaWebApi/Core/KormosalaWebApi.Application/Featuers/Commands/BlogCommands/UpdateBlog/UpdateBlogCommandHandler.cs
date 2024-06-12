using KormosalaWebApi.Application.Repositories.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.BlogCommands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest, UpdateBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;

        public UpdateBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);

            if (blog is null)
            {
                return new UpdateBlogCommandResponse
                {
                    Success = false,
                    Message = "Blog Not Found"
                };
            }

            try
            {
                blog.Text = request.Text;
                blog.Title = request.Title;
                blog.Image = request.Image;

                _repository.Update(blog);

                return new UpdateBlogCommandResponse { Success = true, Message = "Blog Update Successfully" };
            }
            catch (Exception ex)
            {
                return new UpdateBlogCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
