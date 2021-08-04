using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Menus.Where(x => x.Durum == true & x.Tur.Ad != "Tatlılar" & x.Tur.Ad != "İçecekler").ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YemekEkle()
        {
            List<SelectListItem> deger1 = (from i in c.Turs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();

        }
        [HttpPost]
        public ActionResult YemekEkle(Menu y)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                y.Gorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Menus.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YemekSil(int id)
        {
            var ymk = c.Menus.Find(id);
            ymk.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YemekGetir(int id)
        {
            List<SelectListItem> deger1 = (from i in c.Turs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ymk = c.Menus.Find(id);
            return View("YemekGetir", ymk);
        }
        public ActionResult YemekGuncelle(Menu y)
        {
            var ymk = c.Menus.Find(y.ID);
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                y.Gorsel = "/Image/" + dosyaadi + uzanti;
            }
            else
            {
                ymk.Ad = y.Ad;
                ymk.Aciklama = y.Aciklama;
                ymk.Durum = y.Durum;
                ymk.Fiyat = y.Fiyat;
                ymk.Turid = y.Turid;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            ymk.Ad = y.Ad;
            ymk.Aciklama = y.Aciklama;
            ymk.Durum = y.Durum;
            ymk.Fiyat = y.Fiyat;
            ymk.Gorsel = y.Gorsel;
            ymk.Turid = y.Turid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Index2()
        {
            var deger = c.Menus.Where(x => x.Tur.Ad == "Tatlılar" & x.Durum == true).ToList();
            return View(deger);
        }
        public ActionResult Index3()
        {
            var deger = c.Menus.Where(x => x.Tur.Ad == "İçecekler" & x.Durum == true).ToList();
            return View(deger);
        }

    }
}