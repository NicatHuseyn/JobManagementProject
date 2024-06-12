using KormosalaWebApi.Application.Repositories.BlogRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.BlogQueries.GetByIdBlog
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IBlogRepository _repository;

        public GetByIdBlogQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog is null)
            {
                return new GetByIdBlogQueryResponse
                {
                    Success = false,
                    Message = "Blog Not Found"
                };
            }

            try
            {
                return new GetByIdBlogQueryResponse
                {
                    Id = blog.Id,
                    Text = blog.Text,
                    Image = blog.Image,
                    Title = blog.Title,
                    CreateDate = blog.CreateDate,
                    UpdateDate = blog.UpdateDate,

                    Success = true,
                    Message = "Blog Found Successfully",
                };
            }
            catch (Exception ex)
            {
                return new GetByIdBlogQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
