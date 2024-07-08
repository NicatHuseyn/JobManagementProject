using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CompanyCommands.RemoveCompany
{
    public class RemoveCompanyCommandRequest:IRequest<RemoveCompanyCommandResponse>
    {
        public int Id { get; set; }
    }
}
