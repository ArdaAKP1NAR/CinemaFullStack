using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace CinemaFullStack.Services
{
    public class SessionService(ISessionRepository sessionRepository, IMovieRepository movieRepository, IMapper mapper) : ISessionService
    {
        public async Task AddSessionToMovie(Session session, long MovieId)
        {
            var Movie = await movieRepository.GetByIdAsync(MovieId) ?? throw new MovieNotFoundExcepiton("Movie not found. ");
            session.Movie = Movie;
            session.MovieId = MovieId;
            session.SeatingCapacity = Movie.SeatingCapacity;
            if (session.StartTime < DateTime.Now)
            {
                session.IsActive = false;
            }

            await sessionRepository.AddAsync(session);
            await movieRepository.UpdateAsync(Movie);
        }
        public async Task<List<SessionViewModel>> GetSessionByMovieId(long MovieId)
        {
            return await sessionRepository.GetAll()
                .Where(a => a.MovieId == MovieId && a.StartTime > DateTime.Now)
                .ProjectTo<SessionViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
