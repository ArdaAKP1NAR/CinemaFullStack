using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CinemaFullStack.Services
{
    public class MovieService(IMovieRepository movieRepository, ICinemaHallRepository cinemaHallRepository, ISessionRepository sessionRepository, IMapper mapper) : IMovieService
    {
        public async Task AddMovie(Movie movie, long CinemaHallId)
        {
            var CinemaHall = await cinemaHallRepository.GetByIdAsync(CinemaHallId) ?? throw new CinemaHallNotFoundException("CinemaHall not found. ");
            movie.CinemaHall = CinemaHall;
            movie.CinemaHallId = CinemaHallId;
            movie.SeatingCapacity = CinemaHall.SeatingCapacity;

            var regex = new Regex(@"^[a-zA-Z\s]+$");

            if (!regex.IsMatch(movie.MovieName))
            {
                throw new InvalidMovieNameException("Name can only contain letters");
            }

            await movieRepository.AddAsync(movie);
            CinemaHall.Movies.Add(movie);

            await cinemaHallRepository.UpdateAsync(CinemaHall);
            await movieRepository.UpdateAsync(movie);
        }
        public async Task<List<Movie>> GetAllMovie()
        {
            return await movieRepository.GetAll()
                .Where(m => m.Session.Any(s => s.StartTime > DateTime.Now))
                .Include(m => m.Session)
                .ToListAsync();
        }
        public async Task<Movie> GetMovieById(long movieId)
        {
            var movie = await movieRepository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new MovieNotFoundExcepiton("Movie not found. ");
            }
            return movie;
        }

        public async Task<List<Movie>> GetMovieByCinemaHall(long cinemaHallId)
        {
            var cinemaHall = await cinemaHallRepository.GetByIdAsync(cinemaHallId) ?? throw new CinemaHallNotFoundException("Cinema Hall not found. ");
            return await movieRepository.GetAll()
                .Where(a => a.CinemaHallId == cinemaHallId)
                .ToListAsync();
        }
    }
}
