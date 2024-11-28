using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface ICinemaHallRepository
    {
        Task<CinemaHall> AddAsync(CinemaHall entity);
        Task DeleteAsync(CinemaHall entity);
        Task DeleteAsyncById(long id);
        IQueryable<CinemaHall> GetAll();
        Task<CinemaHall?> GetByIdAsync(long? id);
        Task UpdateAsync(CinemaHall entity);
    }
}
