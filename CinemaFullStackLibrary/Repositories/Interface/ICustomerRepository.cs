using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer entity);
        Task DeleteAsync(Customer entity);
        Task DeleteAsyncById(long id);
        IQueryable<Customer> GetAll();
        Task<Customer?> GetByIdAsync(long? id);
        Task UpdateAsync(Customer entity);
    }
}
