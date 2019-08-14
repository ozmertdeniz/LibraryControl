using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryControl.Models
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext() : base("libraryDb")
        {
            Database.SetInitializer(new LibraryInitializer());
        }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}