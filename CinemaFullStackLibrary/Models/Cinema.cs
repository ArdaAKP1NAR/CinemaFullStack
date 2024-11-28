using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class Cinema : BaseEntity
    {
        [MaxLength(100)]
        public string CinemaName { get; set; } = default!;
        [JsonIgnore]
        public List<CinemaHall> CinemaHalls { get; set; } = default!;
    }
}
