using KormosalaWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Repositories.IndustryRepository
{
    public interface IIndustryRepository:IRepository<Industry>
    {
    }
}
