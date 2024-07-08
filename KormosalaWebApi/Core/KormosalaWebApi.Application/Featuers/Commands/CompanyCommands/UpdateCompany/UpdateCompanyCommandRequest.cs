using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.UpdateCompany
{
    public class UpdateCompanyCommandRequest:IRequest<UpdateCompanyCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }
    }
}
