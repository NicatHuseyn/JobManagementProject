using KormosalaWebApi.Application.Repositories;
using KormosalaWebApi.Domain.Entities.Common;
using KormosalaWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly KormosalaDbContext _context;

        public Repository(KormosalaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        // WRITE Methods
        #region WRITE Methods
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entry = await Table.AddAsync(model);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entry =  Table.Remove(model);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return Remove(await Table.FindAsync(id));
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entry = Table.Update(model);
            return entry.State == EntityState.Modified;
        }
        #endregion


        // GET Methods
        #region Get Methods
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return query;
        }

        public Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return query.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return query;
        }
        #endregion


        #region Save Method
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion


    }
}
