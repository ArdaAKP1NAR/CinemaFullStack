using CinemaFullStackLibrary.Models;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsyncById(long id);
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(long? id);
        Task UpdateAsync(T entity);
    }
}