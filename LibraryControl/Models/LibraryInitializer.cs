using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryControl.Models
{
    public class LibraryInitializer : DropCreateDatabaseIfModelChanges<LibraryDbContext>
    {
        protected override void Seed(LibraryDbContext context)
        {
            //Ülke ve para birimleri set ediliyor.
            List<Country> countries = new List<Country>()
            {
                new Country(){Name="Turkey",Currency="TL",Id=1},
                new Country(){Name="USA",Currency="Dolar",Id=2},
                new Country(){Name="Germany",Currency="Euro",Id=3},
            };


            foreach (var item in countries)
            {
                context.Countries.Add(item);
            }
            context.SaveChanges();

            //Her ülke için tatil günü set ediyoruz.
            List<Vacation> vacations = new List<Vacation>()
            {
                new Vacation(){VacationDay=(Convert.ToDateTime("15/07/2019")),CountryId=1},
                new Vacation(){VacationDay=(Convert.ToDateTime("30/08/2019")),CountryId=1},
                new Vacation(){VacationDay=(Convert.ToDateTime("25/12/2019")),CountryId=2},
                new Vacation(){VacationDay=(Convert.ToDateTime("28/01/2019")),CountryId=2},
                new Vacation(){VacationDay=(Convert.ToDateTime("10/07/2019")),CountryId=3},
                new Vacation(){VacationDay=(Convert.ToDateTime("08/05/2019")),CountryId=3},
                new Vacation(){VacationDay=(Convert.ToDateTime("01/03/2019")),CountryId=3},
            };

            foreach (var item in vacations)
            {
                context.Vacations.Add(item);
            }
            context.SaveChanges();


            base.Seed(context);
        }
    }
}