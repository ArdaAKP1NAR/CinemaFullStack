using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CinemaFullStack.Services
{
    public class TicketProcessService(ITicketSalesRepository ticketSalesRepository,IMovieRepository movieRepository, ISessionRepository sessionRepository, ICustomerRepository customerRepository, ICinemaHallRepository cinemaHallRepository) : ITicketProcessService
    {
        public async Task<long> SellTicket(long SessionId, long CustomerId)
        {
            TicketSales ticketSales = new TicketSales()
            {
                CustomerId = CustomerId,
                SessionId = SessionId,
                SoldDate = DateTime.Now,
            };

            var Session = await sessionRepository.GetByIdAsync(SessionId);
            if (Session == null)
            {
                throw new MovieNotFoundExcepiton("Session not found. ");
            }

            var Customer = await customerRepository.GetByIdAsync(CustomerId);
            if (Customer == null)
            {
                throw new CustomerNotFoundException("Customer not found. ");
            }

            if (Session.SeatingCapacity > 0)
            {
                await ticketSalesRepository.AddAsync(ticketSales);

                Session.SeatingCapacity -= 1;
                var movie = await movieRepository.GetAll().Where(a=>a.Id == Session.MovieId).FirstAsync();
                ticketSales.Payment = movie.TicketPrice;

                ticketSales.CustomerId = CustomerId;
                ticketSales.SessionId = SessionId;

                await ticketSalesRepository.UpdateAsync(ticketSales);
                await customerRepository.UpdateAsync(Customer);
                await sessionRepository.UpdateAsync(Session);

                return ticketSales.Id;
            }
            return 0;
        }
        public async Task<Customer> CheckCustomerByPhoneNumber(string phoneNumber)
        {
            var customer = customerRepository.GetAll().Where(a => a.PhoneNumber == phoneNumber).FirstOrDefault();
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found.");
            }
            var customerFromRepo = await customerRepository.GetByIdAsync(customer.Id);
            if (customerFromRepo == null)
            {
                throw new CustomerNotFoundException("Customer not found in the repository.");
            }

            return customerFromRepo;
        }
        public async Task SellAnonymousTicket(long SessionId)
        {
            TicketSales ticketSales = new TicketSales()
            {
                SessionId = SessionId,
                SoldDate = DateTime.Now,
            };

            var Session = await sessionRepository.GetByIdAsync(SessionId);
            if (Session == null)
            {
                throw new MovieNotFoundExcepiton("Session not found. ");
            }
            if (Session.SeatingCapacity > 0)
            {
                await ticketSalesRepository.AddAsync(ticketSales);

                Session.SeatingCapacity -= 1;
                var movie = await movieRepository.GetAll().Where(a => a.Id == Session.MovieId).FirstAsync();
                ticketSales.Payment = movie.TicketPrice;

                ticketSales.SessionId = SessionId;

                await ticketSalesRepository.UpdateAsync(ticketSales);
                await sessionRepository.UpdateAsync(Session);
            }
        }
        public async Task TicketRefund(long TicketSalesId)
        {
            var TicketSales = await ticketSalesRepository.GetByIdAsync(TicketSalesId);
            if (TicketSales == null)
            {
                throw new TicketSalesNotFoundException("Ticket sales not fount");
            }

            var Customer = await customerRepository.GetByIdAsync(TicketSales.CustomerId);
            if (Customer == null)
            {
                throw new CustomerNotFoundException($"Customer not found. ");
            }
            var Session = await sessionRepository.GetByIdAsync(TicketSales.SessionId);
            if (Session == null)
            {
                throw new MovieNotFoundExcepiton("Session not found. ");
            }

            Session.SeatingCapacity += 1;

            await ticketSalesRepository.DeleteAsyncById(TicketSalesId);
        }
    }
}
