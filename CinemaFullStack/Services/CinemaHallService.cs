using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories;
using CinemaFullStackLibrary.Repositories.Interface;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace CinemaFullStack.Services
{
    public class CinemaHallService(ICinemaHallRepository cinemaHallRepository, ICinemaRepository cinemaRepository, IMapper mapper) : ICinemaHallService
    {
        public async Task AddCinemaHall(CinemaHall cinemaHall, long CinemaId)
        {
            var Cinema = await cinemaRepository.GetByIdAsync(CinemaId) ?? throw new CinemaNotFoundException("Cinema not found. ");
            cinemaHall.CinemaId = CinemaId;
            await cinemaHallRepository.AddAsync(cinemaHall);
        }
        public async Task<List<CinemaHallViewModel>> GetAllCİnemaHall()
        {
            return await cinemaHallRepository.GetAll()
                .ProjectTo<CinemaHallViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<CinemaHall> GetCinemaHallById(long cinemaHallId)
        {
            var cinemaHall = await cinemaHallRepository.GetByIdAsync(cinemaHallId);
            if (cinemaHall == null)
            {
                throw new CinemaHallNotFoundException("CinemaHall not found. ");
            }
            return cinemaHall;
        }
        public async Task<List<CinemaHall>> GetCinemaHallByCinema(long cinemaId)
        {
            var cinema = await cinemaRepository.GetByIdAsync(cinemaId);
            if (cinema != null)
            {
                return await cinemaHallRepository.GetAll()
                    .Where(a => a.CinemaId == cinemaId)
                    .ToListAsync();
            }
            throw new CinemaNotFoundException("Cinema not found. ");
        }
    }
}
