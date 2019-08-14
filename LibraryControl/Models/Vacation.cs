using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryControl.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime VacationDay { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}