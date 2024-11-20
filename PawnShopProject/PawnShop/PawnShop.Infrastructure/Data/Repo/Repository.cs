using Microsoft.EntityFrameworkCore;

namespace PawnShop.Infrastructure.Data.Repo
{
	public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>(); // връща табл. отговаряща на въпросното entity
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
            return await context.SaveChangesAsync();
        }	
	}
}
