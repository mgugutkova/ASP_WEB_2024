using Microsoft.EntityFrameworkCore;

namespace PawnShop.Infrastructure.Data.Repo
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

        public async Task AddAsync<T>(T entiry) where T : class
        {
           await DbSet<T>().AddAsync(entiry);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();   //.AsQueryable();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
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

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }
    }
}
