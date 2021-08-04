using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Controllers
{
    public class PanelimController : Controller
    {
        Context c = new Context();
        // GET: Panelim
        public ActionResult Index()
        {

            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        public ActionResult Menu()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        public ActionResult Galeri()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        public ActionResult Hakkimizda()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Menus.ToList();
            return View(cs);
        }
        public ActionResult Personel()
        {
            Class1 cs = new Class1();
            cs.Deger2 = c.Personels.ToList();
            return View(cs);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KullaniciLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciLogin(Musteri a)
        {
            var bilgiler = c.Musteris.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["MusteriAd"] = bilgiler.MusteriAd.ToString();
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                Session["id"] = bilgiler.MusteriID.ToString();
                return RedirectToAction("Index", "Panelim2");
            }
            else
            {
                TempData["LoginMessage"] = "Kullanıcı adı veya şifre yanlış!";
                return RedirectToAction("Login", "Panelim");
            }

        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Musteri m)
        {
            ViewBag.yid = Session["yid"];
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            c.Musteris.Add(m);
            c.SaveChanges();
            return View();
        }

    }
}