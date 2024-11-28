using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.ViewModels
{
    public class MovieViewModel
    {
        public long Id { get; set; }
        public string MovieName { get; set; }
        public int SeatingCapacity { get; set; }
        public double TicketPrice { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public long CinemaHallId { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
