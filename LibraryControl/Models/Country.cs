using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryControl.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}