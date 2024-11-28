using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories;
using CinemaFullStackLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFullStack.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TicketProcessController(ITicketProcessService ticketProcessService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SellTicket(long SessionId, long CustomerId)
        {
            try
            {
                var ticketId = await ticketProcessService.SellTicket(SessionId, CustomerId);
                return Ok(new { ticketId = ticketId });
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (MovieNotFoundExcepiton ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SellAnonymousTicket(long SessionId)
        {
            try
            {
                await ticketProcessService.SellAnonymousTicket(SessionId);
                return Ok(new { message = "Ticket sold successfully." });
            }
            catch (MovieNotFoundExcepiton ex)
            {
                return NotFound(ex.Message);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> CheckCustomerByPhone(string phoneNumber)
        {
            var customer = await ticketProcessService.CheckCustomerByPhoneNumber(phoneNumber);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new { customerId = customer.Id });
        }

        [HttpPost]
        public async Task<IActionResult> TicketRefund(long SalesTicketId)
        {
            await ticketProcessService.TicketRefund(SalesTicketId);
            return Ok();
        }
    }
}
