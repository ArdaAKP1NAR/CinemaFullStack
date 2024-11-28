using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class Session : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SeatingCapacity { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; } = default!;
        public long MovieId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
