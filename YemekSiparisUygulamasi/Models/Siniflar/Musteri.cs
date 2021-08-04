using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Musteri
    {
        [Key]

        public int MusteriID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        [Required]
        public string MusteriAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string MusteriSoyad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(1)]
        public string Cinsiyet { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string MusteriSehir { get; set; }
        public string MusteriMail { get; set; }
        public string MusteriTelefon { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public ICollection<Siparisler> Siparislers { get; set; }
        public ICollection<Rezervasyon> Rezervasyons { get; set; }
        public ICollection<Yorum> Yorums { get; set; }
        public ICollection<Sepet> Sepets { get; set; }
    }
}