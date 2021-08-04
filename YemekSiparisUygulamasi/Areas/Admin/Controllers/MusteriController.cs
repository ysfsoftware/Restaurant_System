using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class MusteriController : Controller
    {
        Context c = new Context();
        // GET: Admin/Musteri
        public ActionResult Index()
        {
            var degerler = c.Musteris.ToList();
            return View(degerler);
        }
        public ActionResult MusteriSil(int id)
        {
            var cr = c.Musteris.Find(id);
            c.Musteris.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = c.Musteris.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult MusteriGuncelle(Musteri m)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            var mstr = c.Musteris.Find(m.MusteriID);
            mstr.MusteriAd = m.MusteriAd;
            mstr.MusteriSoyad = m.MusteriSoyad;
            mstr.Cinsiyet = m.Cinsiyet;
            mstr.MusteriSehir = m.MusteriSehir;
            mstr.MusteriMail = m.MusteriMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}