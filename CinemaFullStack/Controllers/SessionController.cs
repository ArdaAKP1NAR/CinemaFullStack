using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionController(ISessionService sessionService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddSessionToMovie(SessionRequestModel sessionRequestModel, long movieId)
        {
            try
            {
                await sessionService.AddSessionToMovie(mapper.Map<Session>(sessionRequestModel), movieId);
                return Ok();
            }
            catch (MovieNotFoundExcepiton ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetSessionByMovieId(long MovieId)
        {
            return Ok(await sessionService.GetSessionByMovieId(MovieId));
        }
    }
}
