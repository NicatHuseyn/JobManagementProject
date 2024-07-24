using KormosalaWebApi.Application.Repositories.CompnayRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly ILogger<UpdateCompanyCommandHandler> _logger;

        public UpdateCompanyCommandHandler(ICompanyRepository repository, ILogger<UpdateCompanyCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
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

                _logger.LogInformation("Company updated...");

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
