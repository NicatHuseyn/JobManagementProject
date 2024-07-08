using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQueryRequest, GetByIdCompanyQueryResponse>
    {
        private readonly ICompanyRepository _repository;

        public GetByIdCompanyQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdCompanyQueryResponse> Handle(GetByIdCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company is null)
            {
                return new GetByIdCompanyQueryResponse
                {
                    Success = false,
                    Message = "Company Not Found"
                };
            }
            try
            {
                return new GetByIdCompanyQueryResponse
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description,
                    Email = company.Email,
                    Icon = company.Icon,
                    PhoneNumber = company.PhoneNumber,
                    WebSiteUrl = company.WebSiteUrl,
                    CreateDate = company.CreateDate,
                    UpdateDate = company.UpdateDate,

                    Success = true,
                    Message = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdCompanyQueryResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
