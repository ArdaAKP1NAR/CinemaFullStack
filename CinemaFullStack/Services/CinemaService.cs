using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CinemaFullStack.Services
{
    public class CinemaService(ICinemaRepository cinemaRepository , IMapper mapper) : ICinemaService
    {
        public async Task AddCinema(Cinema cinema)
        {
            var regex = new Regex(@"^[a-zA-Z\s]+$");

            if (!regex.IsMatch(cinema.CinemaName))
            {
                throw new InvalidCinemaNameException("Name can only contain letters");
            }
            await cinemaRepository.AddAsync(cinema);
        }
        public async Task<List<CinemaViewModel>> GetAllCinema()
        {
            return await cinemaRepository.GetAll().ProjectTo<CinemaViewModel>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
