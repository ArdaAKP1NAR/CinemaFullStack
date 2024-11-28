using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController(IMovieService movieService,IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieRequestModel movieRequestModel, long CinemaHallId)
        {
            try
            {          
                await movieService.AddMovie(mapper.Map<Movie>(movieRequestModel), CinemaHallId);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is CinemaHallNotFoundException)
                {
                    return NotFound(ex.Message);
                }
                if (ex is InvalidMovieNameException)
                {
                    return BadRequest(ex.Message);
                }
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GettAllMovie()
        {
            return Ok(await movieService.GetAllMovie());
        }
        [HttpGet]
        public async Task<IActionResult> GetMovieById(long movieId)
        {
            var movie = await movieService.GetMovieById(movieId);
            return Ok(movie);
        }
        [HttpGet]
        public async Task<IActionResult> GetMovieByCinemaHall(long CinemaHallId)
        {
            return Ok(await movieService.GetMovieByCinemaHall(CinemaHallId));
        }
    }
}
