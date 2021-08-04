using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Admin/Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        public ActionResult PersonelSil(int id)
        {
            var prsnl = c.Personels.Find(id);
            prsnl.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsnl = c.Personels.Find(p.PersonelID);
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image2/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image2/" + dosyaadi + uzanti;
            }
            else {
                prsnl.PersonelAd = p.PersonelAd;
                prsnl.PersonelSoyad = p.PersonelSoyad;
                prsnl.PersonelTelefon = p.PersonelTelefon;
                prsnl.PersonelMail = p.PersonelMail;
                prsnl.Unvan = p.Unvan;
                prsnl.Durum = p.Durum;
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            prsnl.PersonelAd =p.PersonelAd;
            prsnl.PersonelSoyad = p.PersonelSoyad;
            prsnl.PersonelTelefon = p.PersonelTelefon;
            prsnl.PersonelMail = p.PersonelMail;
            prsnl.Unvan = p.Unvan;
            prsnl.Durum = p.Durum;
            prsnl.PersonelGorsel = p.PersonelGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel y)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image2/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                y.PersonelGorsel = "/Image2/" + dosyaadi + uzanti;
            }
            c.Personels.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}