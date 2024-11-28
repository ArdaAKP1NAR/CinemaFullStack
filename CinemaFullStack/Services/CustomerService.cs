using AutoMapper;
using CinemaFullStack.Exceptions;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.Repositories.Interface;
using CinemaFullStackLibrary.RequestModel;
using System.Text.RegularExpressions;

namespace CinemaFullStack.Services
{
    public class CustomerService(ICustomerRepository customerRepository,IMapper mapper) : ICustomerService
    {
        public async Task AddCustomer(Customer customer)
        {
            var regex = new Regex(@"^[a-zA-Z\s]+$");

            if (!regex.IsMatch(customer.FirstName))
            {
                throw new InvalidCustomerNameException("Name can only contain letters");
            }
            if (!regex.IsMatch(customer.LastName))
            {
                throw new InvalidCustomerNameException("Name can only contain letters");
            }
            var Customer = await customerRepository.AddAsync(customer);
        }
    }
}
