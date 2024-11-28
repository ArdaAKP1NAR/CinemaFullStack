using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class TicketSales : BaseEntity
    {
        public Session Session { get; set; } = default!;
        public long SessionId { get; set; }
        public Customer? Customer { get; set; }
        public long? CustomerId { get; set; }
        public DateTime SoldDate { get; set; }
        public double Payment {  get; set; }
    }
}
