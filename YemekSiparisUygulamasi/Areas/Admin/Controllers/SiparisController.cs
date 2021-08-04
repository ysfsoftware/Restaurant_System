using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class SiparisController : Controller
    {
        Context c = new Context();
        // GET: Admin/Siparis
        public ActionResult Index()
        {
            var degerler = c.Siparislers.ToList();
            return View(degerler);
        }
        public ActionResult SiparisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Menus.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.ID.ToString()
                                           }).ToList();
      
            List<SelectListItem> deger2 = (from x in c.Musteris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MusteriAd + " " + x.MusteriSoyad,
                                               Value = x.MusteriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            var sprs = c.Siparislers.Find(id);
            return View("SiparisGetir", sprs);
        }
        public ActionResult SiparisGuncelle(Siparisler s)
        {
            if (!ModelState.IsValid)
            {
                return View("SiparisGetir");
            }
            var sprs = c.Siparislers.Find(s.SiparisID);
            sprs.Tarih = s.Tarih;
            sprs.Saat = s.Saat;
            sprs.Durum = s.Durum;
            sprs.ToplamTutar = s.ToplamTutar;
            sprs.Sepetid = s.Sepetid;
            sprs.Musteriid = s.Musteriid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}