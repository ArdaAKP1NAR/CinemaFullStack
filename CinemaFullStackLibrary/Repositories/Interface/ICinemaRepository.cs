using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface ICinemaRepository
    {
        Task<Cinema> AddAsync(Cinema entity);
        Task DeleteAsync(Cinema entity);
        Task DeleteAsyncById(long id);
        IQueryable<Cinema> GetAll();
        Task<Cinema?> GetByIdAsync(long? id);
        Task UpdateAsync(Cinema entity);
    }
}
