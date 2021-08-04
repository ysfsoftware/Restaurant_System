using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSiparisUygulamasi.Models.Siniflar;

namespace YemekSiparisUygulamasi.Areas.Admin.Controllers
{
    public class GaleriController : Controller
    {
        Context c = new Context();
        // GET: Admin/Galeri
        public ActionResult Index()
        {
            var degerler = c.Menus.ToList();
            return View(degerler);
        }
    }
}