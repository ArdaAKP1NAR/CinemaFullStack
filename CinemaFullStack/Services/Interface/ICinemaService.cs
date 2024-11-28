using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;

namespace CinemaFullStack.Services.Interface
{
    public interface ICinemaService
    {
        Task AddCinema(Cinema cinema);
        Task<List<CinemaViewModel>> GetAllCinema();
    }
}