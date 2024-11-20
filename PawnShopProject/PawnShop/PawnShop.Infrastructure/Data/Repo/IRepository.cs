using System.Diagnostics.Contracts;

namespace PawnShop.Infrastructure.Data.Repo
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entiry) where T : class;

        Task<int> SaveChangesAsync();		
	}
}
