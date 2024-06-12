using KormosalaWebApi.Application.Repositories.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.BlogCommands.RemoveBlog
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommandRequest, RemoveBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;

        public RemoveBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveBlogCommandResponse> Handle(RemoveBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog is null)
            {
                return new RemoveBlogCommandResponse
                {
                    Success = false,
                    Message = "Blog Not Found"
                };
            }

            try
            {
                _repository.Remove(blog);
                await _repository.SaveAsync();

                return new RemoveBlogCommandResponse { Success = true, Message = "Blog Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new RemoveBlogCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
