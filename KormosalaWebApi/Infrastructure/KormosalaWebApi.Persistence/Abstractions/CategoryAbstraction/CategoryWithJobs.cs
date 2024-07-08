using KormosalaWebApi.Application.Interfaces.CategoryInterfaces;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Abstractions.CategoryAbstraction
{
    public class CategoryWithJobs : ICategoryWithJobs
    {
        private readonly KormosalaDbContext _context;

        public CategoryWithJobs(KormosalaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoryWithJobsAsync()
        {
            var categories = await _context.Categories.Include(c=>c.Jobs).ToListAsync();
            return categories;
        }
    }
}
