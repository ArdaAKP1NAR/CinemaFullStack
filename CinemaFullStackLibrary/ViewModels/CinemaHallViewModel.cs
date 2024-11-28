using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.ViewModels
{
    public class CinemaHallViewModel
    {
        public long Id { get; set; }
        public int HallNo { get; set; }
        public int SeatingCapacity { get; set; }
        public List<Movie> Movies { get; set; }
        public Cinema? Cinema { get; set; }
        public long? CinemaId { get; set; }
    }
}
