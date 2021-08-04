using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Sepet
    {
        [Key]
        public int SepetID { get; set; }
        public virtual Menu Menu { get; set; }
        public int Menuid { get; set; }
        public virtual Musteri Musteri { get; set; }
        public int Musteriid { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Miktar { get; set; }
        public decimal ToplamTutar { get; set; }
        public ICollection<Siparisler> Siparislers { get; set; }
    }
}