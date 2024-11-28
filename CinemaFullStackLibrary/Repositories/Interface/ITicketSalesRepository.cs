using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Repositories.Interface
{
    public interface ITicketSalesRepository
    {
        Task<TicketSales> AddAsync(TicketSales entity);
        Task DeleteAsync(TicketSales entity);
        Task DeleteAsyncById(long id);
        IQueryable<TicketSales> GetAll();
        Task<TicketSales?> GetByIdAsync(long? id);
        Task UpdateAsync(TicketSales entity);
    }
}
