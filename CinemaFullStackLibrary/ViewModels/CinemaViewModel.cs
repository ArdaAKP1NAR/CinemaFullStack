using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFullStackLibrary.ViewModels
{
    public class CinemaViewModel
    {
        public long Id { get; set; }
        public string CinemaName { get; set; }
        public List<CinemaHallViewModel> CinemaHalls { get; set; }
    }
}
