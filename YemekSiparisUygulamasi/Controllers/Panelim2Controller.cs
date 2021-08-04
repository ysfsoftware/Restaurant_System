using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Controllers
{
    public class Panelim2Controller : Controller
    {
        Context c = new Context();
        // GET: Panelim2
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.mad = Session["MusteriAd"];
            Class1 cs = new Class1();
            cs.Deger6 = c.Yorums.ToList();
            return View(cs);
        }
        [Authorize]
        public ActionResult Menu()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        [Authorize]
        public ActionResult Galeri()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        [Authorize]
        public ActionResult Hakkimizda()
        {
          
            return View();
        }
        [Authorize]
        public ActionResult Personel()
        {
            Class1 cs = new Class1();
            cs.Deger2 = c.Personels.ToList();
            return View(cs);
        }
        [Authorize]
        public ActionResult Rezervasyonlarim()
        {
            var mid = Session["id"];
            var degerler = c.Rezervasyons.Where(x => x.Musteriid.ToString() == mid.ToString()).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Rezervasyon()
        {
            ViewBag.id = Session["id"];
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Rezervasyon(Rezervasyon r)
        {

            if (!ModelState.IsValid)
            {
                return View("Rezervasyon");
            }
            c.Rezervasyons.Add(r);
            c.SaveChanges();
            return View();
        }
      
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Panelim");
        }
    }
}