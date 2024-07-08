using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.RemoveCompany
{
    public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommandRequest, RemoveCompanyCommandResponse>
    {
        private readonly ICompanyRepository _repository;

        public RemoveCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveCompanyCommandResponse> Handle(RemoveCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company is null)
            {
                return new RemoveCompanyCommandResponse
                {
                    Success = false,
                    Message = "Company Not Found"
                };
            }

            try
            {
                _repository.Remove(company);
                await _repository.SaveAsync();

                return new RemoveCompanyCommandResponse
                {
                    Success = true,
                    Message = "Company Deleted Successuflly"
                };
            }
            catch (Exception ex)
            {
                return new RemoveCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
