using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Siparisler
    {
        [Key]
        public int SiparisID { get; set; }
        public virtual Musteri Musteri { get; set; }
        public int Musteriid { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string Durum { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
        public virtual Sepet Sepet { get; set; }
        public int? Sepetid { get; set; }
        public decimal ToplamTutar { get; set; }
        public virtual Menu Menu { get; set; }
        public int Menuid { get; set; }



    }
}