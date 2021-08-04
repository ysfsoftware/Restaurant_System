using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Controllers
{
    public class SepetController : Controller
    {
        Context c = new Context();
        // GET: Sepet
        [Authorize]
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = c.Musteris.FirstOrDefault(x => x.KullaniciAd == kullaniciadi);
                var model = c.Sepets.Where(x => x.Musteriid == kullanici.MusteriID).ToList();
                var kid = c.Sepets.FirstOrDefault(x => x.Musteriid == kullanici.MusteriID);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün Bulunmuyor.";
                    }
                    else if (kid != null)
                    {
                        Tutar = c.Sepets.Where(x => x.Musteriid == kid.Musteriid).Sum(x => x.ToplamTutar);
                        ViewBag.Tutar = "Toplam Tutar=" + Tutar + "₺";
                    }
                    return View(model);
                }
            }
            return HttpNotFound();
        }
        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAd = User.Identity.Name;
                var model = c.Musteris.FirstOrDefault(x => x.KullaniciAd == kullaniciAd);
                var urun = c.Menus.Find(id);
                var sepet = c.Sepets.FirstOrDefault(x => x.Musteriid == model.MusteriID && x.Menuid == id);
                if (model != null)
                {
                    if (sepet != null)
                    {
                        sepet.Miktar++;
                        sepet.ToplamTutar = urun.Fiyat * sepet.Miktar;
                        decimal toplamsepettutar = 0;
                        toplamsepettutar +=sepet.ToplamTutar;
                        c.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var s = new Sepet
                    {
                        Musteriid = model.MusteriID,
                        Menuid = urun.ID,
                        Miktar = 1,
                        Fiyat = urun.Fiyat,
                        ToplamTutar = urun.Fiyat

                    };
                    c.Entry(s).State = System.Data.Entity.EntityState.Added;
                    c.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
        public ActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = c.Musteris.FirstOrDefault(x => x.KullaniciAd == User.Identity.Name);
                count = c.Sepets.Where(x => x.Musteriid == model.MusteriID).Count();
                ViewBag.Count = count;
                if (count == 0)
                {
                    ViewBag.Count = "";
                }

                return PartialView();
            }
            return HttpNotFound();
        }
        public ActionResult Arttir(int id)
        {
            var model = c.Sepets.Find(id);
            model.Miktar++;
            model.ToplamTutar = model.Fiyat * model.Miktar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Azalt(int id)
        {
            var model = c.Sepets.Find(id);
            if (model.Miktar == 1)
            {
                c.Sepets.Remove(model);
                c.SaveChanges();
            }
            model.Miktar--;
            model.ToplamTutar = model.Fiyat * model.Miktar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public void DinamikMiktar(int id, int miktari)
        {
            var model = c.Sepets.Find(id);
            model.Miktar = miktari;
            model.ToplamTutar = model.Fiyat * model.Miktar;
            c.SaveChanges();
        }
        public ActionResult Sil(int id)
        {
            var model = c.Sepets.Find(id);
            c.Sepets.Remove(model);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index2(decimal? Tutar)
        {
            var model = c.Siparislers.ToList();
            return View(model);
        }
        public ActionResult SiparisVer(decimal? Tutar)
        {

            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = c.Musteris.FirstOrDefault(x => x.KullaniciAd == kullaniciadi);
                var model = c.Sepets.Where(x => x.Musteriid == kullanici.MusteriID).ToList();
                var kid = c.Sepets.FirstOrDefault(x => x.Musteriid == kullanici.MusteriID);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün Bulunmuyor.";
                    }
                    else if (kid != null)
                    {
                        Tutar = c.Sepets.Where(x => x.Musteriid == kid.Musteriid).Sum(x => x.ToplamTutar);
                        ViewBag.Tutar = "Toplam Tutar=" + Tutar + "₺";
                    }
                    return View(model);
                }
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult SiparisVer2()
        {
            var kid = User.Identity.Name;
            var musteri = c.Musteris.FirstOrDefault(x=>x.KullaniciAd==kid);
            var model = c.Sepets.Where(x => x.Musteriid == musteri.MusteriID).ToList();
            int row = 0;
            foreach(var x in model)
            {
                var siparis = new Siparisler
                {
                    Sepetid = model[row].SepetID,
                    Musteriid = model[row].Musteriid,
                    Menuid = model[row].Menuid,
                    ToplamTutar=model[row].ToplamTutar,
                    Tarih=DateTime.Now
                    
                };
                c.Siparislers.Add(siparis);
                row++;
            }
            foreach(var y in model)
            {
                var menu = c.Menus.FirstOrDefault(x => x.ID == y.Menuid);

            }

            c.Sepets.RemoveRange(model);
            c.SaveChanges();
            return RedirectToAction("Index","Sepet");
        }
        }
}