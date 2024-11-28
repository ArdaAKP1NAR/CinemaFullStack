using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;

namespace CinemaFullStack.Services.Interface
{
    public interface ICustomerService
    {
        Task AddCustomer(Customer customer);
    }
}