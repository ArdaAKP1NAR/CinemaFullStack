using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class CinemaHall : BaseEntity
    {
        public int HallNo { get; set; }
        public int SeatingCapacity { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; } = default!;
        [JsonIgnore]
        public Cinema? Cinema { get; set; }
        public long? CinemaId { get; set; }
    }
}
