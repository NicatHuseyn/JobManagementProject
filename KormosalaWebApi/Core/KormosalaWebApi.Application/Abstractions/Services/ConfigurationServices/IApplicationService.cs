using KormosalaWebApi.Application.DTOs.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.ConfigurationServices
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoint(Type type);
    }
}
