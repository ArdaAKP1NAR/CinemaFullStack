using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.Models
{
    public class Customer : BaseEntity
    {
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;
        [MaxLength(100)]
        public string LastName { get; set; } = default!;
        // public string soyisim { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; } = default!;
        public DateTime BirthdayDate { get; set; }
        public List<Movie> Movies { get; set; } = default!;
    }
}
