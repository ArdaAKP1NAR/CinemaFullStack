using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CinemaHallController(ICinemaHallService cinemaHallService,IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCinemaHall(CinemaHallRequestModel cinemaHallRequestModel, long CinemaId)
        {
            try
            {
                await cinemaHallService.AddCinemaHall(mapper.Map<CinemaHall>(cinemaHallRequestModel),CinemaId);
                return Ok(); 
            }
            catch (CinemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCinemaHall()
        {
            return Ok(await cinemaHallService.GetAllCİnemaHall());
        }
        [HttpGet]
        public async Task<IActionResult> GetCinemaHallById(long cinemaHallId)
        {
            var movie = await cinemaHallService.GetCinemaHallById(cinemaHallId);
            return Ok(movie);
        }
        [HttpGet]
        public async Task<IActionResult> GetCinemaHallByCinema(long cinemaId)
        {
            try
            {
                var CinemaHalls = await cinemaHallService.GetCinemaHallByCinema(cinemaId);
                return Ok(CinemaHalls);
            }
            catch (CinemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
