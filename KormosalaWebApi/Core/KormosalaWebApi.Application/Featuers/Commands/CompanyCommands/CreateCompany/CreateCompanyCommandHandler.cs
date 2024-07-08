using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _repository;

        public CreateCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Domain.Entities.Company
                {
                    Name = request.Name,
                    Description = request.Description,
                    Icon = request.Icon,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    WebSiteUrl  = request.WebSiteUrl,
                });

                await _repository.SaveAsync();

                return new CreateCompanyCommandResponse
                {
                    Success = true,
                    Message = "Create Company Successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreateCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
