using Microsoft.EntityFrameworkCore;

namespace Fondacia.Infrastructure.Repo
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task<T> GetByIdsAsync<T>(object[] id) where T : class;

        Task AddAsync<T>(T entiry) where T : class;

        Task<int> SaveChangesAsync();

        DbSet<T> DbSet<T>() where T : class;

       // DbSet<T> Set<T>() where T : class;

    }
}
