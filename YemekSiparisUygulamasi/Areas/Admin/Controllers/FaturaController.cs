using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Admin/Fatura
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            List<SelectListItem> deger1 = (from i in c.Siparislers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Sepet.Menu.Ad,
                                               Value = i.SiparisID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {

            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var ftr = c.Faturas.Find(f.FaturaID);
            ftr.Tarih = f.Tarih;
            ftr.Siparisid = f.Siparisid;
            ftr.ToplamTutar = f.ToplamTutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.Faturas.Find(id);
            return View(degerler);
        }
    }
}