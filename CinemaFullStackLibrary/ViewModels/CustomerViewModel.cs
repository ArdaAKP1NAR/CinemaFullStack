using CinemaFullStackLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.ViewModels
{
    public class CustomerViewModel
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
       // public string soyadi { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
