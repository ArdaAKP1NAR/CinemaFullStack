using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.ViewModels;

namespace CinemaFullStack.Services.Interface
{
    public interface ICinemaHallService
    {
        Task AddCinemaHall(CinemaHall cinemaHall, long CinemaId);
        Task<List<CinemaHallViewModel>> GetAllCİnemaHall();
        Task<List<CinemaHall>> GetCinemaHallByCinema(long cinemaId);
        Task<CinemaHall> GetCinemaHallById(long cinemaHallId);
    }
}