using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController(ICustomerService customerService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequestModel customerRequestModel)
        {
            try
            {
                var customer = mapper.Map<Customer>(customerRequestModel);
                await customerService.AddCustomer(customer);
                return Ok(customer.Id);
            }
            catch (InvalidCustomerNameException ex)
            {
                return BadRequest(ex.Message);
            }          
        }
    }
}
