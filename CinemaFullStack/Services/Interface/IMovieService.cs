using CinemaFullStackLibrary.Models;

namespace CinemaFullStack.Services.Interface
{
    public interface IMovieService
    {
        Task AddMovie(Movie movie, long CinemaHallId);
        Task<List<Movie>> GetAllMovie();
        Task<List<Movie>> GetMovieByCinemaHall(long cinemaHallId);
        Task<Movie> GetMovieById(long movieId);
    }
}