using KormosalaWebApi.Application.Repositories.BlogRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.BlogQueries.GetAllBlog
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, List<GetAllBlogQueryResponse>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllBlogQueryResponse>> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = _repository.GetAll();
            return blogs.Select(x => new GetAllBlogQueryResponse
            {
                Id = x.Id,
                Text = x.Text,
                Image = x.Image,
                Title = x.Title,
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,

                Success = true,
                Message = "Successfully"
            }).ToListAsync();
        }
    }
}
