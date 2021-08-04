using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class TurController : Controller
    {
        Context c = new Context();
        // GET: Tur
        public ActionResult Index()
        {
            var degerler = c.Turs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult TurEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult TurEkle(Tur t)
        {
            c.Turs.Add(t);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TurSil(int id)
        {
            var tur = c.Turs.Find(id);
            c.Turs.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TurGetir(int id)
        {
            var tur = c.Turs.Find(id);
            return View("TurGetir", tur);
        }
        public ActionResult TurGuncelle(Tur t)
        {
            var tur = c.Turs.Find(t.ID);
            tur.Ad = t.Ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}