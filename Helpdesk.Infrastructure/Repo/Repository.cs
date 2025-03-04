using Helpdesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Repo
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }

        public Repository(ApplicationDbContext _context)
        {
            Context = _context;
        }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>(); // връща табл. отговаряща на въпросното entity
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
           await DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public void Dispose()
        {
           this.Context.Dispose();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
