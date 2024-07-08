using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _repository;

        public UpdateCompanyCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(request.Id);
            if (company is null)
            {
                return new UpdateCompanyCommandResponse
                {
                    Success = false,
                    Message = "Company Not Found"
                };
            }

            try
            {
                company.Name = request.Name;
                company.Description = request.Description;
                company.Email = request.Email;
                company.WebSiteUrl = request.WebSiteUrl;
                company.PhoneNumber = request.PhoneNumber;
                company.Icon = request.Icon;

                await _repository.SaveAsync();

                return new UpdateCompanyCommandResponse { Success = true, Message = "Company Update Successfully" };
            }
            catch (Exception ex)
            {
                return new UpdateCompanyCommandResponse
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
