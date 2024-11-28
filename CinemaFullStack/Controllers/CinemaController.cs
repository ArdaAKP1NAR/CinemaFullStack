using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CinemaController(ICinemaService CinemaService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCinema(CinemaRequestModel cinemaRequestModel)
        {
            try
            {
                await CinemaService.AddCinema(mapper.Map<Cinema>(cinemaRequestModel));
                return Ok();
            }
            catch (InvalidCinemaNameException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GettAllCinema()
        {
           return Ok(await CinemaService.GetAllCinema());    
        }
    }
}
