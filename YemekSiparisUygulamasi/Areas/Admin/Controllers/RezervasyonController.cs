using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Admin/Rezervasyon
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Rezervasyons.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult RezervasyonEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RezervasyonEkle(Rezervasyon r)
        {
            c.Rezervasyons.Add(r);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RezervasyonSil(int id)
        {
            var cr = c.Musteris.Find(id);
            c.Musteris.Remove(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RezervasyonGetir(int id)
        {
            var rezervasyon = c.Rezervasyons.Find(id);
            return View("RezervasyonGetir", rezervasyon);
        }
        public ActionResult RezervasyonGuncelle(Rezervasyon r)
        {
            if (!ModelState.IsValid)
            {
                return View("RezervasyonGetir");
            }
            var rzrv = c.Rezervasyons.Find(r.RezervasyonID);
            rzrv.Ad = r.Ad;
            rzrv.Soyad = r.Soyad;
            rzrv.TelefonNo = r.TelefonNo;
            rzrv.Mail = r.Mail;
            rzrv.KisiSayisi = r.KisiSayisi;
            rzrv.Tarih = r.Tarih;
            rzrv.Saat = r.Saat;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}