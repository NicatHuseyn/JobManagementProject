using KormosalaWebApi.Application.Repositories.IndustryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetByIdIndustry
{
    public class GetByIdIndustryQueryHandler : IRequestHandler<GetByIdIndustryQueryRequest, GetByIdIndustryQueryResponse>
    {
        private readonly IIndustryRepository _repository;

        public GetByIdIndustryQueryHandler(IIndustryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdIndustryQueryResponse> Handle(GetByIdIndustryQueryRequest request, CancellationToken cancellationToken)
        {
            var industry = await _repository.GetByIdAsync(request.Id);

            if (industry is null)
            {
                return new GetByIdIndustryQueryResponse
                {
                    Success = false,
                    Message = "Industry Not Found"
                };
            }

            try
            {
                return new GetByIdIndustryQueryResponse
                {
                    Id = industry.Id,
                    Name = industry.Name,
                    CreateDate = industry.CreateDate,
                    UpdateDate = industry.UpdateDate,

                    Success = true,
                    Message = "Successfully"
                };
            }
            catch (Exception ex)
            {
                return new GetByIdIndustryQueryResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
