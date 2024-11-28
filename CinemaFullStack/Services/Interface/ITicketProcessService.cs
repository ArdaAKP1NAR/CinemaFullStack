using CinemaFullStackLibrary.Models;

namespace CinemaFullStack.Services.Interface
{
    public interface ITicketProcessService
    {
        Task<Customer> CheckCustomerByPhoneNumber(string phoneNumber);
        Task SellAnonymousTicket(long SessionId);
        Task<long> SellTicket(long SessionId, long CustomerId);
        Task TicketRefund(long TicketSalesId);
    }
}