using LibraryControl.Models;
using LibraryControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryControl.Controllers
{
    public class HomeController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            //CountryList listemize DB deki Country tablomuzdaki değerleri ekliyoruz.
            foreach (var item in db.Countries)
            {
                model.CountryList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            foreach (var item in db.Countries)
            {
                model.CountryList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            //Seçilmiş ülkenin tatil günleri çekiliyor.
            var tatilGunleri = db.Vacations.Where(o => o.CountryId == model.SelectedCountryId);
            //Cumartesi ve Pazara denk gelen tatil günleri hesaplanıyor.
            int resmiTatil = 0;
            foreach (var rTatil in tatilGunleri)
            {
                if ((rTatil.VacationDay.ToString("dddd") != "Cumartesi" && rTatil.VacationDay.ToString("dddd") != "Pazar") && (rTatil.VacationDay >= model.TeslimTarihi && rTatil.VacationDay <= model.IadeTarihi))
                {
                    resmiTatil++;
                }
            }

            int isGunleriSayisi = GunHesapla(model.TeslimTarihi, model.IadeTarihi);

            model.IsGunuSayisi = isGunleriSayisi - resmiTatil;
            //İş gün sayısı 10'dan fazla ise ceza hesaplaması yapılıyor.
            if (model.IsGunuSayisi >= 10)
            {
                var cezaGunSayisi = model.IsGunuSayisi - 10;
                model.CezaliMi = true;
                model.CezaTutari = 5 * cezaGunSayisi;
                model.Currency = db.Countries.SingleOrDefault(o => o.Id == model.SelectedCountryId).Currency;
            }
            else
            {
                model.CezaliMi = false;
            }

            return View(model);
        }

        public static int GunHesapla(DateTime teslimTarihi, DateTime iadeTarihi)
        {
            DateTime geciciTarih = teslimTarihi;
            int gunSayi = 0;
            string gun = string.Empty;
            while (geciciTarih <= iadeTarihi)
            {
                gun = geciciTarih.ToString("dddd");
                if (gun != "Cumartesi" && gun != "Pazar")
                {
                    gunSayi++;
                }
                geciciTarih = geciciTarih.AddDays(1);
            }
            return gunSayi;
        }


    }
}
