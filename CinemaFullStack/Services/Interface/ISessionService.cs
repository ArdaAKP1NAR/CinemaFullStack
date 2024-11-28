using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.ViewModels;

namespace CinemaFullStack.Services.Interface
{
    public interface ISessionService
    {
        Task AddSessionToMovie(Session session, long MovieId);
        Task<List<SessionViewModel>> GetSessionByMovieId(long MovieId);
    }
}