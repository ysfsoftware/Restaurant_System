using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public string Aciklama { get; set; }
        public virtual Musteri Musteri { get; set; }
        public int Musteriid { get; set; }
    }
}