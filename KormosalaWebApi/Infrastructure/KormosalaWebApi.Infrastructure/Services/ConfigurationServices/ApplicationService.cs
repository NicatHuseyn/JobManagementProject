using KormosalaWebApi.Application.Abstractions.Services.ConfigurationServices;
using KormosalaWebApi.Application.CustomAttributes;
using KormosalaWebApi.Application.DTOs.Configuration;
using KormosalaWebApi.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Infrastructure.Services.ConfigurationServices
{
    public class ApplicationService : IApplicationService
    {
        public List<MenuDto> GetAuthorizeDefinitionEndpoint(Type type)
        {
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t=> t.IsAssignableTo(typeof(ControllerBase)));


            List<MenuDto> menus = new();

            if (controllers is not null)
            {
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute), true));

                    if (actions is not null)
                    {
                        foreach (var action in actions)
                        {
                            var attributes = action.GetCustomAttributes(true);
                            if (attributes is not null)
                            {

                                MenuDto menu = null;

                                var authorizeDefinitionAttribute = attributes.FirstOrDefault(a=>a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                                if (!menus.Any(m=> m.Name == authorizeDefinitionAttribute.Menu))
                                {
                                    menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                    menus.Add(menu);
                                }
                                else
                                {
                                    menu = menus.FirstOrDefault(m=>m.Name == authorizeDefinitionAttribute.Menu);
                                }

                                ActionDto actionDto = new ActionDto()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                    Definition = authorizeDefinitionAttribute.Definition
                                };

                                var httpAttribute = attributes.FirstOrDefault(a=>a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;

                                if (httpAttribute is not null)
                                {
                                    actionDto.HttpType = httpAttribute.HttpMethods.First();
                                }
                                else
                                {
                                    actionDto.HttpType = HttpMethods.Get;
                                }

                                actionDto.Code = $"{actionDto.HttpType}.{actionDto.ActionType}.{actionDto.Definition.Replace(" ","")}";

                                menu.Actions.Add(actionDto);
                            }
                        }
                    }
                }
            }

            return menus;
        }
    }
}
