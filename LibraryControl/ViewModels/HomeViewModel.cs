using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryControl.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            CountryList = new List<SelectListItem>();
        }
        public int SelectedCountryId { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public DateTime IadeTarihi { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public int IsGunuSayisi { get; set; }
        public decimal CezaTutari { get; set; }
        public string Currency { get; set; }
        public bool CezaliMi { get; set; }


    }
}