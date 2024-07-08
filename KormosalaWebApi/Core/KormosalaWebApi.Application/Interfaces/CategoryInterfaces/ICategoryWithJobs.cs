using KormosalaWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Interfaces.CategoryInterfaces
{
    public interface ICategoryWithJobs
    {
        public Task<List<Category>> GetCategoryWithJobsAsync();
    }
}
