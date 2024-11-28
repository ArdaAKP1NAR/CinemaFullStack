using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class Movie : BaseEntity
    {
        [MaxLength(100)]
        public string MovieName { get; set; } = default!;
        public double TicketPrice { get; set; }
        public int SeatingCapacity { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        [JsonIgnore]
        public List<Session> Session { get; set; } = default!;
        [JsonIgnore]
        public CinemaHall CinemaHall { get; set; } = default!;
        public long CinemaHallId { get; set; }
        public List<Customer> Customers { get; set; } = default!;
    }
}
