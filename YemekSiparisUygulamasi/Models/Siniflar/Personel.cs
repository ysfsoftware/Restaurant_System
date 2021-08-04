using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSiparisUygulamasi.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string PersonelSoyad { get; set; }
        public string PersonelMail { get; set; }
        public string PersonelTelefon { get; set; }
        public string PersonelGorsel { get; set; }
        public string Unvan { get; set; }
        public bool Durum { get; set; }
    }
}