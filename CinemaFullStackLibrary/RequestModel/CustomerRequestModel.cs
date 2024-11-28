using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.RequestModel
{
    public class CustomerRequestModel
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        // public string soyisim { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}
