using System.Diagnostics.Contracts;

namespace PawnShop.Infrastructure.Data.Repo
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;     

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task<T> GetByIdsAsync<T>(object[] id) where T : class;

        Task AddAsync<T>(T entiry) where T : class;      

        Task<int> SaveChangesAsync();

        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
      
    }
}
