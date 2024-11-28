using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.ViewModels
{
    public class SessionViewModel
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SeatingCapacity { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
