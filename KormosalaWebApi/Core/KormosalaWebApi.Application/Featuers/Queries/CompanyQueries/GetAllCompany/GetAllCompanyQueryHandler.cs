using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, List<GetAllCompanyQueryResponse>>
    {
        private readonly ICompanyRepository _repository;

        public GetAllCompanyQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllCompanyQueryResponse>> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = _repository.GetAll();

            return companies.Select(x => new GetAllCompanyQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                WebSiteUrl = x.WebSiteUrl,

                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate
            }).ToListAsync();
        }
    }
}
