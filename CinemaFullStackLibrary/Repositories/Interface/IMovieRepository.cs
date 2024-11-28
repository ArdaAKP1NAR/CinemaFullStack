using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface IMovieRepository
    {
        Task<Movie> AddAsync(Movie entity);
        Task DeleteAsync(Movie entity);
        Task DeleteAsyncById(long id);
        IQueryable<Movie> GetAll();
        Task<Movie?> GetByIdAsync(long? id);
        Task UpdateAsync(Movie entity);
    }
}
