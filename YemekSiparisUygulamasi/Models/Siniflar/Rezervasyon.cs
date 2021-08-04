using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Rezervasyon
    {
        [Key]
        public int RezervasyonID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Ad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }
        public string Mail { get; set; }
        public int KisiSayisi { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public virtual Musteri Musteri { get; set; }
        public  int Musteriid { get; set; }

    }
}