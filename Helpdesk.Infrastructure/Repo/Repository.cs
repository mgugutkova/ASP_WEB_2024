using Helpdesk.Infrastructure.Data;
using Helpdesk.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;

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
            return DbSet<T>().AsNoTracking();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public void Dispose()
        {
           this.Context.Dispose();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            var key = (Guid)id;

            return await DbSet<T>()
                .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == key);

            // return await DbSet<T>().FindAsync(id);
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
